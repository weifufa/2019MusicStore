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
    public class ArtistTest
    {
        private readonly ITestOutputHelper _output;//ITestOutputHelper通过将其添加至构造函数，将实现存储，可在单元测试中使用它
        private readonly Artist _artist;
        public ArtistTest(ITestOutputHelper output)
        {
            _output = output;
            _artist = new Artist();
        }
        [Fact]
        public void ArtistEntityTest()
        {
            _output.WriteLine("这是我的Artist业务实体单元测试");
            //Arrange
            List<Artist> aList = new List<Artist>();
            Artist a1 = new Artist { Id = Guid.NewGuid(), Name = "张杰", Description = "国内歌手" };
            Artist a2 = new Artist { Id = Guid.NewGuid(), Name = "凌俊杰", Description = "国内歌手" };
            Artist a3 = new Artist { Id = Guid.NewGuid(), Name = "邓紫棋", Description = "国内歌手" };
            Artist a4 = new Artist { Id = Guid.NewGuid(), Name = "薛之谦", Description = "国内歌手" };
            Artist a5 = new Artist { Id = Guid.NewGuid(), Name = "李荣浩", Description = "国内歌手" };
            aList.Add(a1);
            aList.Add(a2);
            aList.Add(a3);
            aList.Add(a4);
            //Act
            var result = aList.Contains(a5);
            var nameResult = aList.Where(x => x.Name.Contains("邓紫棋")).Select(x => x.Name).First();
            _output.WriteLine(nameResult);
            //Assert
            Assert.False(result);
            Assert.Equal("邓紫棋", nameResult);
        }
    }
    }

