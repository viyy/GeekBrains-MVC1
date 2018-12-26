using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebStore.DomainModels;
using WebStore.DomainModels.Dto;
using WebStore.DomainModels.Entities;
using WebStore.DomainModels.Entities.Classes;
using WebStore.DomainModels.Interfaces;

namespace WebStore.DAL
{
    public class ProductData : IProductData
    {
        private readonly WebStoreContext _context;

        public ProductData(WebStoreContext context)
        {
            _context = context;
        }

        public IEnumerable<SectionDto> GetSections()
        {
            return _context.Sections.Select(c => new SectionDto()
            {
                Id = c.Id,
                Name = c.Name,
                Order = c.Order,
                ParentId = c.ParentId
            }).ToList();
        }

        public Section GetSectionById(int id)
        {
            return _context.Sections.FirstOrDefault(s => s.Id == id);
        }
        public Brand GetBrandById(int id)
        {
            return _context.Brands.FirstOrDefault(s => s.Id == id);
        }


        public IEnumerable<BrandDto> GetBrands()
        {
            return _context.Brands.Select(b => new BrandDto()
            {
                Id = b.Id,
                Name = b.Name,
                Order = b.Order
            }).ToList();
        }

        public IEnumerable<ProductDto> GetProducts(ProductFilter filter)
        {
            var query =
                _context.Products.Include("Brand").Include("Section").AsQueryable();
            if (filter.BrandId.HasValue)
                query = query.Where(c => c.BrandId.HasValue &&
                                         c.BrandId.Value.Equals(filter.BrandId.Value));
            if (filter.SectionId.HasValue)
                query = query.Where(c =>
                    c.SectionId.Equals(filter.SectionId.Value));
            return query.Select(p => new ProductDto()
            {
                Id = p.Id,
                Name = p.Name,
                Order = p.Order,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                Brand = p.BrandId.HasValue ? new BrandDto()
                {
                    Id = p.Brand.Id,
                    Name = p.Brand.Name
                } : null,
                Section = new SectionDto()
                {
                    Id = p.SectionId,
                    Name =
                        p.Section.Name
                }
            }).ToList();

        }

        public ProductDto GetProductById(int id)
        {
            var product =
                    _context.Products.Include("Brand").Include("Section").FirstOrDefault(p =>
                        p.Id.Equals(id));
            if (product == null) return null;
            var dto = new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                ImageUrl = product.ImageUrl,
                Order = product.Order,
                Price = product.Price,
                Section = new SectionDto()
                {
                    Id = product.SectionId,
                    Name =
                        product.Section.Name
                }
            };
            if (product.Brand != null)
                dto.Brand = new BrandDto()
                {
                    Id = product.Brand.Id,
                    Name = product.Brand.Name
                };
            return dto;
        }

    }
}