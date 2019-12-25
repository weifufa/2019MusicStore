using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit;
using MVCMusicStore2019.Models.MusicStores;

namespace MVCMusicStore2019Test.Models
{
   public class AlbumTypeTest
    {
        private readonly ITestOutputHelper _output;//ITestOutputHelper通过将其添加至构造函数，将实现存储，可在单元测试中使用它
        private readonly AlbumType _albumType;
        public AlbumTypeTest(ITestOutputHelper output)
        {
            _output = output;
            _albumType = new AlbumType();
        }
        [Fact]
        public void AlbumTypeEntityTest()
        {
            _output.WriteLine("这是我的Artist业务实体单元测试");
            //Arrange
            List<AlbumType> aList = new List<AlbumType>();
            AlbumType a1 = new AlbumType { Id = Guid.NewGuid(), Name = "伤感", Description = "伤感" };
            AlbumType a2 = new AlbumType { Id = Guid.NewGuid(), Name = "安静", Description = "安静" };
            AlbumType a3 = new AlbumType { Id = Guid.NewGuid(), Name = "快乐", Description = "快乐" };
            AlbumType a4 = new AlbumType { Id = Guid.NewGuid(), Name = "治愈", Description = "治愈" };
            AlbumType a5 = new AlbumType { Id = Guid.NewGuid(), Name = "励志", Description = "励志" };
            aList.Add(a1);
            aList.Add(a2);
            aList.Add(a3);
            aList.Add(a4);
            aList.Add(a5);
            //Act
            var result = aList.Contains(a5);
            var nameResult = aList.Where(x => x.Name.Contains("励志")).Select(x => x.Name).First();
            //Assert
            Assert.True(result);
            Assert.Equal("励志", nameResult);
        }
    }
}
