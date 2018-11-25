﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebStore.DomainModels.DataServices.Interfaces;
using WebStore.DomainModels.Entities;
using WebStore.DomainModels.Entities.Classes;

namespace WebStore.DAL
{
    public class ProductData : IProductData
    {
        private readonly WebStoreContext _context;

        public ProductData(WebStoreContext context)
        {
            _context = context;
        }

        public IEnumerable<Section> GetSections()
        {
            return _context.Sections.ToList();
        }

        public IEnumerable<Brand> GetBrands()
        {
            _context.Brands.Load();
            return _context.Brands.Include(brand => brand.Products).ToList();
        }

        public IEnumerable<Product> GetProducts(ProductFilter filter)
        {
            var query = _context.Products.AsQueryable();
            if (filter.BrandId.HasValue)
                query = query.Where(c => c.BrandId.HasValue && c.BrandId.Value.Equals(filter.BrandId.Value));
            if (filter.SectionId.HasValue)
                query = query.Where(c => c.SectionId.Equals(filter.SectionId.Value));
            return query.ToList();
        }
    }
}