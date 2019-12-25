using System;
using Xunit;

namespace MVCMusicStore2019Test
{
    public class Demo
    {
       public Demo()
        {
            this.isNew = true;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Calculateresult { get; set; }
        public bool isNew { get; set; }
        public void Add(int x,int y)
        {
            this.Calculateresult = x + y;
        }

        //Demo的单元测试实现
        [Fact]
        public void Calculation()
        {
            //Arrange
            var demo = new Demo();
            //Act
            demo.Add(45, 9);
            //Assert Bingo
            var result = demo.Calculateresult;
            Assert.Equal(54,result);
        }
        [Fact]
        public void IsNewWhenCreated()
        {
            //Arrange
            var demo = new Demo();
            //Act
            var result = demo.isNew;
            //Assert 
            Assert.True(result);
        }
        [Fact]
        public void DemoForName()
        {
            //Arrange
            var demo = new Demo
            {
                Id = Guid.NewGuid(),
                Name = "张三",
                Description = "这是张三的数据"
            };
            //Act
            var result = demo.Name;
            //Assert 
            Assert.Equal("张三", result);
        }
    }
}
