using System.Collections.Generic;
using WebStore.DomainModels.Entities.Classes;
using WebStore.DomainModels.Models;

namespace WebStore.Interfaces.Services
{
    public interface IOrderService
    {
            IEnumerable<Order> GetUserOrders(string userName);

            Order GetOrderById(int id);

            Order CreateOrder(OrderViewModel orderModel, CartViewModel transformCart, string userName);

    }
}