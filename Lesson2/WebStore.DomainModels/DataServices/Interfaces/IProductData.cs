using System.Collections.Generic;
using WebStore.DomainModels.Entities;
using WebStore.DomainModels.Entities.Classes;

namespace WebStore.DomainModels.DataServices.Interfaces
{
    public interface IProductData
    {
        IEnumerable<Section> GetSections();

        IEnumerable<Brand> GetBrands();

        /// <summary>
        ///     Список товаров
        /// </summary>
        /// <param name="filter">Фильтр товаров</param>
        /// <returns></returns>
        IEnumerable<Product> GetProducts(ProductFilter filter);
    }
}