using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebStore.DomainModels;
using WebStore.DomainModels.Entities.Classes;
using WebStore.DomainModels.Interfaces;
using WebStore.DomainModels.Models;

namespace WebStore.Components
{
    public class SectionsViewComponent : ViewComponent
    {
        private readonly IProductData _productData;

        public SectionsViewComponent(IProductData productData)
        {
            _productData = productData;
        }

        public IViewComponentResult Invoke()
        {
            var sections = GetSections();
            return View(sections);
        }

        private List<SectionViewModel> GetSections()
        {
            var categories = _productData.GetSections();
            var parentCategories = Enumerable.Where<Section>(categories, p => !p.ParentId.HasValue).ToArray();
            var parentSections = parentCategories.Select(parentCategory => new SectionViewModel
                {
                    Id = parentCategory.Id,
                    Name = parentCategory.Name,
                    Order = parentCategory.Order,
                    ParentSection = null
                })
                .ToList();
            foreach (var sectionViewModel in parentSections)
            {
                var childCategories = Enumerable.Where<Section>(categories, c => c.ParentId.Equals(sectionViewModel.Id));
                foreach (var childCategory in childCategories)
                    sectionViewModel.ChildSections.Add(new SectionViewModel
                    {
                        Id = childCategory.Id,
                        Name = childCategory.Name,
                        Order = childCategory.Order,
                        ParentSection = sectionViewModel
                    });
                sectionViewModel.ChildSections = sectionViewModel.ChildSections.OrderBy(c => c.Order).ToList();
            }
            parentSections = parentSections.OrderBy(c => c.Order).ToList();
            return parentSections;
        }
    }
}