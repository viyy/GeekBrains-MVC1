using System.ComponentModel.DataAnnotations.Schema;
using WebStore.DomainModels.Entities.Classes.Base;
using WebStore.DomainModels.Interfaces;

namespace WebStore.DomainModels.Entities.Classes
{
    [Table("Products")]
    public class Product : NamedEntity, IOrderedEntity
    {
        /// <summary>
        ///     Секция, к которой принадлежит товар
        /// </summary>
        public int SectionId { get; set; }

        [ForeignKey("SectionId")]
        public virtual Section Section { get; set; }

        /// <summary>
        ///     Бренд товара
        /// </summary>
        public int? BrandId { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }

        /// <summary>
        ///     Ссылка на картинку
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        ///     Цена
        /// </summary>
        public decimal Price { get; set; }

        public int Order { get; set; }
    }
}