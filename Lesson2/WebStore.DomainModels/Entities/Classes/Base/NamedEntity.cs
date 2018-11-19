using WebStore.DomainModels.Entities.Interfaces;

namespace WebStore.DomainModels.Entities.Classes.Base
{
    public class NamedEntity : INamedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}