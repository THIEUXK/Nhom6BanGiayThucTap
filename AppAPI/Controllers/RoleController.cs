
using AppAPI.Services;
using MCV.Models;
using MCV.Models.DBnhom6;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOganicAPI.IServices;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
       private readonly IAllServices<Role> services;

        public RoleController()
        {
            services = new AllServices<Role>();
        }

        [HttpGet("get-all-role")]
        public async Task<IActionResult> GetAllRole()
        {
            var lstRole = await services.GetAllAsync();
            if (lstRole == null)
            {
                return NotFound();
            }
            return Ok(lstRole);
        }

        [HttpGet("get-role-{id}")]
        public async Task<IActionResult> GetRole(Guid id)
        {
            var role = await services.GetByIdAsync(id);
            if (role == null)
            {
                return BadRequest();
            }
            return Ok(role);
        }

        [HttpPost("create-role")]
        public async Task<bool> CreateRole(Role role)
        {
            return await services.CreateAsync(role);
        }
        [HttpPost("update-role")]
        public async Task<bool> UpdateRole(Role role)
        {
            return await services.UpdateAsync(role);
        }
        [HttpDelete("delete-role-{id}")]
        public async Task<bool> DeleteRole(Guid id)
        {
            return await services.DeleteAsync(id);
        }
    }
}
