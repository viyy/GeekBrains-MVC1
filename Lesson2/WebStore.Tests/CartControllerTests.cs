using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebStore.Controllers;
using WebStore.DomainModels.Dto;
using WebStore.DomainModels.Models;
using WebStore.Interfaces.Services;
using Xunit;

namespace WebStore.Tests
{
    public class CartControllerTests
    {
        [Fact]
        public void CheckOut_Calls_Service_And_Return_Redirect()
        {
            #region Arrange

            var user = new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, "1")
            }));
            // setting up cartService
            var mockCartService = new Mock<ICartService>();
            mockCartService.Setup(c => c.TransformCart()).Returns(new
                CartViewModel
                {
                    Items = new Dictionary<ProductViewModel, int>
                    {
                        {new ProductViewModel(), 1}
                    }
                });
            // setting up ordersService
            var mockOrdersService = new Mock<IOrderService>();
            mockOrdersService.Setup(c =>
                    c.CreateOrder(It.IsAny<CreateOrderModel>(), It.IsAny<string>()))
                .Returns(new OrderDto {Id = 1});
            var controller = new CartController(mockCartService.Object,
                mockOrdersService.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext
                    {
                        User = user
                    }
                }
            };

            #endregion

            // Act
            var result = controller.CheckOut(new OrderViewModel
            {
                Name =
                    "test",
                Address = "",
                Phone = ""
            });
            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectResult.ControllerName);
            Assert.Equal("OrderConfirmed", redirectResult.ActionName);
            Assert.Equal(1, redirectResult.RouteValues["id"]);
        }

        [Fact]
        public void CheckOut_ModelState_Invalid_Returns_ViewModel()
        {
            var mockCartService = new Mock<ICartService>();
            var mockOrdersService = new Mock<IOrderService>();
            var controller = new CartController(mockCartService.Object,
                mockOrdersService.Object);
            controller.ModelState.AddModelError("error", "InvalidModel");
            var result = controller.CheckOut(new OrderViewModel
            {
                Name = "test"
            });
            var viewResult = Assert.IsType<ViewResult>(result);
            var model =
                Assert.IsAssignableFrom<CartDetailsViewModel>(viewResult.ViewData.Model);
            Assert.Equal("test", model.OrderViewModel.Name);
        }
    }
}