using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebStore.DomainModels.Dto;
using WebStore.DomainModels.Models;
using WebStore.Interfaces.Services;

namespace WebStore.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        public CartController(ICartService cartService, IOrderService orderService)
        {
            _cartService = cartService;
            _orderService = orderService;
        }
        public IActionResult Details()
        {
            var model = new CartDetailsViewModel
            {
                CartViewModel = _cartService.TransformCart(),
                OrderViewModel = new OrderViewModel()
            };
            return View(model);
        }

        public IActionResult Index()
        {
            return RedirectToAction("Details");
        }

        public IActionResult DecrementFromCart(int id)
        {
            _cartService.DecrementFromCart(id);
            return Json(new
            {
                id,
                message = "Количество товара уменьшено на 1"
            });
        }
        public IActionResult RemoveFromCart(int id)
        {
            _cartService.RemoveFromCart(id);
            return Json(new { id, message = "Товар удален из корзины" });
        }


        public IActionResult RemoveAll()
        {
            _cartService.RemoveAll();
            return RedirectToAction("Index");
        }

        public IActionResult AddToCart(int id)
        {

                _cartService.AddToCart(id);
                return Json(new { id, message = "Товар добавлен в корзину" });


        }

        public IActionResult GetCartView()
        {
            return ViewComponent("Cart");
        }


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CheckOut(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var orderModel = new CreateOrderModel()
                {
                    OrderViewModel = model,
                    OrderItems = new List<OrderItemDto>()
                };
                foreach (var orderItem in _cartService.TransformCart().Items)
                {
                    orderModel.OrderItems.Add(new OrderItemDto()
                    {
                        Id = orderItem.Key.Id,
                        Price = orderItem.Key.Price,
                        Quantity = orderItem.Value
                    });
                }

                var orderResult = _orderService.CreateOrder(orderModel, User.Identity.Name);
                _cartService.RemoveAll();
                return RedirectToAction("OrderConfirmed", new { id = orderResult.Id });
            }
            var detailsModel = new CartDetailsViewModel()
            {
                CartViewModel = _cartService.TransformCart(),
                OrderViewModel = model
            };
            return View("Details", detailsModel);
        }

        public IActionResult OrderConfirmed(int id)
        {
            ViewBag.OrderId = id;
            return View();
        }

    }
}