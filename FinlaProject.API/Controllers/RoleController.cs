using FinalProject.Core.Data;
using FinalProject.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet]
        [CheckClaims("roleid", "21")]
        public List<Role> GetAllRoles()
        {
            return _roleService.GetAllRoles();
        }
        [HttpGet]
        [Route("GetRoleById/{id}")]
        [CheckClaims("roleid", "21")]

        public Role GetRoleById(int id)
        {
            return _roleService.GetRoleById(id);
        }
        [HttpPost]
        [Route("CreateRole")]
        [CheckClaims("roleid", "21")]

        public void CreateRole(Role role)
        {
            _roleService.CreateRole(role);
        }
        [HttpPut]

        [Route("UpdateRole")]
        [CheckClaims("roleid", "21")]

        public void UpdateRole(Role role)
        {
            _roleService.UpdateRole(role);
        }
        [HttpDelete]
        [Route("DeleteRole/{id}")]
        [CheckClaims("roleid", "21")]

        public void DeleteRole(int id)
        {
            _roleService.DeleteRole(id);
        }


    }
}
