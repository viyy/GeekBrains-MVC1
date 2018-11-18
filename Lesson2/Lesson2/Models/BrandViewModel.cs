using WebStore.DomainModel.Entities.Interfaces;

namespace WebStore.Models
{
    public class BrandViewModel : INamedEntity, IOrderedEntity, ICountableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public int Count { get; set; }
    }

}