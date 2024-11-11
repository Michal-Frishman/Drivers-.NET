using Drivers.Controllers;
using Drivers.Entities;
using Microsoft.AspNetCore.Mvc;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void GetAll_ReturnsOKResult()
        {
            //Arrange
            //Act
            var test = (new DriversController()).Get();
            //Assert
            Assert.IsType<ActionResult<List<Driver>>>(test);
            //Assert.IsType<List<CustomerEntity>>(test);
        }

        [Fact]
        public void GetById_ReturnsBadRequest()
        {
            //Arrange
            var id = -1;
            //Act
            var test = (new DriversController()).GetById(id);
            //Assert
            Assert.IsType<BadRequestResult>(test.Result);
        }
        [Fact]
        public void GetById_ReturnsNotFound()
        {
            //Arrange
            var id = 2;
            //Act
            var test = (new DriversController()).GetById(id);
            //Assert
            Assert.IsType<NotFoundResult>(test.Result);
        }

        [Fact]
        public void GetById_ReturnsOKResult()
        {
            //Arrange
            var id = 1;
            //Act
            var test = (new DriversController()).GetById(id);
            //Assert
            Assert.IsType<ActionResult<Driver>>(test);
            //Assert.IsType<OkObjectResult>(test);
        }

    }
}









