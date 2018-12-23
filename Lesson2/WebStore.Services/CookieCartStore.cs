﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WebStore.DomainModels.Models;
using WebStore.Interfaces;

namespace WebStore.Services
{
    public class CookieCartStore : ICartStore
    {
        private readonly string _cartName;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieCartStore(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _cartName = "cart" +
                        (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated
                            ? _httpContextAccessor.HttpContext.User.Identity.Name
                            : "");
        }

        public Cart Cart
        {
            get
            {
                var cookie =
                    _httpContextAccessor.HttpContext.Request.Cookies[_cartName];
                string json;
                Cart cart;
                if (cookie == null)
                {
                    cart = new Cart
                    {
                        Items = new
                            List<CartItem>()
                    };
                    json = JsonConvert.SerializeObject(cart);
                    _httpContextAccessor.HttpContext.Response.Cookies.Append(_cartName, json, new
                        CookieOptions
                        {
                            Expires = DateTime.Now.AddDays(1)
                        });
                    return cart;
                }

                json = cookie;
                cart =
                    JsonConvert.DeserializeObject<Cart>(json);
                _httpContextAccessor.HttpContext.Response.Cookies.Delete(_cartName);
                _httpContextAccessor.HttpContext.Response.Cookies.Append(_cartName, json, new
                    CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(1)
                    });
                return cart;
            }
            set
            {
                var json = JsonConvert.SerializeObject(value);
                _httpContextAccessor.HttpContext.Response.Cookies.Delete(_cartName);
                _httpContextAccessor.HttpContext.Response.Cookies.Append(_cartName, json, new
                    CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(1)
                    });
            }
        }
    }
}