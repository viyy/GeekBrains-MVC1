using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebStore.DomainModels.DataServices.Interfaces;
using WebStore.Models;

namespace WebStore.Components
{
    public class BrandsViewComponent : ViewComponent
    {
        private readonly IProductData _productData;

        public BrandsViewComponent(IProductData productData)
        {
            _productData = productData;
        }

        public IViewComponentResult Invoke()
        {
            var brands = GetBrands();
            return View(brands);
        }

        private IEnumerable<BrandViewModel> GetBrands()
        {
            var dbBrands = _productData.GetBrands();
            return Enumerable.Select(dbBrands, b => new BrandViewModel
            {
                Id = b.Id,
                Name = b.Name,
                Order = b.Order,
                Count = b.Products.Count
            }).OrderBy(b => b.Order).ToList();
        }
    }
}