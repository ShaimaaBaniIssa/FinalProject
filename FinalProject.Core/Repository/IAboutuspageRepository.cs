using FinalProject.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace FinalProject.Core.Repository
{
    public interface IAboutuspageRepository
    {
        Aboutuspage GetAllAboutPages();
        void CreateAboutUsPage(Aboutuspage aboutuspage);
        void UpdateAboutUsPage(Aboutuspage aboutuspage);
    }
}
