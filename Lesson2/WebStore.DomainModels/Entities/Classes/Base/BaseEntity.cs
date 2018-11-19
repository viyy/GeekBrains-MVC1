using WebStore.DomainModels.Entities.Interfaces;

namespace WebStore.DomainModels.Entities.Classes.Base
{
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
    }
}