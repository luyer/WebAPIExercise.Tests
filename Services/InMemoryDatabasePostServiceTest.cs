using System;
using Microsoft.EntityFrameworkCore;
using WebAPIExercise.Data;
using WebAPIExercise.Data.Models;
using WebAPIExercise.Services.PostService;
using Xunit;
using FluentAssertions;

namespace WebAPIExercise.Tests.Services
{
    
    public class InMemoryDatabasePostServiceTest : IDisposable
    {
        private WebAPIExerciseContext context;
        public InMemoryDatabasePostServiceTest()
        {
            var options = new DbContextOptionsBuilder<WebAPIExerciseContext>().UseInMemoryDatabase("mockdb-PostService").Options;
            context = new WebAPIExerciseContext(options);
        }
        
        [Fact]
        public void Add_CuandoSeEjecuta_AgregaUnPostADB()
        {
            context.Database.EnsureDeleted();
            Post fakePost = new Post
            {
                Title = "Post A",
                Body = "Cuerpo del post 1", 
                Autor = "Luis"
            };
            var SUT = new InMemoryPostDb(context);

            var newPost = SUT.Add(fakePost);
            context.Posts.Find(newPost.Id).Should().BeEquivalentTo(newPost);
        }

        [Fact]
        public void Delete_CuandoSeEjecuta_BorraUnRegistro()
        {
            context.Database.EnsureDeleted();
            Post fakePost = new Post
            {
                Title = "Post B",
                Body = "Cuerpo del post 2", 
                Autor = "Luis"
            };
            var newPost = context.Posts.Add(fakePost).Entity;
             var SUT = new InMemoryPostDb(context);

             SUT.Delete(newPost.Id);

             context.Posts.Find(newPost.Id).Should().BeNull();
        }

        [Fact]
        public void  GetById_CuandoSeUtilizaConUnIDValido_TraeElDetalleDelRegistro()
        {
            context.Database.EnsureDeleted();
            Post fakePost = new Post
            {
                Title = "Post C",
                Body = "Cuerpo del post 3", 
                Autor = "Luis"
            };
            var newPost = context.Posts.Add(fakePost).Entity;
            var SUT = new InMemoryPostDb(context);

            var result = SUT.GetById(newPost.Id);
            context.Posts.Find(newPost.Id).Should().BeEquivalentTo(result);

        }


        [Fact]
        public void Update_TestOFTheInMemoryPostDB()
        {
            context.Database.EnsureDeleted();
            Post fakePost = new Post
            {
                Title = "Post D",
                Body = "Cuerpo del post 4", 
                Autor = "Luis"
            };
            
            var SUT = new InMemoryPostDb(context);
            //var newPost = context.Posts.Add(fakePost).Entity;
            var newPost = SUT.Add(fakePost);

            fakePost.Body = "Actualizado";            
            SUT.Update(fakePost);

            var UpdatedPost = SUT.GetById(newPost.Id);
    
            //context.Posts.Find(newPost.Body).Should().BeEquivalentTo(UpdatedPost.Body);
            UpdatedPost.Body.Should().Be(fakePost.Body);
            

        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}