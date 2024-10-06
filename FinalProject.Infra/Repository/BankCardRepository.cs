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

        public void UpdateBalance(string cardNumber, decimal balance)
        {
            var p = new DynamicParameters();

            p.Add("p_cardNumber", cardNumber, dbType: DbType.String, direction: ParameterDirection.Input);

            p.Add("p_balance", balance, dbType: DbType.Decimal, direction: ParameterDirection.Input);


            _dbContext.Connection.Execute("BankCard_Package.UpdateBalance", p, commandType: CommandType.StoredProcedure);

        }

        public Bankcard ValidateBankCard(Bankcard bankcard)
        {


            var p = new DynamicParameters(); 

            p.Add("p_cardNumber", bankcard.Cardnumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_cardHolder", bankcard.Cardnumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_cardCVV", bankcard.Cardnumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_cardType", bankcard.Cardnumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_expiryDate", bankcard.Expirydate, dbType: DbType.DateTime, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Bankcard>("BankCard_Package.ValidateBankCard", p, commandType: CommandType.StoredProcedure);

            return result.SingleOrDefault();

        }
       
    }





}

