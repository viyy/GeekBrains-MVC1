using System.Collections.Generic;
using WebStore.DomainModel.Entities.Classes;

namespace WebStore.DomainModel.DataServices.Interfaces
{
    public interface IProductData
    {
        IEnumerable<Section> GetSections();

        IEnumerable<Brand> GetBrands();
    }
}