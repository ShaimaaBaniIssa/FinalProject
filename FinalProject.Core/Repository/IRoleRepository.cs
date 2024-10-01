﻿using FinalProject.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Repository
{
    
        public interface IRoleRepository
        {
            List<Role> GetAllRoles();
            Role GetRoleById(int id);
            void CreateRole(Role role);
            void UpdateRole(Role role);
            void DeleteRole(int id);


        }

    
}
