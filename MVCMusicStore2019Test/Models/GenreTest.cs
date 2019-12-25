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
   public class GenreTest
    {
        private readonly ITestOutputHelper _output;//ITestOutputHelper通过将其添加至构造函数，将实现存储，可在单元测试中使用它
        private readonly Genre _genre;
        public GenreTest(ITestOutputHelper output)
        {
            _output = output;
            _genre = new Genre();
        }
        [Fact]
        public void GenreEntityTest()
        {
            _output.WriteLine("这是我的Genre业务实体单元测试");
            //Arrange
            List<Genre> aList = new List<Genre>();
            Genre a1 = new Genre { Id = Guid.NewGuid(), Name = "流行", Description = "流行" };
            Genre a2 = new Genre { Id = Guid.NewGuid(), Name = "轻音乐", Description = "轻音乐" };
            Genre a3 = new Genre { Id = Guid.NewGuid(), Name = "摇滚", Description = "摇滚" };
            Genre a4 = new Genre { Id = Guid.NewGuid(), Name = "民谣", Description = "民谣" };
            Genre a5 = new Genre { Id = Guid.NewGuid(), Name = "嘻哈", Description = "嘻哈" };
            aList.Add(a1);
            aList.Add(a2);
            aList.Add(a3);
            aList.Add(a4);
            aList.Add(a5);
            //Act
            var result = aList.Contains(a5);
            var nameResult = aList.Where(x => x.Name.Contains("嘻哈")).Select(x => x.Name).First();
            //Assert
            Assert.True(result);
            Assert.Equal("嘻哈", nameResult);
        }
    }
}
