using FinalProject.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Repository
{
    public interface IBankCardRepository
    {
        Bankcard ValidateBankCard(Bankcard bankcard);
        void UpdateBalance(string cardNumber, decimal balance);




    }
}
