using WebStore.DomainModel.Entities.Classes.Base;
using WebStore.DomainModel.Entities.Interfaces;

namespace WebStore.DomainModel.Entities.Classes
{
    public class Section : NamedEntity, IOrderedEntity
    {
        public int? ParentId { get; set; }
        public int Order { get; set; }
    }
}