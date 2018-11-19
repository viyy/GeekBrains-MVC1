using WebStore.DomainModels.Entities.Classes.Base;
using WebStore.DomainModels.Entities.Interfaces;

namespace WebStore.DomainModels.Entities.Classes
{
    public class Brand : NamedEntity, IOrderedEntity, ICountableEntity
    {
        public int Count { get; set; }
        public int Order { get; set; }
    }
}