using JsonPlaceHolderDependencyInjection.Function;
using JsonPlaceHolderDependencyInjection.Function.Models;
using JsonPlaceHolderDependencyInjection.Function.Services;
using JsonPlaceHolderDependencyInjection.Tests.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace JsonPlaceHolderDependencyInjection.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task Album_ReturnsAOkObjectResult_WithAListOf2Albums()
        {
            // Arrange
            var request = TestFactory.CreateHttpRequest();
            var mockService = new Mock<IJsonPlaceholderService>();
            mockService.Setup(serv => serv.GetAlbums()).Returns(Task.FromResult(TestFactory.GetTestAlbums()));
            var getAlbums = new GetAlbums(mockService.Object, new NullLoggerFactory());

            // Act
            var response = await getAlbums.Run(request, null);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(response);
            var model = Assert.IsAssignableFrom<List<Album>>(okResult.Value);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public async Task Photo_ReturnsAOkObjectResult_WithAPhoto()
        {
            // Arrange
            var request = TestFactory.CreateHttpRequest();
            var mockService = new Mock<IJsonPlaceholderService>();
            mockService.Setup(serv => serv.GetPhotoById(1)).Returns(Task.FromResult(TestFactory.GetTestPhotos(1)));
            var getPhotos = new GetPhotos(mockService.Object, new NullLoggerFactory());

            // Act
            var response = await getPhotos.Run(request, 1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(response);
            var model = Assert.IsAssignableFrom<Photo>(okResult.Value);
        }
    }
}
