using WebStore.DomainModel.Entities.Interfaces;

namespace WebStore.DomainModel.Entities.Classes.Base
{
    public class NamedEntity : INamedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}