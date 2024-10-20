using Dapper;
using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using FinalProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infra.Services
{
    public class ContactuspageServices: IContactuspageServices
    {

        private readonly IContactuspageRepository _contactuspageRepository;
        public ContactuspageServices(IContactuspageRepository contactuspageRepository)
        {
            _contactuspageRepository = contactuspageRepository;
        }
        public List<Contactuspage> GetAllContactusPages()
        {
            return _contactuspageRepository.GetAllContactusPages();
        }

        public void CreateContactusPage(Contactuspage contactuspage)
        {
            _contactuspageRepository.CreateContactusPage(contactuspage);

        }
        public void UpdateContactusPage(Contactuspage contactuspage)
        {
            _contactuspageRepository.UpdateContactusPage(contactuspage);
        }
    }
}
