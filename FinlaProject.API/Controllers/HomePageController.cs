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
        public HomePageController(IHomePageServices homePageServices)
        {
            _homePageServices = homePageServices;
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
    }
}
