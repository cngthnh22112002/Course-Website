using Abp.Application.Services;
using CourseWebsite.Subjects.Dtos;

namespace CourseWebsite.Subjects.Services.Interfaces
{
    public interface ISubjectAppService : IAsyncCrudAppService<SubjectDto, int, SubjectFilterDto, CreateSubjectDto, SubjectDto>
    {
    }
}
