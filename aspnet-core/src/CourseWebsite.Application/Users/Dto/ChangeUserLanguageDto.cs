using System.ComponentModel.DataAnnotations;

namespace CourseWebsite.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}