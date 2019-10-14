using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using WebAPIExercise.Controllers;
using WebAPIExercise.Models;
using System.ComponentModel.DataAnnotations;


namespace WebAPIExercise.Tests
{
    public class PostsControllerTests
    {
        [Fact]
        public void Index_WhenCalled_ReturnsOKResult()
        {
            //Given //Arrange
            BlogPosts post = new BlogPosts(); 

            // When  // Act
            var result = post.Index();

            // Then // Assert
            Assert.IsType<OkObjectResult>(result);
        
        }

        [Fact]
        public void View_WhenCalled_ReturnsOKResult()
        {
            //Given //Arrange
            BlogPosts post = new BlogPosts();
            Post data = new Post{
                Id = 1,
                Title = "Titulo",
                Body = "contenido del post",
                Autor = "el equipo"
            }; 

            // When  // Act
            var result = post.View(data.Id);

            // Then // Assert
            Assert.IsType<OkObjectResult>(result);
        
        }

        [Fact]
        public void Add_WhenCalled_ReturnsOKResult()
        {
            //Given //Arrange
            BlogPosts post = new BlogPosts();
            Post data = new Post{
                Title = "Titulo",
                Body = "contenido del post",
                Autor = "el equipo"
            }; 

            // When  // Act
            var result = post.Add(data);

            // Then // Assert
            Assert.IsType<OkObjectResult>(result);
        
        }


        [Fact]
        public void Delete_WhenCalledWhitoutID_ReturnsBadRequest()
        {
            //Given //Arrange
            BlogPosts post = new BlogPosts();
            Post data = new Post{
                Id = 10
            }; 

            // When  // Act
            var result = post.Delete(data.Id);
            // Then // Assert
            Assert.IsType<BadRequestResult>(result);
        }

    }
}
