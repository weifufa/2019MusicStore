using Moq;
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
    public class AlbumTest : IDisposable
    {
        private readonly IEntityRepository<Album> _repository;
        private readonly MusicDbContext _context;
        private readonly ITestOutputHelper _output;
        public AlbumTest(ITestOutputHelper output)
        {
            _output = output;
            _context = new MusicDbContext();
            _repository = new EntityRepository<Album>(_context);
        }
        [Fact]
        public void AlbumIndexTest()
        {
            _output.WriteLine("这是AlbumController的Index方法的单元测试");
            var mockContext = new Mock<ControllerContext>();
            var controller = new AlbumController(_repository);
            controller.Index();
            _output.WriteLine(controller.Index().ToString());

            mockContext.Verify();
        }

        Guid id;
        [Fact]
        public async Task TaskAlbumCreate()
        {
            ///TaskGenreCreate()方法会飘绿，是因为该方法采用异步实现
            ///方法会自动检测方法实现有误await关键字
            ///如果没有await，就会飘绿，方法将会按照同步实现

            id = Guid.NewGuid();
            ///这是一组数据新增
            Guid gId = Guid.NewGuid();
            Guid aId = Guid.NewGuid();
            Guid tId = Guid.NewGuid();

            var g = new Genre()
            {
            Id=gId,
            Name="Name单元测试",
            Description= "Description单元测试"
            };
            var a = new Artist()
            {
                Id = aId,
                Name = "Name单元测试",
                Description = "Description单元测试"
            };
            var t = new AlbumType()
            {
                Id = tId,
                Name = "Name单元测试",
                Description = "Description单元测试"
            };

           

            ///一条数据
            var album = new Album()
            {
                Id = id,
                Name = "AlbumName单元测试",
                Description = "Description单元测试",
                IssueTime=DateTime.Now,
                Price=1.00M,
                Genre=g,
                Artist=a,
                AlbumType=t,
                
                
            };
            album.Genre.Id = gId;
            album.Artist.Id = aId;
            album.AlbumType.Id = tId;
            //_repository.AddAndSave(album);
            //var result = _repository.GetSingleById(id);
            //Assert.NotNull(result);
        }

        [Fact]
        public async Task TaskAlbumCreateEdit()
        {
            id = Guid.NewGuid();
            Guid gId = Guid.NewGuid();
            Guid aId = Guid.NewGuid();
            Guid tId = Guid.NewGuid();
            var g = new Genre()
            {
                Id = gId,
                Name = "Name单元测试",
                Description = "Description单元测试"
            };
            var a = new Artist()
            {
                Id = aId,
                Name = "Name单元测试",
                Description = "Description单元测试"
            };
            var t = new AlbumType()
            {
                Id = tId,
                Name = "Name单元测试",
                Description = "Description单元测试"
            };
            var task1 = new Album()
            {
                Id = id,
                Name = "AlbumName单元测试",
                Description = "Description单元测试",
                IssueTime = DateTime.Now,
                Price = 1.00M,
                Genre = g,
                Artist = a,
                AlbumType = t,
            };
            //Act
            _repository.AddAndSave(task1);
            //Arrange
            var task2 = new Album(task1)
            {
                Id = id,
                Name = "AlbumName单元测试",
                Description = "Description单元测试",
                IssueTime = DateTime.Now,
                Price = 1.00M,
                Genre = g,
                Artist = a,
                AlbumType = t,
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