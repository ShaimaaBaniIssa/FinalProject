using FinalProject.Core.Data;
using FinalProject.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet]
        public List<Role> GetAllRoles()
        {
            return _roleService.GetAllRoles();
        }
        [HttpGet]
        [Route("GetRoleById/{id}")]
        public Role GetRoleById(int id)
        {
            return _roleService.GetRoleById(id);
        }
        [HttpPost]
        [Route("CreateRole")]
        public void CreateRole(Role role)
        {
            _roleService.CreateRole(role);
        }
        [HttpPut]

        [Route("UpdateRole")]
        public void UpdateRole(Role role)
        {
            _roleService.UpdateRole(role);
        }
        [HttpDelete]
        [Route("DeleteRole/{id}")]
        public void DeleteRole(int id)
        {
            _roleService.DeleteRole(id);
        }


    }
}
