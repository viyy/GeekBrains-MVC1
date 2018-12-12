using System.Security.Claims;

namespace WebStore.DomainModels.Dto.User
{
    public class ReplaceClaimsDto
    {
        public Entities.Classes.User User { get; set; }

        public Claim Claim { get; set; }

        public Claim NewClaim { get; set; }
    }

}
