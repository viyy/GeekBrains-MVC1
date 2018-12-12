using WebStore.DomainModels.Entities.Classes.Base;
using WebStore.DomainModels.Interfaces;

namespace WebStore.DomainModels.Dto
{
    public class SectionDto : NamedEntity, IOrderedEntity
    {
        public int? ParentId { get; set; }
        public int Order { get; set; }
    }
}
