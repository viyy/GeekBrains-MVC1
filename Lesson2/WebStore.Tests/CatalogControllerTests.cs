using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebStore.Controllers;
using WebStore.DomainModels.Dto;
using WebStore.DomainModels.Entities;
using WebStore.DomainModels.Interfaces;
using WebStore.DomainModels.Models;
using Xunit;

namespace WebStore.Tests
{
    public class CatalogControllerTests
    {
        [Fact]
        public void ProductDetails_Returns_NotFound()
        {
            // Arrange
            var productMock = new Mock<IProductData>();
            productMock.Setup(p =>
                p.GetProductById(It.IsAny<int>())).Returns((ProductDto) null);
            var controller = new CatalogController(productMock.Object);
            // Act
            var result = controller.Details(1);
            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void ProductDetails_Returns_View_With_Correct_Item()
        {
            // Arrange
            var productMock = new Mock<IProductData>();
            productMock.Setup(p =>
                p.GetProductById(It.IsAny<int>())).Returns(new ProductDto
            {
                Id = 1,
                Name = "Test",
                ImageUrl = "TestImage.jpg",
                Order = 0,
                Price = 10,
                Brand = new BrandDto
                {
                    Id = 1,
                    Name = "TestBrand"
                }
            });
            var controller = new CatalogController(productMock.Object);
            // Act
            var result = controller.Details(1);
            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<ProductViewModel>(
                viewResult.ViewData.Model);
            Assert.Equal(1, model.Id);
            Assert.Equal("Test", model.Name);
            Assert.Equal(10, model.Price);
            Assert.Equal("TestBrand", model.Brand);
        }

        [Fact]
        public void Shop_Method_Returns_Correct_View()
        {
            // Arrange
            var productMock = new Mock<IProductData>();
            productMock.Setup(p =>
                p.GetProducts(It.IsAny<ProductFilter>())).Returns(new List<ProductDto>
            {
                new ProductDto
                {
                    Id = 1,
                    Name = "Test",
                    ImageUrl = "TestImage.jpg",
                    Order = 0,
                    Price = 10,
                    Brand = new BrandDto
                    {
                        Id = 1,
                        Name = "TestBrand"
                    }
                },
                new ProductDto
                {
                    Id = 2,
                    Name = "Test2",
                    ImageUrl = "TestImage2.jpg",
                    Order = 1,
                    Price = 22,
                    Brand = new BrandDto
                    {
                        Id = 1,
                        Name = "TestBrand"
                    }
                }
            });
            var controller = new CatalogController(productMock.Object);
            // Act
            var result = controller.Shop(1, 5);
            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<CatalogViewModel>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Products.Count());
            Assert.Equal(5, model.BrandId);
            Assert.Equal(1, model.SectionId);
            Assert.Equal("TestImage2.jpg",
                model.Products.ToList()[1].ImageUrl);
        }
    }
}