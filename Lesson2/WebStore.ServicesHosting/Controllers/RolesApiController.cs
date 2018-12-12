using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WebStore.DAL;

namespace WebStore.ServicesHosting.Controllers
{
    [Produces("application/json")]
    [Route("api/roles")]
    public class RolesApiController : Controller
    {
        private readonly RoleStore<IdentityRole> _roleStore;
        public RolesApiController(WebStoreContext context) => _roleStore = new RoleStore<IdentityRole>(context);

        [HttpPost]
        public async Task<bool> CreateAsync(IdentityRole role) => (await _roleStore.CreateAsync(role)).Succeeded;

        [HttpPut]
        public async Task<bool> UpdateAsync(IdentityRole role) => (await _roleStore.UpdateAsync(role)).Succeeded;

        [HttpPost("delete")]
        public async Task<bool> DeleteAsync(IdentityRole role) => (await _roleStore.DeleteAsync(role)).Succeeded;

        [HttpPost("GetRoleId")]
        public async Task<string> GetRoleIdAsync(IdentityRole role) => await _roleStore.GetRoleIdAsync(role);

        [HttpPost("GetRoleName")]
        public async Task<string> GetRoleNameAsync(IdentityRole role) => await _roleStore.GetRoleNameAsync(role);

        [HttpPost("SetRoleName/{roleName}")]
        public Task SetRoleNameAsync(IdentityRole role, string roleName) => _roleStore.SetRoleNameAsync(role, roleName);

        [HttpPost("GetNormalizedRoleName")]
        public async Task<string> GetNormalizedRoleNameAsync(IdentityRole role) => await _roleStore.GetRoleNameAsync(role);

        [HttpPost("SetNormalizedRoleName/{normalizedName}")]
        public Task SetNormalizedRoleNameAsync(IdentityRole role, string normalizedName) => _roleStore.SetNormalizedRoleNameAsync(role, normalizedName);

        [HttpGet("FindById/{roleId}")]
        public async Task<IdentityRole> FindByIdAsync(string roleId) => await _roleStore.FindByIdAsync(roleId);

        [HttpGet("FindByName/{normalizedRoleName}")]
        public async Task<IdentityRole> FindByNameAsync(string normalizedRoleName) => await _roleStore.FindByNameAsync(normalizedRoleName);
    }
}