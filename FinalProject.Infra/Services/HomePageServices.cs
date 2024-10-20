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
    public class HomePageServices : IHomePageServices
    {
        private readonly IHomePageRepository _homePageRepository;

        public HomePageServices(IHomePageRepository homePageRepository)
        {
            _homePageRepository = homePageRepository;
        }

        public List<Homepage> GetAllHomePages()
        { 
            return _homePageRepository.GetAllHomePages();
        }

        public void CreateHomePage(Homepage homepage)
        {
            _homePageRepository.CreateHomePage(homepage);
        }
        public void UpdateHomePage(Homepage homepage)
        {
            _homePageRepository.UpdateHomePage(homepage);
        }
    }
}
