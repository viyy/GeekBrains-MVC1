﻿using Microsoft.AspNetCore.Mvc;
using WebStore.Interfaces.Services;

namespace WebStore.Components
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartService _cartService;

        public CartViewComponent(ICartService cartService)
        {
            _cartService = cartService;
        }

        public IViewComponentResult Invoke()
        {
            var cartView = _cartService.TransformCart();
            return View(cartView);
        }

    }
}
