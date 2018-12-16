namespace WebStore.DomainModels.Dto.User
{
    public class PasswordHashDto
    {
        public Entities.Classes.User User { get; set; }

        public string Hash { get; set; }
    }
}
