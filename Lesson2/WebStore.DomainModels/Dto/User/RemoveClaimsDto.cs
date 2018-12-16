using System.Collections.Generic;
using System.Security.Claims;

namespace WebStore.DomainModels.Dto.User
{
    public class RemoveClaimsDto
    {
        public Entities.Classes.User User { get; set; }

        public IEnumerable<Claim> Claims { get; set; }
    }

}
