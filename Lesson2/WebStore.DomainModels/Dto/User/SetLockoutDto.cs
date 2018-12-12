using System;

namespace WebStore.DomainModels.Dto.User
{
    public class SetLockoutDto
    {
        public Entities.Classes.User User { get; set; }

        public DateTimeOffset? LockoutEnd { get; set; }
    }
}
