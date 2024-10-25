using FinalProject.Core.Data;
using FinalProject.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Services
{
    public interface ILoginService
    {
        List<Login> GetAllLogins();
        Login GetLoginById(int id);
        void CreateLogin(Login login);
        void UpdateLogin(Login login);
        void DeleteLogin(int id);
        string Auth(Login login);
        int CountUser();
        void Registration(Registration regInfo);
    }
}
