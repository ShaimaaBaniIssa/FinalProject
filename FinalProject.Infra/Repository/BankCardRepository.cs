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
    public class BankCardRepository: IBankCardRepository
    {
        private readonly IDbContext _dbContext;
        public BankCardRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Bankcard> GetAllBankCards()
        {

            //query == reterive data from db 

            IEnumerable<Bankcard> result = _dbContext.Connection.Query<Bankcard>("BankCard_Package.GetAllBankCards", commandType: CommandType.StoredProcedure);

            return result.ToList();

        }
        public Bankcard GetBankCardById(int id)

        {

            //dapper

            var p = new DynamicParameters(); // pass data to database (stored proc.)

            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Bankcard>("BankCard_Package.GetBankCardById", p, commandType: CommandType.StoredProcedure);

            return result.SingleOrDefault();

        }
        public void CreateBankCard(Bankcard bankcard)

        {

            var p = new DynamicParameters();

            p.Add("p_CardNumber", bankcard.Cardnumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_CVV", bankcard.Cvv, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_ExpiryDate", bankcard.Expirydate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("p_CardHolderName", bankcard.Cardholdername, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Balance", bankcard.Balance, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_CardType", bankcard.Cardtype, dbType: DbType.String, direction: ParameterDirection.Input);



            _dbContext.Connection.Execute("BankCard_Package.CreateBankCard", p, commandType: CommandType.StoredProcedure);


        }
        public void UpdateBankCard(Bankcard bankcard)

        {

            var p = new DynamicParameters();

            p.Add("p_CardNumber", bankcard.Cardnumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_CVV", bankcard.Cvv, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_ExpiryDate", bankcard.Expirydate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("p_CardHolderName", bankcard.Cardholdername, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Balance", bankcard.Balance, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_CardType", bankcard.Cardtype, dbType: DbType.String, direction: ParameterDirection.Input);



            _dbContext.Connection.Execute("BankCard_Package.UpdateBankCard", p, commandType: CommandType.StoredProcedure);
        }
        public void DeleteBankCard(int id)

        {

            var p = new DynamicParameters();

            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("Reservation_Package.DeleteBankCard", p, commandType: CommandType.StoredProcedure);

        }
    }





}

