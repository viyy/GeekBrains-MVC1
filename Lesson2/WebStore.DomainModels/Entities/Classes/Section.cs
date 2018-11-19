using WebStore.DomainModels.Entities.Classes.Base;
using WebStore.DomainModels.Entities.Interfaces;

namespace WebStore.DomainModels.Entities.Classes
{
    public class Section : NamedEntity, IOrderedEntity
    {
        public int? ParentId { get; set; }
        public int Order { get; set; }
    }
}