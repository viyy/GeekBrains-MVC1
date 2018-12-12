using WebStore.DomainModels.Entities.Classes.Base;

namespace WebStore.DomainModels.Dto
{
    public class OrderItemDto : BaseEntity
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}
