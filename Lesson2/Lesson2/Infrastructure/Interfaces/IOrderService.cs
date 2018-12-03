using System.Collections.Generic;
using WebStore.DomainModels.Entities.Classes;
using WebStore.Models;

namespace WebStore.Infrastructure.Interfaces
{
    public interface IOrderService
    {
            IEnumerable<Order> GetUserOrders(string userName);

            Order GetOrderById(int id);

            Order CreateOrder(OrderViewModel orderModel, CartViewModel transformCart, string userName);

    }
}