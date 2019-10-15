using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using WebAPIExercise.Controllers;
using WebAPIExercise.Models;
using FluentAssertions;


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


        /* 
        [Fact]
        public void Create_WhenCalled_WhitValidCustomer_ReturnsCreatedAtActionResult(){

            // Given
            TestController testController = new TestController();
            Customer newCustomer = new Customer {
                FirstName = "Luis",
                Lastname = "Lozano",
                Email = "luis@bla.com"
            };
            // when
            var getResult = testController.Create(newCustomer); 

            // then
            Assert.IsType<CreatedAtActionResult>(getResult);

        }
        

        [Fact]
        public void GetOne_WhenCalled_ReturnsCustomer()
        {

            var customers = new List<Customer> {
                new Customer { Id = 1, FirstName = "steve", Lastname = "Balh", Email = "correo@bla.com"  },
                new Customer { Id = 2, FirstName = "luis", Lastname = "Balh", Email = "luis@bla.com"  }
            };

            TestController SUT = new TestController(customers);


            //act 
            var getResult = (OkObjectResult)SUT.Get(1);


            // Assert
            //getResult.Value.Should().BeEquivalentTo(customers[0]);
            Customer expected = new Customer { Id = 1, FirstName = "steve", Lastname = "Balh", Email = "correo@bla.com"  };
            getResult.Value.Should().BeEquivalentTo(expected);

        }
        */

    }
}
