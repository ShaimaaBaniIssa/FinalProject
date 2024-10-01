using Dapper;
using FinalProject.Core.Common;
using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infra.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IDbContext _dbContext;
        public RoleRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Role> GetAllRoles()
        {

            //query == reterive data from db 

            IEnumerable<Role> result = _dbContext.Connection.Query<Role>("Role_Package.GetAllRoles", commandType: CommandType.StoredProcedure);

            return result.ToList();

        }
        public Role GetRoleById(int id)

        {

            //dapper

            var p = new DynamicParameters(); // pass data to database (stored proc.)

            p.Add("p_RoleId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Role>("Role_Package.GetRoleById", p, commandType: CommandType.StoredProcedure);

            return result.SingleOrDefault();

        }
        public void CreateRole(Role role)

        {

            var p = new DynamicParameters();

            p.Add("p_RoleName", role.Rolename, dbType: DbType.String, direction: ParameterDirection.Input);



            _dbContext.Connection.Execute("Role_Package.CreateRole", p, commandType: CommandType.StoredProcedure);


        }
        public void UpdateRole(Role role)

        {

            var p = new DynamicParameters();

            p.Add("p_RoleId", role.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            p.Add("p_RoleName", role.Rolename, dbType: DbType.String, direction: ParameterDirection.Input);


            _dbContext.Connection.Execute("Role_Package.UpdateRole", p, commandType: CommandType.StoredProcedure);

        }
        public void DeleteRole(int id)

        {

            var p = new DynamicParameters();

            p.Add("p_RoleId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("Role_Package.DeleteRole", p, commandType: CommandType.StoredProcedure);

        }


    }

}
