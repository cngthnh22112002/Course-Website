using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using CourseWebsite.Subjects.Dtos;
using CourseWebsite.Subjects.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace CourseWebsite.Subjects.Services.Implementations
{
    public class SubjectAppService : AsyncCrudAppService<Subject, SubjectDto, int, SubjectFilterDto, CreateSubjectDto, SubjectDto>, ISubjectAppService
    {
        private readonly IRepository<Subject, int> _subjectRepository;

        public SubjectAppService(IRepository<Subject, int> subjectRepository) : base(subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        protected override IQueryable<Subject> CreateFilteredQuery(SubjectFilterDto input)
        {
            var query = base.CreateFilteredQuery(input);

            if (!string.IsNullOrEmpty(input.Name))
            {
                query = query.Where(s => s.Name.Contains(input.Name));
            }
            if (!string.IsNullOrEmpty(input.Description))
            {
                query = query.Where(s => s.Description.Contains(input.Description));
            }

            return query;
        }

        public override async Task<PagedResultDto<SubjectDto>> GetAllAsync(SubjectFilterDto input)
        {
            var query = CreateFilteredQuery(input);
            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            var items = await AsyncQueryableExecuter.ToListAsync(query
                .OrderBy(input.Sorting ?? "Name")  // Use dynamic sorting
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
            );

            return new PagedResultDto<SubjectDto>(
                totalCount,
                ObjectMapper.Map<List<SubjectDto>>(items)
            );
        }
    }
}
