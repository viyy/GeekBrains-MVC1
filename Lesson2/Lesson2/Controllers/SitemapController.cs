using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleMvcSitemap;
using WebStore.DomainModels.Entities;
using WebStore.DomainModels.Interfaces;

namespace WebStore.Controllers
{
    public class SitemapController : Controller
    {
        private readonly IProductData _productData;
        public SitemapController(IProductData productData)
        {
            _productData = productData;
        }
        public IActionResult Index()
        {
            var nodes = new List<SitemapNode>
            {
                new SitemapNode(Url.Action("Index","Home")),
                new SitemapNode(Url.Action("Shop","Catalog")),
                new SitemapNode(Url.Action("BlogSingle","Home")),
                new SitemapNode(Url.Action("Blog","Home")),
                new SitemapNode(Url.Action("ContactUs","Home"))
            };
            var sections = _productData.GetSections();
            nodes.AddRange(from section in sections where section.ParentId.HasValue select new SitemapNode(Url.Action("Shop", "Catalog", new {sectionId = section.Id})));
            var brands = _productData.GetBrands();
            nodes.AddRange(brands.Select(brand => new SitemapNode(Url.Action("Shop", "Catalog", new {brandId = brand.Id}))));
            /*var products = _productData.GetProducts(new ProductFilter());
            nodes.AddRange(products.Select(productDto => new SitemapNode(Url.Action("Details", "Catalog", new {id = productDto.Id}))));*/
            return new SitemapProvider().CreateSitemap(new SitemapModel(nodes));
        }
    }
}