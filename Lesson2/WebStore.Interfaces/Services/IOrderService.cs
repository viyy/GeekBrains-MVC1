using System.Collections.Generic;
using WebStore.DomainModels.Dto;
using WebStore.DomainModels.Entities.Classes;
using WebStore.DomainModels.Models;

namespace WebStore.Interfaces.Services
{
    public interface IOrderService
    {
        IEnumerable<OrderDto> GetUserOrders(string userName);
        OrderDto GetOrderById(int id);
        OrderDto CreateOrder(CreateOrderModel orderModel, string userName);

    }
}