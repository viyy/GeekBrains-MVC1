using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebStore.DomainModels;
using WebStore.DomainModels.Entities;
using WebStore.DomainModels.Interfaces;
using WebStore.DomainModels.Models;

namespace WebStore.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductData _productData;
        private readonly IConfiguration _configuration;
        public CatalogController(IProductData productData, IConfiguration
            configuration)
        {
            _productData = productData;
            _configuration = configuration;
        }
        public IActionResult Shop(int? sectionId, int? brandId, int page = 1)
        {
            var productsModel = GetProducts(sectionId, brandId, page, out var
                totalCount);
            var model = new CatalogViewModel()
            {
                BrandId = brandId,
                SectionId = sectionId,
                Products = productsModel,
                PageViewModel = new PageViewModel
                {
                    PageSize = int.Parse(_configuration["PageSize"]),
                    PageNumber = page,
                    TotalItems = totalCount
                }
            };
            return View(model);
        }
        public IActionResult GetFilteredItems(int? sectionId, int? brandId, int page = 1)
        {
            var productsModel = GetProducts(sectionId, brandId, page, out var totalCount);
            return PartialView("Shop/ShopItems", productsModel);
        }
        private IEnumerable<ProductViewModel> GetProducts(int? sectionId, int?
            brandId, int page, out int totalCount)
        {
            var products = _productData.GetProducts(new ProductFilter
            {
                BrandId = brandId,
                SectionId = sectionId,
                Page = page,
                PageSize = int.Parse(_configuration["PageSize"])
            });
            totalCount = products.TotalCount;
            return products.Products.Select(p => new ProductViewModel()
            {
                Id = p.Id,
                ImageUrl = p.ImageUrl,
                Name = p.Name,
                Order = p.Order,
                Price = p.Price,
                Brand = p.Brand != null ? p.Brand.Name : string.Empty
            }).ToList();
        }
        public IActionResult Details(int id)
        {
            var product = _productData.GetProductById(id);
            if (product == null)
                return NotFound();
            return View(new ProductViewModel
            {
                Id = product.Id,
                ImageUrl = product.ImageUrl,
                Name = product.Name,
                Order = product.Order,
                Price = product.Price,
                Brand = product.Brand != null ? product.Brand.Name :
                    string.Empty
            });
        }
    }

}