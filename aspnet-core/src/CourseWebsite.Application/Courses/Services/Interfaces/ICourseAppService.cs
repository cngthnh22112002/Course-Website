using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CourseWebsite.Courses.Dtos;
using System.Threading.Tasks;

namespace CourseWebsite.Courses.Services.Interfaces
{
    public interface ICourseAppService : IAsyncCrudAppService<CourseDto, int, PagedResultRequestDto, CreateCourseDto, CourseDto>
    {
        Task AddSubjectAsync(AddSubjectToCourseDto input);
        Task RemoveSubjectAsync(RemoveSubjectFromCourseDto input);
    }
}
