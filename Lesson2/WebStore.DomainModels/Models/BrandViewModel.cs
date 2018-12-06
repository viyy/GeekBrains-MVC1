using WebStore.DomainModels.Interfaces;

namespace WebStore.DomainModels.Models
{
    public class BrandViewModel : INamedEntity, IOrderedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public int Count { get; set; }
    }
}