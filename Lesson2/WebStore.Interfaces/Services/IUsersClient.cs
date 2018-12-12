using Microsoft.AspNetCore.Identity;
using WebStore.DomainModels.Entities.Classes;

namespace WebStore.Interfaces.Services
{
    public interface IUsersClient : 
        IUserClaimStore<User>,
        IUserPasswordStore<User>,
        IUserTwoFactorStore<User>,
        IUserEmailStore<User>,
        IUserPhoneNumberStore<User>,
        IUserLoginStore<User>,
        IUserLockoutStore<User>
    {
    }
}
