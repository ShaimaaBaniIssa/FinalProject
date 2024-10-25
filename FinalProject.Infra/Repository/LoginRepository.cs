using Dapper;
using FinalProject.Core.Common;
using FinalProject.Core.Data;
using FinalProject.Core.DTO;
using FinalProject.Core.Repository;
using FinalProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infra.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IPasswordHasher _passwordHasher;
        public LoginRepository(IDbContext dbContext,IPasswordHasher passwordHasher)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }
        public List<Login> GetAllLogins()
        {

            //query == reterive data from db 

            IEnumerable<Login> result = _dbContext.Connection.Query<Login>("Login_Package.GetAllLogins", commandType: CommandType.StoredProcedure);

            return result.ToList();

        }
        public Login GetLoginById(int id)

        {

            //dapper

            var p = new DynamicParameters(); // pass data to database (stored proc.)

            p.Add("p_LoginId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Login>("Login_Package.GetLoginById", p, commandType: CommandType.StoredProcedure);

            return result.SingleOrDefault();

        }
        public void CreateLogin(Login login)

        {

            var p = new DynamicParameters();

            p.Add("p_UserName", login.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Password", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_CustomerId", login.Customerid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_RoleId", login.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);



            _dbContext.Connection.Execute("Login_Package.CreateLogin", p, commandType: CommandType.StoredProcedure);


        }
        public void UpdateLogin(Login login)

        {

            var p = new DynamicParameters();

            p.Add("p_LoginId", login.Loginid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_UserName", login.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Password", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_CustomerId", login.Customerid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_RoleId", login.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);


            _dbContext.Connection.Execute("Login_Package.UpdateLogin", p, commandType: CommandType.StoredProcedure);

        }
        public void DeleteLogin(int id)

        {

            var p = new DynamicParameters();

            p.Add("p_LoginId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("Login_Package.DeleteLogin", p, commandType: CommandType.StoredProcedure);

        }

        public Login Auth(Login login)
        {
            var p = new DynamicParameters();
           
            //name from PROCEDURE(User_NAME,Pass)
            p.Add("User_NAME", login.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            var res = _dbContext.Connection.Query<Login>("Login_Package.User_Login", p, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            var hashPass = _passwordHasher.Verify(res.Password, login.Password);
            if (hashPass == false)
            {
                return null;
            }
            else
            {
                return res;
            }
        }
        public int CountUser()
        {

            var result = _dbContext.Connection.Query<int>("Report.GetTotalUsers", commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public void Registration(Registration regInfo)

        {

            var p = new DynamicParameters();

            //p.Add("p_Latitude", regInfo.Latitude, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            //p.Add("p_Longitude", regInfo.Longitude, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("p_FName", regInfo.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_LName", regInfo.Lname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Email", regInfo.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_PhoneNumber", regInfo.Phonenumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_adress", regInfo.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            // Output parameter for CustomerId
            p.Add("p_CustomerId", dbType: DbType.Int32, direction: ParameterDirection.Output);


            _dbContext.Connection.Execute("Customer_Package.CreateCustomer", p, commandType: CommandType.StoredProcedure);
            // Retrieve the CustomerId from the OUT parameter
            var id = p.Get<int>("p_CustomerId");

            var pLog = new DynamicParameters();
            var hashPass = _passwordHasher.Hash(regInfo.Password);

            pLog.Add("p_UserName", regInfo.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            pLog.Add("p_Password", hashPass, dbType: DbType.String, direction: ParameterDirection.Input);
            pLog.Add("p_CustomerId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            pLog.Add("p_RoleId", 1, dbType: DbType.Int32, direction: ParameterDirection.Input);



            _dbContext.Connection.Execute("Login_Package.CreateLogin", pLog, commandType: CommandType.StoredProcedure);

        }

    }
}
