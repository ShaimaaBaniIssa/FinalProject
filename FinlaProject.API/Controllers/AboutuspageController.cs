using FinalProject.Core.Data;
using FinalProject.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutuspageController : ControllerBase
    {
        private readonly IAboutuspageService _aboutuspageService;
        public AboutuspageController(IAboutuspageService aboutuspageService)
        {
            _aboutuspageService = aboutuspageService;
        }

        [HttpGet]
        public List<Aboutuspage> GetAllAboutUsPages()
        {
            return _aboutuspageService.GetAllAboutUsPages();
        }


        [HttpPost]
        [Route("CreateAboutUsPage")]
        public void CreateAboutUsPage(Aboutuspage aboutuspage)
        {
            _aboutuspageService.CreateAboutUsPage(aboutuspage);

        }


        [HttpPut]
        [Route("UpdateAboutUsPage")]
        public void UpdateAboutUsPage(Aboutuspage aboutuspage)
        {
            _aboutuspageService.UpdateAboutUsPage(aboutuspage);
        }
    }
}

