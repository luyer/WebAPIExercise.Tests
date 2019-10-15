using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using WebAPIExercise.Controllers;
using WebAPIExercise.Models;
using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using System.Collections.Generic;


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
          var postList = new List<Post> {
                new Post {Id = 1, Title = "Post 1", Body = "Cuerpo del post 1", Autor = "Luis" },
                new Post {Id = 2, Title = "Post 2", Body = "Cuerpo del post 2", Autor = "Eduardo" },
                new Post {Id = 3, Title = "Post 3", Body = "Cuerpo del post 3", Autor = "Marcelo" }
            };

            BlogPosts post = new BlogPosts(postList);
            Post data = new Post{
                Id = 1
            }; 
            // When  // Act
            var result = post.View(data.Id);
            // Then // Assert
            Assert.IsType<OkObjectResult>(result);
        }
        

        [Fact]
        public void View_WhenCalled_ReturnsOKResult_WhitFluentAssertions()
        {
            //Given //Arrange      
           var postList = new List<Post> {
                new Post {Id = 1, Title = "Post 1", Body = "Cuerpo del post 1", Autor = "Luis" },
                new Post {Id = 2, Title = "Post 2", Body = "Cuerpo del post 2", Autor = "Eduardo" },
                new Post {Id = 3, Title = "Post 3", Body = "Cuerpo del post 3", Autor = "Marcelo" }
            };
            BlogPosts post = new BlogPosts(postList);

            // When  // Act
            var result = (OkObjectResult)post.View(1);
            // Then // Assert

           Post  expected = new Post {Id = 1, Title = "Post 1", Body = "Cuerpo del post 1", Autor = "Luis" };
            //Assert.IsType<OkObjectResult>(result);
            //result.Value.Should().NotBeEquivalentTo(expected);
            result.Value.Should().BeEquivalentTo(expected);
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
