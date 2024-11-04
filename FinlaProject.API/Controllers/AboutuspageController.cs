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
    public class AboutuspageController : ControllerBase
    {
        private readonly IAboutuspageService _aboutuspageService;
        public AboutuspageController(IAboutuspageService aboutuspageService)
        {
            _aboutuspageService = aboutuspageService;
        }

        [HttpGet]
        [AllowAnonymous]
        public Aboutuspage GetAllAboutPages()
        {
            return _aboutuspageService.GetAllAboutPages();
        }


        [HttpPost]
        [Route("CreateAboutUsPage")]
        [CheckClaims("roleid", "21")]

        public void CreateAboutUsPage(Aboutuspage aboutuspage)
        {
            _aboutuspageService.CreateAboutUsPage(aboutuspage);

        }


        [HttpPut]
        [Route("UpdateAboutUsPage")]
        [CheckClaims("roleid", "21")]

        public void UpdateAboutUsPage(Aboutuspage aboutuspage)
        {
            _aboutuspageService.UpdateAboutUsPage(aboutuspage);
        }
    }
}

