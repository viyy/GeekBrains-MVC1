using System;
using System.Collections.Generic;
using WebStore.DomainModels.Entities.Classes.Base;

namespace WebStore.DomainModels.Dto
{
    public class OrderDto : NamedEntity
    {
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<OrderItemDto> OrderItems { get; set; }
    }
}