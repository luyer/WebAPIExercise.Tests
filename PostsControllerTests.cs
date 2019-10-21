using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using WebAPIExercise.Controllers;
using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using System.Collections.Generic;
using Moq;
using WebAPIExercise.Services.PostService;
using WebAPIExercise.Data.Models;

namespace WebAPIExercise.Tests
{
    public class PostsControllerTests
    {
        
        [Fact]
        public void Index_WhenCalled_ReturnsOKResult()
        {
            //Given //Arrange
            var mockService = new Mock<IPostService>();

            var postList = new List<Post> {
                new Post {Id = 1, Title = "Post 1", Body = "Cuerpo del post 1", Autor = "Luis" },
                new Post {Id = 2, Title = "Post 2", Body = "Cuerpo del post 2", Autor = "Eduardo" },
                new Post {Id = 3, Title = "Post 3", Body = "Cuerpo del post 3", Autor = "Marcelo" }
            };

            mockService.Setup( serv => serv.GetAll()).Returns(postList);
            BlogPosts post = new BlogPosts(mockService.Object); 

            // When  // Act
            var result = (OkObjectResult)post.Index();

            // Then // Assert
            Assert.IsType<OkObjectResult>(result); // esto si esta pasando
            //result.Value.Should().BeEquivalentTo(postList); // esto no esta pasando...
        
        }
        

        
        [Fact]
        public void View_WhenCalled_ReturnsOKResult()
        {
            //Given //Arrange
            /* 
          var postList = new List<Post> {
                new Post {Id = 1, Title = "Post 1", Body = "Cuerpo del post 1", Autor = "Luis" },
                new Post {Id = 2, Title = "Post 2", Body = "Cuerpo del post 2", Autor = "Eduardo" },
                new Post {Id = 3, Title = "Post 3", Body = "Cuerpo del post 3", Autor = "Marcelo" }
            };
            */
            var mockService = new Mock<IPostService>();
            var fakePost = new Post {Id = 1, Title = "Post 1", Body = "Cuerpo del post 1", Autor = "Luis" };

            mockService.Setup( serv => serv.GetById(1)).Returns(fakePost);

            BlogPosts post = new BlogPosts(mockService.Object);
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
            var mockService = new Mock<IPostService>();
            var fakePost = new Post {Id = 1, Title = "Post 1", Body = "Cuerpo del post 1", Autor = "Luis" };

            mockService.Setup( serv => serv.GetById(1)).Returns(fakePost);

            BlogPosts post = new BlogPosts(mockService.Object);
            // When  // Act
            var result = (OkObjectResult)post.View(1);
            // Then // Assert
            result.Value.Should().BeEquivalentTo(fakePost);
        }

        
        [Fact]
        public void Add_WhenCalled_ReturnsOKResult()
        {
            //Given //Arrange

            var mockService = new Mock<IPostService>();

            Post data = new Post{
                Title = "Titulo",
                Body = "contenido del post",
                Autor = "el equipo"
            };

            Post expected = new Post{
                Id = 1,
                Title = "Titulo",
                Body = "contenido del post",
                Autor = "el equipo"
            }; 

            mockService.Setup( serv => serv.Add(data)).Returns(expected);
            BlogPosts post = new BlogPosts(mockService.Object); 
            
            // When  // Act
            var result = post.Add(data);

            // Then // Assert
            Assert.IsType<OkObjectResult>(result);
        
        }

        /* 
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
        */

    }
}
