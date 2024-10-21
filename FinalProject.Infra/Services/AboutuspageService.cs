using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using FinalProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infra.Services
{
    public class AboutuspageService: IAboutuspageService
    {
        private readonly IAboutuspageRepository _aboutuspageRepository;
        public AboutuspageService(IAboutuspageRepository aboutuspageRepository)
        {
            _aboutuspageRepository = aboutuspageRepository;
        }
        public Aboutuspage GetAllAboutPages()
        {
            return _aboutuspageRepository.GetAllAboutPages();
        }

        public void CreateAboutUsPage(Aboutuspage aboutuspage)
        {
            _aboutuspageRepository.CreateAboutUsPage(aboutuspage);

        }
        public void UpdateAboutUsPage(Aboutuspage aboutuspage)
        {
            _aboutuspageRepository.UpdateAboutUsPage(aboutuspage);
        }
    }





}

