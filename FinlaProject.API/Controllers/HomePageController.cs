using FinalProject.Core.Data;
using FinalProject.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomePageController : ControllerBase
    {
        private readonly IHomePageServices _homePageServices;
        public HomePageController(IHomePageServices homePageServices)
        {
            _homePageServices = homePageServices;
        }
        [HttpGet]
        public Homepage GetHomePage()
        {
            return _homePageServices.GetHomePage();
        }
        [HttpPost]
        [Route("CreateHomePage")]
        public void CreateHomePage(Homepage homepage)
        {
            _homePageServices.CreateHomePage(homepage);
        }
        [HttpPut]
        [Route("UpdateHomePage")]
        public void UpdateHomePage(Homepage homepage)
        {
            _homePageServices.UpdateHomePage(homepage);
        }
    }
}
