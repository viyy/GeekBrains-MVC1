using WebStore.DomainModels.Entities.Classes.Base;
using WebStore.DomainModels.Interfaces;

namespace WebStore.DomainModels.Dto
{
    public class BrandDto : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
    }
}