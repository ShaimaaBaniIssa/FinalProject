using FinalProject.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Services
{
    public interface IRoleService
    {
        List<Role> GetAllRoles();
        Role GetRoleById(int id);
        void CreateRole(Role role);
        void UpdateRole(Role role);
        void DeleteRole(int id);
    }

}
