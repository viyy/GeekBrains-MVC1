using WebStore.DomainModels.Entities.Classes.Base;
using WebStore.DomainModels.Entities.Interfaces;

namespace WebStore.DomainModels.Entities.Classes
{
    public class Product : NamedEntity, IOrderedEntity
    {
        /// <summary>
        ///     Секция, к которой принадлежит товар
        /// </summary>
        public int SectionId { get; set; }

        /// <summary>
        ///     Бренд товара
        /// </summary>
        public int? BrandId { get; set; }

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