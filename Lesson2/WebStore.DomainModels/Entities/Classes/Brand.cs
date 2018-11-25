using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.DomainModels.Entities.Classes.Base;
using WebStore.DomainModels.Entities.Interfaces;

namespace WebStore.DomainModels.Entities.Classes
{
    [Table("Brands")]
    public class Brand : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}