using Microsoft.AspNetCore.Identity;
using WebStore.DomainModels.Entities.Classes;

namespace WebStore.Interfaces.Services
{
    public interface IUserStoreClient : IUserStore<User>
    {
    }
}
