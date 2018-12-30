﻿using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using WebStore.Clients.Base;
using WebStore.DomainModels.Dto;
using WebStore.DomainModels.Entities;
using WebStore.DomainModels.Entities.Classes;
using WebStore.DomainModels.Interfaces;

namespace WebStore.Clients
{
    public class ProductsClient : BaseClient, IProductData
    {
        public ProductsClient(IConfiguration configuration) :
            base(configuration)
        {
            ServiceAddress = "api/products";
        }
        protected sealed override string ServiceAddress { get; set; }
        public IEnumerable<SectionDto> GetSections()
        {
            var url = $"{ServiceAddress}/sections";
            var result = Get<List<SectionDto>>(url);
            return result;
        }

        public Section GetSectionById(int id)
        {
            var url = $"{ServiceAddress}/sections/{id}";
            var result = Get<Section>(url);
            return result;
        }
        public Brand GetBrandById(int id)
        {
            var url = $"{ServiceAddress}/brands/{id}";
            var result = Get<Brand>(url);
            return result;
        }


        public IEnumerable<BrandDto> GetBrands()
        {
            var url = $"{ServiceAddress}/brands";
            var result = Get<List<BrandDto>>(url);
            return result;
        }

        public PagedProductDto GetProducts(ProductFilter filter)
        {
            var url = $"{ServiceAddress}";
            var response = Post(url, filter);
            var result = response.Content.ReadAsAsync<PagedProductDto>().Result;
            return result;
        }
        public ProductDto GetProductById(int id)
        {
            var url = $"{ServiceAddress}/{id}";
            var result = Get<ProductDto>(url);
            return result;
        }
        public SaveResult CreateProduct(ProductDto productDto)
        {
            var url = $"{ServiceAddress}/create";
            var response = Post(url, productDto);
            var result = response.Content.ReadAsAsync<SaveResult>().Result;
            return result;
        }
        public SaveResult UpdateProduct(ProductDto productDto)
        {
            var url = $"{ServiceAddress}";
            var response = Put(url, productDto);
            var result = response.Content.ReadAsAsync<SaveResult>().Result;
            return result;
        }
        public SaveResult DeleteProduct(int productId)
        {
            var url = $"{ServiceAddress}/{productId}";
            var response = DeleteAsync(url).Result;
            var result = response.Content.ReadAsAsync<SaveResult>().Result;
            return result;
        }
    }
}