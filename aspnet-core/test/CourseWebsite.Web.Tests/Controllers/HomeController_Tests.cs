using System.Threading.Tasks;
using CourseWebsite.Models.TokenAuth;
using CourseWebsite.Web.Controllers;
using Shouldly;
using Xunit;

namespace CourseWebsite.Web.Tests.Controllers
{
    public class HomeController_Tests: CourseWebsiteWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}