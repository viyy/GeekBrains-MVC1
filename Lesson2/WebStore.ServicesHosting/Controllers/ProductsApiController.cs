using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.DomainModels.Dto;
using WebStore.DomainModels.Entities;
using WebStore.DomainModels.Entities.Classes;
using WebStore.DomainModels.Interfaces;

namespace WebStore.ServicesHosting.Controllers
{
    [Produces("application/json")]
    [Route("api/products")]
    public class ProductsApiController : Controller, IProductData
    {
        private readonly IProductData _productData;
        public ProductsApiController(IProductData productData)
        {
            _productData = productData;
        }
        [HttpGet("sections")]
        public IEnumerable<SectionDto> GetSections()
        {
            return _productData.GetSections();
        }

        [HttpGet("sections/{id}")]
        public Section GetSectionById(int id)
        {
            return _productData.GetSectionById(id);
        }
        [HttpGet("brands/{id}")]
        public Brand GetBrandById(int id)
        {
            return _productData.GetBrandById(id);
        }


        [HttpGet("brands")]
        public IEnumerable<BrandDto> GetBrands()
        {
            return _productData.GetBrands();
        }

        [HttpPost]
        [ActionName("Post")]
        public PagedProductDto GetProducts([FromBody]ProductFilter filter)
        {
            return _productData.GetProducts(filter);
        }
        [HttpGet("{id}"), ActionName("Get")]
        public ProductDto GetProductById(int id)
        {
            var product = _productData.GetProductById(id);
            return product;
        }
        [HttpPost("create")]
        public SaveResult CreateProduct([FromBody]ProductDto productDto)
        {
            var result = _productData.CreateProduct(productDto);
            return result;
        }
        [HttpPut]
        public SaveResult UpdateProduct([FromBody]ProductDto productDto)
        {
            var result = _productData.UpdateProduct(productDto);
            return result;
        }
        [HttpDelete("{productId}")]
        public SaveResult DeleteProduct(int productId)
        {
            var result = _productData.DeleteProduct(productId);
            return result;
        }

    }
}