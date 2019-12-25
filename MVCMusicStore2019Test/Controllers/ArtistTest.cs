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
   public class ArtistTest
    {
        private readonly IEntityRepository<Artist> _repository;
        private readonly MusicDbContext _context;
        private readonly ITestOutputHelper _output;
        public ArtistTest(ITestOutputHelper output)
        {
            _output = output;
            _context = new MusicDbContext();
            _repository = new EntityRepository<Artist>(_context);
        }
        [Fact]
        public void ArtistIndexTest()
        {
            _output.WriteLine("这是ArtistController的Index方法的单元测试");
            var mockContext = new Mock<ControllerContext>();
            var controller = new ArtistController(_repository);
            controller.Index();
            _output.WriteLine(controller.Index().ToString());

            mockContext.Verify();
        }
        Guid id;
        [Fact]
        public async Task TaskArtistCreate()
        {
            ///TaskGenreCreate()方法会飘绿，是因为该方法采用异步实现
            ///方法会自动检测方法实现有误await关键字
            ///如果没有await，就会飘绿，方法将会按照同步实现

            id = Guid.NewGuid();
            ///这是一组数据新增
            var taskList = new List<Artist>();
            taskList.Add(new Artist()
            {
                Id = id,
                Name = "ArtistName单元测试",
                Description = "Description单元测试"
            });
            ///一条数据
            var task = new Artist()
            {
                Id = id,
                Name = "ArtistName单元测试",
                Description = "Description单元测试"
            };
            _repository.AddAndSave(task);
            var result = _repository.GetSingleById(id);
            Assert.NotNull(result);
        }
        [Fact]
        public async Task TaskArtistCreateEdit()
        {
            //Arrange
            id = Guid.NewGuid();
            var task1 = new Artist()
            {
                Id = id,
                Name = "ArtistName单元测试",
                Description = "Description单元测试"
            };
            //Act
            _repository.AddAndSave(task1);
            //Arrange
            var task2 = new Artist(task1)
            {
                Id = id,
                Name = "ArtistName单元测试",
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
