using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using FinalProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infra.Services
{
    public class BankCardService: IBankCardService
    {
        private readonly IBankCardRepository _bankCardRepository;
        public BankCardService(IBankCardRepository bankCardRepository)
        {
            _bankCardRepository = bankCardRepository;
        }
        public List<Bankcard> GetAllBankCards()
        {
            return _bankCardRepository.GetAllBankCards();
        }
        public Bankcard GetBankCardById(int id)
        {
            return _bankCardRepository.GetBankCardById(id);
        }
        public void CreateBankCard(Bankcard bankcard)
        {
            _bankCardRepository.CreateBankCard(bankcard);
        }
        public void UpdateBankCard(Bankcard bankcard)
        {
            _bankCardRepository.UpdateBankCard(bankcard);
        }
        public void DeleteBankCard(int id)
        {
            _bankCardRepository.DeleteBankCard(id);
        }


    }


}

