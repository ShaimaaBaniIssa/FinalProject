using FinalProject.Core.Data;
using FinalProject.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankCardController : ControllerBase
    {
        private readonly IBankCardService _bankCardService;
        public BankCardController(IBankCardService bankCardService)
        {
            _bankCardService = bankCardService;
        }
        [HttpGet]
        public List<Bankcard> GetAllBankCards()
        {
            return _bankCardService.GetAllBankCards();
        }
        [HttpGet]
        [Route("GetBankCardById/{id}")]
        public Bankcard GetBankCardById(int id)
        {
            return _bankCardService.GetBankCardById(id);
        }
        [HttpPost]
        [Route("CreateBankCard")]
        public void CreateBankCard(Bankcard bankcard)
        {
            _bankCardService.CreateBankCard(bankcard);
        }
        [HttpPut]

        [Route("UpdateBankCard")]
        public void UpdateBankCard(Bankcard bankcard)
        {
            _bankCardService.UpdateBankCard(bankcard);
        }
        [HttpDelete]
        [Route("DeleteBankCard/{id}")]
        public void DeleteBankCard(int id)
        {
            _bankCardService.DeleteBankCard(id);
        }
    }
}
