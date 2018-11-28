using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using WebStore.DomainModels.Entities.Classes;

namespace WebStore.Infrastructure
{
    [HtmlTargetElement("access")]
    public class AccessTagHelper : TagHelper
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _accessor;

        public string Roles { get; set; }
        public string ToTag { get; set; }

        public AccessTagHelper(UserManager<User> userManager, IHttpContextAccessor accessor)
        {
            _userManager = userManager;
            _accessor = accessor;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var user = _userManager.GetUserAsync(_accessor.HttpContext.User);
            var roles = _userManager.GetRolesAsync(user.Result);
            var tagRoles = Roles.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim());
            if (!roles.Result.Any(r => tagRoles.Contains(r)))
            {
                output.Content.SetContent("");
                output.TagName = "";
            }
            output.TagName = ToTag;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var user = await _userManager.GetUserAsync(_accessor.HttpContext.User);
            var roles = await _userManager.GetRolesAsync(user);
            var tagRoles = Roles.Split(',',StringSplitOptions.RemoveEmptyEntries).Select(s=>s.Trim());
            if (!roles.Any(r => tagRoles.Contains(r)))
            {
                output.Content.SetContent("");
                output.TagName = "";
            }
            output.TagName = ToTag;

        }
    }
}