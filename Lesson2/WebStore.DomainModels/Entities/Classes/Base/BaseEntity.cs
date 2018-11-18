using WebStore.DomainModel.Entities.Interfaces;

namespace WebStore.DomainModel.Entities.Classes.Base
{
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
    }
}