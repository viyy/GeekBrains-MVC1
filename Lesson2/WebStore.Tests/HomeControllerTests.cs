using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebStore.Controllers;
using WebStore.Interfaces.Services;
using Xunit;

namespace WebStore.Tests
{
    public class HomeControllerTests
    {
        public HomeControllerTests()
        {
            var mockService = new Mock<IValuesService>();
            mockService.Setup(c => c.GetAsync()).ReturnsAsync(new List<string>
            {
                "1", "2"
            });
            _controller = new HomeController(mockService.Object);
        }

        private readonly HomeController _controller;

        [Fact]
        public void Blog_Returns_View()
        {
            var result = _controller.Blog();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void BlogSingle_Returns_View()
        {
            var result = _controller.BlogSingle();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Checkout_Returns_View()
        {
            var result = _controller.Checkout();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void ContactUs_Returns_View()
        {
            var result = _controller.ContactUs();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Error_Returns_View()
        {
            var result = _controller.Error();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void ErrorStatus_Antother_Returns_Content_Result()
        {
            var result = _controller.ErrorStatus("500");
            var contentResult = Assert.IsType<ContentResult>(result);
            Assert.Equal("Статуcный код ошибки: 500",
                contentResult.Content);
        }

        [Fact]
        public async Task Index_Method_Returns_View_With_ValuesAsync()
        {
            // Arrange and act
            var result = await _controller.Index().ConfigureAwait(false);
            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<string>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }
    }
}