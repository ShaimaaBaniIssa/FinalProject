using FinalProject.Core.Data;
using FinalProject.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HomePageController : ControllerBase
    {
        private readonly IHomePageServices _homePageServices;
        private readonly IConfiguration _configuration;

        public HomePageController(IHomePageServices homePageServices, IConfiguration configuration)
        {
            _homePageServices = homePageServices;
            _configuration = configuration;
        }
        [HttpGet]
        [AllowAnonymous]
        public Homepage GetHomePage()
        {
            return _homePageServices.GetHomePage();
        }
        [HttpPost]
        [Route("CreateHomePage")]
        [CheckClaims("roleid", "21")]

        public void CreateHomePage(Homepage homepage)
        {
            _homePageServices.CreateHomePage(homepage);
        }
        [HttpPut]
        [Route("UpdateHomePage")]
        [CheckClaims("roleid", "21")]

        public void UpdateHomePage(Homepage homepage)
        {
            _homePageServices.UpdateHomePage(homepage);
        }
        [Route("UploadImage")]
        [HttpPost]
        [CheckClaims("roleid", "21")]
        public Homepage UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var imageFolderPath = _configuration["ImageFolderPath"];
            var fullPath = Path.Combine(imageFolderPath, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Homepage homepage = new Homepage();
            homepage.Logoimage = fileName;
            return homepage;
        }
    }
}
