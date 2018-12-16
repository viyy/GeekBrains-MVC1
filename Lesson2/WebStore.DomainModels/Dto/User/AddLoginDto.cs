using Microsoft.AspNetCore.Identity;

namespace WebStore.DomainModels.Dto.User
{
    public class AddLoginDto
    {
        public Entities.Classes.User User { get; set; }

        public UserLoginInfo UserLoginInfo { get; set; }

    }
}
