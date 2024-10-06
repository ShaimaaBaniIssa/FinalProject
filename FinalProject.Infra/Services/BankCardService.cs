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

        public Bankcard ValidateBankCard(Bankcard bankcard)
        {
            return _bankCardRepository.ValidateBankCard(bankcard);
        }

        public void UpdateBalance(string cardNumber, decimal balance)
        {
            _bankCardRepository.UpdateBalance(cardNumber, balance);
        }
        public bool Pay(Bankcard bankcard, decimal price, int reservationId)
        {
            var card = ValidateBankCard(bankcard);
            if (card == null) return false;
            if (card.Balance < price) return false;
            card.Balance -= price;
            UpdateBalance(card.Cardnumber, card.Balance.Value);
            return true;




        }
    }


}

