using RadioFreeEuropeAssignment;
using RadioFreeEuropeAssignment.Models;

namespace RadioTest
{
    public class RepositoryTest
    {
        [Fact]
        public void AddLeftTest()
        {
            //Arrange
            var _data = new Dictionary<int, (string left, string right)>();
            Repository _repository = new Repository();
            var newData = new InputData("test");

            //Act
            var result = _repository.Add(1, "left", newData);

            //Assert
            Assert.Equal(Status.Success.Result, result.Result);
            Assert.True(newData.Input == _repository.input[1].left);
        }
        [Fact]
        public void AddRightTest()
        {
            //Arrange
            var _data = new Dictionary<int, (string left, string right)>();
            Repository _repository = new Repository();
            var newData = new InputData("test");

            //Act
            var result = _repository.Add(1, "right", newData);

            //Assert
            Assert.Equal(Status.Success.Result, result.Result);
            Assert.True(newData.Input == _repository.input[1].right);
        }
        [Fact]
        public void CheckLeftAndRightDifferencesTest()
        {
            //Arrange
            var _data = new Dictionary<int, (string left, string right)>();
            Repository _repository = new Repository();
            var newData1 = new InputData("test");
            var newData2 = new InputData("tesq");
            _repository.Add(1, "left", newData1);
            _repository.Add(1, "right", newData2);

            //Act
            var result = _repository.Diff(1);

            //Assert
            Assert.Equal(Status.Success.Result, result.result.Result);
            Assert.True(3 == result.offset[0].offset);
            Assert.True(1 == result.offset[0].length);
        }
    }
}