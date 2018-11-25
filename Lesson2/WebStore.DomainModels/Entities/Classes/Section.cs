using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.DomainModels.Entities.Classes.Base;
using WebStore.DomainModels.Entities.Interfaces;

namespace WebStore.DomainModels.Entities.Classes
{
    [Table("Sections")]
    public class Section : NamedEntity, IOrderedEntity
    {
        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public virtual Section ParentSection { get; set; }

        public int Order { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}