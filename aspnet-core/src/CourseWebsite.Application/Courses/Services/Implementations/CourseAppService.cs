using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using CourseWebsite.Courses;
using CourseWebsite.Courses.Dtos;
using CourseWebsite.Subjects.Dtos;
using CourseWebsite.Relations;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using System.Collections.Generic;
using Abp.Runtime.Validation;
using CourseWebsite.Subjects;
using CourseWebsite.Exceptions;

public class CourseAppService : AsyncCrudAppService<Course, CourseDto, int, CourseFilterDto, CreateCourseDto, CourseDto>
{
    private readonly IRepository<Course, int> _courseRepository;
    private readonly IRepository<Subject, int> _subjectRepository;

    public CourseAppService(IRepository<Course, int> courseRepository, IRepository<Subject, int> subjectRepository)
        : base(courseRepository)
    {
        _courseRepository = courseRepository;
        _subjectRepository = subjectRepository;
    }

    #region Public method
    public override async Task<PagedResultDto<CourseDto>> GetAllAsync(CourseFilterDto input)
    {
        var query = CreateFilteredQuery(input);
        var totalCount = await AsyncQueryableExecuter.CountAsync(query);
        var items = await AsyncQueryableExecuter.ToListAsync(query
            .OrderBy(input.Sorting ?? "Name")
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount)
        );

        return new PagedResultDto<CourseDto>(
            totalCount,
            ObjectMapper.Map<List<CourseDto>>(items)
        );
    }

    public override async Task<CourseDto> CreateAsync(CreateCourseDto input)
    {
        var subjectIds = input.Subjects.Select(i => i.SubjectId).ToList();
        var subjects = await _subjectRepository.GetAllListAsync(s => subjectIds.Contains(s.Id));

        var validSubjectIds = new HashSet<int>(subjects.Select(s => s.Id));
        var invalidSubjectIds = subjectIds.Except(validSubjectIds).ToList();
        if (invalidSubjectIds.Any())
        {
            throw new AbpValidationException(string.Join(", ", invalidSubjectIds.Select(id => SubjectErrors.NotExist(id).ToString())));
        }

        var course = ObjectMapper.Map<Course>(input);
        foreach (var subject in input.Subjects)
        {
            var subjectEntity = subjects.Single(s => s.Id == subject.SubjectId);
            course.CourseSubjects.Add(new CourseSubject
            {
                Course = course,
                Subject = subjectEntity,
                Order = subject.Order
            });
        }

        await _courseRepository.InsertAsync(course);
        await CurrentUnitOfWork.SaveChangesAsync();

        return MapToEntityDto(course);
    }

    public override async Task<CourseDto> GetAsync(EntityDto<int> input)
    {
        var course = await _courseRepository.GetAll()
                                            .Include(c => c.CourseSubjects)
                                            .ThenInclude(cs => cs.Subject)
                                            .FirstOrDefaultAsync(c => c.Id == input.Id);
        if (course == null)
        {
            throw new AbpValidationException(CourseErrors.NotExist(input.Id).ToString());
        }
        var courseDto = ObjectMapper.Map<CourseDto>(course);
        courseDto.Subjects = course.CourseSubjects.Select(cs => ObjectMapper.Map<SubjectDto>(cs.Subject)).ToList();
        return courseDto;
    }

    public async Task AddSubjectAsync(AddSubjectToCourseDto input)
    {
        var course = await _courseRepository.GetAllIncluding(c => c.CourseSubjects)
                                            .FirstOrDefaultAsync(c => c.Id == input.CourseId);
        if (course == null)
        {
            throw new AbpValidationException(CourseErrors.NotExist(input.CourseId).ToString());
        }

        var subject = await _subjectRepository.FirstOrDefaultAsync(input.SubjectId);
        if (subject == null)
        {
            throw new AbpValidationException(SubjectErrors.NotExist(input.SubjectId).ToString());
        }

        // Update the order of existing subjects
        foreach (var courseSubject in course.CourseSubjects.Where(cs => cs.Order >= input.Order))
        {
            courseSubject.Order++;
        }

        // Add the new subject
        course.CourseSubjects.Add(new CourseSubject
        {
            CourseId = input.CourseId,
            SubjectId = input.SubjectId,
            Order = input.Order
        });

        await _courseRepository.UpdateAsync(course);
        await CurrentUnitOfWork.SaveChangesAsync();
    }

    public async Task RemoveSubjectAsync(RemoveSubjectFromCourseDto input)
    {
        var course = await _courseRepository.GetAllIncluding(c => c.CourseSubjects)
                                            .FirstOrDefaultAsync(c => c.Id == input.CourseId);
        if (course == null)
        {
            throw new AbpValidationException(CourseErrors.NotExist(input.CourseId).ToString());
        }

        var courseSubject = course.CourseSubjects.FirstOrDefault(cs => cs.SubjectId == input.SubjectId);
        if (courseSubject == null)
        {
            throw new AbpValidationException(CourseErrors.SubjectNotInCourse(input.CourseId, input.SubjectId).ToString());
        }

        course.CourseSubjects.Remove(courseSubject);

        // Remove the subject from the course
        foreach (var cs in course.CourseSubjects.Where(cs => cs.Order > courseSubject.Order))
        {
            cs.Order--;
        }

        await _courseRepository.UpdateAsync(course);
        await CurrentUnitOfWork.SaveChangesAsync();
    }
    #endregion

    protected override IQueryable<Course> CreateFilteredQuery(CourseFilterDto input)
    {
        var query = base.CreateFilteredQuery(input);
        if (!string.IsNullOrEmpty(input.Name))
        {
            query = query.Where(c => c.Name.Contains(input.Name));
        }
        if (!string.IsNullOrEmpty(input.Description))
        {
            query = query.Where(c => c.Description.Contains(input.Description));
        }
        if (!string.IsNullOrEmpty(input.ImageUrl))
        {
            query = query.Where(c => c.ImageUrl.Contains(input.ImageUrl));
        }
        return query;
    }

}
