using FinalProject.Core.Data;
using FinalProject.Core.DTO;
using FinalProject.Core.Repository;
using FinalProject.Core.Services;
using FinalProject.Infra.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infra.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService (ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public List<Login> GetAllLogins()
        {
            return _loginRepository.GetAllLogins();
        }
        public Login GetLoginById(int id)
        {
            return _loginRepository.GetLoginById(id);
        }
        public void CreateLogin(Login login)
        {
            _loginRepository.CreateLogin(login);
        }
        public void UpdateLogin(Login login)
        {
            _loginRepository.UpdateLogin(login);
        }
        public void DeleteLogin(int id)
        {
            _loginRepository.DeleteLogin(id);
        }

        public string Auth(Login login)
        {
            var result = _loginRepository.Auth(login);//username + roleid if matching or null if no match

            if (result == null)
            {
                return null;
            }
            else
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecretKey@FinalProject123456"));// at least 256 bit 32byte 
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>
             {
             new Claim(ClaimTypes.Name, result.Username),
             new Claim(ClaimTypes.Role, result.Roleid.ToString())
             };

                var tokeOptions = new JwtSecurityToken(
                                claims: claims,
                                expires: DateTime.Now.AddHours(24),
                                signingCredentials: signinCredentials
                        );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return tokenString;

            }
        }
        public List<UserCountDTO> CountCustomer(UserCountDTO userCountDTO)
        {
            return _loginRepository.CountCustomer(userCountDTO);
        }



    }
}
