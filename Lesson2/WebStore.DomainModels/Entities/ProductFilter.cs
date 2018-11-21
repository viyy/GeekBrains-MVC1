namespace WebStore.DomainModels.Entities
{
    public class ProductFilter
    {
        public int? SectionId { get; set; }

        /// <summary>
        ///     Бренд товара
        /// </summary>
        public int? BrandId { get; set; }
    }
}