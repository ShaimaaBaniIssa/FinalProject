using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using FinalProject.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactuspageController : ControllerBase
    {
        private readonly IContactuspageServices _contactuspageServices;
        public ContactuspageController(IContactuspageServices contactuspageServices)
        {
            _contactuspageServices = contactuspageServices;
        }

        [HttpGet]
        public Contactuspage GetAllContactusPages()
        {
            return _contactuspageServices.GetAllContactusPages();
        }


        [HttpPost]
        [Route("CreateContactusPage")]
        public void CreateContactusPage(Contactuspage contactuspage)
        {
            _contactuspageServices.CreateContactusPage(contactuspage);

        }


        [HttpPut]
        [Route("UpdateContactusPage")]
        public void UpdateContactusPage(Contactuspage contactuspage)
        {
            _contactuspageServices.UpdateContactusPage(contactuspage);
        }
    }
}
