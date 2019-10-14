using System;
using Xunit;
using Microsoft.AspNetCore.Mvc.Core;
using WebAPIExercise.Controllers;
using WebAPIExercise.Models;


namespace WebAPIExercise.Tests
{
    public class CustomerControllerTests
    {
        [Fact]
        public void GetAll_WhenCalled_ReturnsOKResult()
        {
            //Arrange
            TestController testController = new TestController();

            // Act
            var getResult = testController.GetAll();

            // Assert
            Assert.IsType<OkObjectResult>(getResult);
        }

        [Fact]
        public void Create_WhenCalled_WhitValidCustomer_ReturnsCreatedAtActionResult(){

            // Given
            TestController testController = new TestController();
            TestController newCustomer = new Customer {
                FirstName = "Luis",
                Lastname = "Lozano",
                Email = "luis@bla.com"
            };
            // when
            var getResult = testController.Create(newCustomer); 

            // then
            Assert.IsType<CreatedAtActionResult>(getResult);

        }


    }
}
