using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.DomainModels.Interfaces;
using WebStore.DomainModels.Models;

namespace WebStore.Components
{
    public class BreadcrumbsViewComponent : ViewComponent
    {
        private readonly IProductData _productData;
        public BreadcrumbsViewComponent(IProductData productData)
        {
            _productData = productData;
        }
        public async Task<IViewComponentResult> InvokeAsync(BreadcrumbType type,
            int id, BreadcrumbType fromType)
        {
            if (!Enum.IsDefined(typeof(BreadcrumbType), type))
                throw new InvalidEnumArgumentException(nameof(type), (int)type,
                    typeof(BreadcrumbType));
            if (!Enum.IsDefined(typeof(BreadcrumbType), fromType))
                throw new InvalidEnumArgumentException(nameof(fromType),
                    (int)fromType, typeof(BreadcrumbType));
            switch (type)
            {
                case BreadcrumbType.Section:
                    var section = _productData.GetSectionById(id);
                    return View(new List<BreadcrumbViewModel>()
                    {
                        new BreadcrumbViewModel()
                        {
                            BreadCrumbType = type,
                            Id = id.ToString(),
                            Name = section.Name
                        }
                    });
                case BreadcrumbType.Brand:
                    var brand = _productData.GetBrandById(id);
                    return View(new List<BreadcrumbViewModel>()
                    {
                        new BreadcrumbViewModel()
                        {
                            BreadCrumbType = type,
                            Id = id.ToString(),
                            Name = brand.Name
                        }
                    });
                case BreadcrumbType.Item:
                    var crumbs = GetItemBreadcrumbs(id, fromType, type);
                    return View(crumbs);
                case BreadcrumbType.None:
                default:
                    return View(new List<BreadcrumbViewModel>());
            }
        }
        private IEnumerable<BreadcrumbViewModel> GetItemBreadcrumbs(int id,
            BreadcrumbType fromType, BreadcrumbType type)
        {
            var item = _productData.GetProductById(id);
            var crumbs = new List<BreadcrumbViewModel>();
            if (fromType == BreadcrumbType.Section)
                crumbs.Add(new BreadcrumbViewModel()
                {
                    BreadCrumbType = fromType,
                    Id = item.Section.Id.ToString(),
                    Name = item.Section.Name
                });
            else
                crumbs.Add(new BreadcrumbViewModel()
                {
                    BreadCrumbType = fromType,
                    Id = item.Brand.Id.ToString(),
                    Name = item.Brand.Name
                });
            crumbs.Add(new BreadcrumbViewModel()
            {
                BreadCrumbType = type,
                Id = item.Id.ToString(),
                Name = item.Name
            });
            return crumbs;
        }


    }
}