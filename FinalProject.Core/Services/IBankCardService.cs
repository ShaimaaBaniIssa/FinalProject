using FinalProject.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Services
{
    public interface IBankCardService
    {
        List<Bankcard> GetAllBankCards();
        Bankcard GetBankCardById(int id);
        void CreateBankCard(Bankcard bankcard);
        void UpdateBankCard(Bankcard bankcard);
        void DeleteBankCard(int id);
    }
}
