using System.Collections.Generic;
using WebStore.DomainModels.Dto;
using WebStore.DomainModels.Entities;
using WebStore.DomainModels.Entities.Classes;

namespace WebStore.DomainModels.Interfaces
{
    public interface IProductData
    {
        /* IEnumerable<SectionDto> GetSections();

         IEnumerable<BrandDto> GetBrands();

         /// <summary>
         ///     Список товаров
         /// </summary>
         /// <param name="filter">Фильтр товаров</param>
         /// <returns></returns>
         IEnumerable<ProductDto> GetProducts(ProductFilter filter);
         ProductDto GetProductById(int id);*/
        IEnumerable<SectionDto> GetSections();
        /// <summary>
        /// Секция по Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        Section GetSectionById(int id);
        /// <summary>
        /// Список брендов
        /// </summary>
        /// <returns></returns>
        IEnumerable<BrandDto> GetBrands();
        /// <summary>
        /// Бренд по Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        Brand GetBrandById(int id);
        /// <summary>
        /// Список товаров
        /// </summary>
        /// <param name="filter">Фильтр товаров</param>
        /// <returns></returns>
        PagedProductDto GetProducts(ProductFilter filter);
        /// <summary>
        /// Продукт
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Сущность Product, если нашел, иначе null</returns>
        ProductDto GetProductById(int id);
        /// <summary>
        /// Создать продукт
        /// </summary>
        /// <param name="product">Сущность Product</param>
        /// <returns></returns>
        SaveResult CreateProduct(ProductDto product);
        /// <summary>
        /// Обновить продукт
        /// </summary>
        /// <param name="product">Сущность Product</param>
        /// <returns></returns>
        SaveResult UpdateProduct(ProductDto product);
        /// <summary>
        /// Удалить продукт
        /// </summary>
        /// <param name="productId">Id продукта</param>
        /// <returns></returns>
        SaveResult DeleteProduct(int productId);

    }
}