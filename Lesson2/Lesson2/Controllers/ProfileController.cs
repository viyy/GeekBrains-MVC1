using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.DomainModels.Entities.Classes;
using WebStore.DomainModels.Models;
using WebStore.Interfaces.Services;

namespace WebStore.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IOrderService _ordersService;

        public ProfileController(IOrderService ordersService)
        {
            _ordersService = ordersService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Orders()
        {
            var orders = _ordersService.GetUserOrders(User.Identity.Name).ToList();
            var orderModels = new List<UserOrderViewModel>(orders.Count);
            orderModels.AddRange(orders.Select(order => new UserOrderViewModel
            {
                Id = order.Id,
                Name = order.Name,
                Address = order.Address,
                Phone = order.Phone,
                TotalSum = order.OrderItems.Sum(o => o.Price * o.Quantity)
            }));
            return View(orderModels);
        }

    }
}