using FinalProject.Core.Data;
using FinalProject.Core.DTO;
using FinalProject.Core.Services;
using FinalProject.Infra.Repository;
using FinalProject.Infra.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using System.Diagnostics;

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
        [CheckClaims("roleid", "21")]
        [Authorize]
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
        [CheckClaims("roleid", "21")]
        [Authorize]
        public void UpdateLogin(Login login)
        {
            _loginService.UpdateLogin(login);
        }
        [HttpDelete]
        [Route("DeleteLogin/{id}")]
        [CheckClaims("roleid", "21")]
        [Authorize]
        public void DeleteLogin(int id)
        {
            _loginService.DeleteLogin(id);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Auth(Login login)
        {
            try
            {
                var token = _loginService.Auth(login);
                if (token == null)
                {
                    return Unauthorized();
                }
                else
                {
                    return Ok(token);
                }
            }
            catch (Exception e)
            {
                return BadRequest("invaild username/password");
            }
          

        }
        [HttpGet]
        [Route("CountUser")]
        [CheckClaims("roleid", "21")]
        [Authorize]
        public int CountUser()
        {
            return _loginService.CountUser();
        }
        [HttpPost]
        [Route("Registration")]
        public IActionResult Registration(Registration regInfo)
        {
            try
            {
                // Call your registration code here, e.g., insert into database
                _loginService.Registration(regInfo);
                return Ok();
            }
            catch (OracleException ex) when (ex.Number == 1) // ORA-00001
            {
                
                return BadRequest("User name is already taken !");
               
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                return BadRequest($"An error occurred: {ex.Message}");
            }

        }
    }
}
