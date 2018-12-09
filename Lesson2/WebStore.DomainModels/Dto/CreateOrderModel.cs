using System.Collections.Generic;
using WebStore.DomainModels.Models;

namespace WebStore.DomainModels.Dto
{
    public class CreateOrderModel
    {
        public OrderViewModel OrderViewModel { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}