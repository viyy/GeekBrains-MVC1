using System.Collections.Generic;
using WebStore.DomainModels.Dto;
using WebStore.DomainModels.Entities;
using WebStore.DomainModels.Entities.Classes;

namespace WebStore.DomainModels.Interfaces
{
    public interface IProductData
    {
        IEnumerable<SectionDto> GetSections();

        IEnumerable<BrandDto> GetBrands();

        /// <summary>
        ///     Список товаров
        /// </summary>
        /// <param name="filter">Фильтр товаров</param>
        /// <returns></returns>
        IEnumerable<ProductDto> GetProducts(ProductFilter filter);
        ProductDto GetProductById(int id);
    }
}