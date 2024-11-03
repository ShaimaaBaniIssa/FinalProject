using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using FinalProject.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactuspageController : ControllerBase
    {
        private readonly IContactuspageServices _contactuspageServices;
        public ContactuspageController(IContactuspageServices contactuspageServices)
        {
            _contactuspageServices = contactuspageServices;
        }

        [HttpGet]
        [AllowAnonymous]
        public Contactuspage GetAllContactusPages()
        {
            return _contactuspageServices.GetAllContactusPages();
        }


        [HttpPost]
        [Route("CreateContactusPage")]
        [CheckClaims("roleid", "21")]

        public void CreateContactusPage(Contactuspage contactuspage)
        {
            _contactuspageServices.CreateContactusPage(contactuspage);

        }


        [HttpPut]
        [Route("UpdateContactusPage")]
        [CheckClaims("roleid", "21")]

        public void UpdateContactusPage(Contactuspage contactuspage)
        {
            _contactuspageServices.UpdateContactusPage(contactuspage);
        }
    }
}
