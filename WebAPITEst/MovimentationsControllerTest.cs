using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MovimentationsApi.Controllers;
using MovimentationsApi.Data;
using MovimentationsApi.Models;
using MovimentationsApi.Repositories;

namespace WebAPITEst
{
    public class MovimentationsControllerTest
    {
        private readonly MovimentationsController _controller;
        MovimentationsControllerTest() 
        {
            _controller = new MovimentationsController(repository: new MovimentationRepository(context: new MovimentationsContext(options: new DbContextOptions<MovimentationsContext>() )));
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetAllMovimentations();
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.GetAllMovimentations() as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<MovimentationUsecaseModel>>(okResult!.Value);
            Assert.Equal(3, items.Count);
        }
    }
}