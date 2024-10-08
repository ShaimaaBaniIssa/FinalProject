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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IPasswordHasher _passwordHasher ;
        public CustomerRepository(IDbContext dbContext, IPasswordHasher passwordHasher)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }
        public List<Customer> GetAllCustomers()
        {

            //query == reterive data from db 

            IEnumerable<Customer> result = _dbContext.Connection.Query<Customer>("Customer_Package.GetAllCustomers", commandType: CommandType.StoredProcedure);

            return result.ToList();

        }
        public Customer GetCustomerById(int id)

        {

            //dapper

            var p = new DynamicParameters(); // pass data to database (stored proc.)

            p.Add("p_CustomerId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Customer>("Customer_Package.GetCustomerById", p, commandType: CommandType.StoredProcedure);

            return result.SingleOrDefault();

        }
        public void CreateCustomer(Customer customer)

        {

            var p = new DynamicParameters();

            p.Add("p_Latitude", customer.Latitude, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("p_Longitude", customer.Longitude, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("p_FName", customer.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_LName", customer.Lname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Email", customer.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_PhoneNumber", customer.Phonenumber, dbType: DbType.Int32, direction: ParameterDirection.Input);



            _dbContext.Connection.Execute("Customer_Package.CreateCustomer", p, commandType: CommandType.StoredProcedure);


        }
        public void UpdateCustomer(Customer customer)

        {

            var p = new DynamicParameters();

            p.Add("p_CustomerId", customer.Customerid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_Latitude", customer.Latitude, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("p_Longitude", customer.Longitude, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("p_FName", customer.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_LName", customer.Lname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Email", customer.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_PhoneNumber", customer.Phonenumber, dbType: DbType.Int32, direction: ParameterDirection.Input);


            _dbContext.Connection.Execute("Customer_Package.UpdateCustomer", p, commandType: CommandType.StoredProcedure);

        }
        public void DeleteCustomer(int id)

        {

            var p = new DynamicParameters();

            p.Add("p_CustomerId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("Customer_Package.DeleteCustomer", p, commandType: CommandType.StoredProcedure);

        }

        public void Registration(Registration regInfo)

        {

            var p = new DynamicParameters();

            p.Add("p_Latitude", regInfo.Latitude, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("p_Longitude", regInfo.Longitude, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("p_FName", regInfo.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_LName", regInfo.Lname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Email", regInfo.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_PhoneNumber", regInfo.Phonenumber, dbType: DbType.Int32, direction: ParameterDirection.Input);

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
