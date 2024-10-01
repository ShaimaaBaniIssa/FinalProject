using FinalProject.Core.Data;
using FinalProject.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController  (ILoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpGet]
        public List<Login> GetAllLogins()
        {
            return _loginService.GetAllLogins();
        }
        [HttpGet]
        [Route("GetLoginById/{id}")]
        public Login GetLoginById(int id)
        {
            return _loginService.GetLoginById(id);
        }
        [HttpPost]
        [Route("CreateLogin")]
        public void CreateLogin(Login login)
        {
            _loginService.CreateLogin(login);
        }
        [HttpPut]

        [Route("UpdateLogin")]
        public void UpdateLogin(Login login)
        {
            _loginService.UpdateLogin(login);
        }
        [HttpDelete]
        [Route("DeleteLogin/{id}")]
        public void DeleteLogin(int id)
        {
            _loginService.DeleteLogin(id);
        }
    }
}
