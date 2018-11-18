using WebStore.DomainModel.Entities.Classes.Base;
using WebStore.DomainModel.Entities.Interfaces;

namespace WebStore.DomainModel.Entities.Classes
{
    public class Brand : NamedEntity, IOrderedEntity, ICountableEntity
    {
        public int Count { get; set; }
        public int Order { get; set; }
    }
}