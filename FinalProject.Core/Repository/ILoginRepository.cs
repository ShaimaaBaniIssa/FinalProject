using FinalProject.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Repository
{
    public interface ILoginRepository
    {
        List<Login> GetAllLogins();
        Login GetLoginById(int id);
        void CreateLogin(Login login);
        void UpdateLogin(Login login);
        void DeleteLogin(int id);

    }
}
