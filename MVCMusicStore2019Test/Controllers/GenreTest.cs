﻿using Moq;
using MVCMusicStore2019.Controllers.MusicStores;
using MVCMusicStore2019.Infrastructure;
using MVCMusicStore2019.Models.MusicStores;
using MVCMusicStore2019.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Xunit;
using Xunit.Abstractions;

namespace MVCMusicStore2019Test.Controllers
{
    public class GenreTest:IDisposable
    {
        private readonly IEntityRepository<Genre> _repository;
        private readonly MusicDbContext _context;
        private readonly ITestOutputHelper _output;
        public GenreTest(ITestOutputHelper output)
        {
            _output = output;
            _context = new MusicDbContext();
            _repository= new EntityRepository<Genre>(_context);
        }
        [Fact]
        public void GenreIndexTest()
        {
            _output.WriteLine("这是GenreController的Index方法的单元测试");
            var mockContext = new Mock<ControllerContext>();
            var controller = new GenreController(_repository);
            controller.Index();
            _output.WriteLine(controller.Index().ToString());

            mockContext.Verify();
        }

        Guid id;
        [Fact]
        public async Task TaskGenreCreate()
        {
            ///TaskGenreCreate()方法会飘绿，是因为该方法采用异步实现
            ///方法会自动检测方法实现有误await关键字
            ///如果没有await，就会飘绿，方法将会按照同步实现
      
            id = Guid.NewGuid();
            ///这是一组数据新增
            var taskList = new List<Genre>();
            taskList.Add(new Genre()
            {
                Id = id,
                Name = "GenreName单元测试",
                Description = "Description单元测试"
            });
            ///一条数据
            var task = new Genre()
            {
                Id = id,
                Name = "GenreName单元测试",
                Description = "Description单元测试"
            };
            _repository.AddAndSave(task);
            var result = _repository.GetSingleById(id);
            Assert.NotNull(result);
        }
       
        [Fact]
        public async Task TaskGenreCreateEdit()
        {
            //Arrange
            id = Guid.NewGuid();
            var task1 = new Genre()
            {
                Id = id,
                Name = "GenreName单元测试",
                Description = "Description单元测试"
            };
            //Act
            _repository.AddAndSave(task1);
            //Arrange
            var task2 = new Genre(task1)
            {
                Id = id,
                Name = "GenreName单元测试",
                Description = "Description单元测试"
            };

            //Act
            _repository.Edit(task2);
            var result = _repository.GetSingleById(id);
            //Assert
            Assert.NotNull(result);
        }
        public void Dispose()
        {

        }
    }
}
