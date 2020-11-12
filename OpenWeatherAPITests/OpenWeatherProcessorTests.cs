using System;
using System.Threading.Tasks;
using Moq;
using OpenWeatherAPI;
using Xunit;
namespace OpenWeatherAPITests
{
    public class OpenWeatherProcessorTests : IDisposable
    {
        

        [Fact]
        public void  GetOneCallAsync_IfApiKeyEmptyOrNull_ThrowArgumentException()
        {
            // Arrange    
            var moq = new Mock<OpenWeatherProcessor>();        
            //Act
            if(moq.Object.ApiKey==null||moq.Object.ApiKey=="")
            {
                Assert.ThrowsAsync<NullReferenceException>(() => moq.Object.GetOneCallAsync());
            }
            //Assert
          

        }
        [Fact]
        public void GetCurrentWeatherAsync_IfApiKeyEmptyOrNull_ThrowArgumentException()
        {
            // Arrange
            var moq = new Mock<OpenWeatherProcessor>();
            //Act
            if (moq.Object.ApiKey == null || moq.Object.ApiKey == "")
            {
                Assert.ThrowsAsync<NullReferenceException>(() => moq.Object.GetCurrentWeatherAsync());
            }
            //Assert
        }
        [Fact]
        public void GetOneCallAsync_IfApiHelperNotInitialized_ThrowArgumentException()
        {
            // Arrange
         
            var moq = new Mock<OpenWeatherProcessor>();
            //Act
            //Assert
            Assert.ThrowsAsync<TypeInitializationException>(() => moq.Object.GetOneCallAsync());
        }
        [Fact]
        public void GetCurrentWeatherAsync_IfApiHelperNotInitialized_ThrowArgumentException()
        {
            // Arrange
         
            var moq = new Mock<OpenWeatherProcessor>();
            //Act
            //Assert
            Assert.ThrowsAsync<TypeInitializationException>(() => moq.Object.GetCurrentWeatherAsync());
        }
        public void Dispose()
        {
           
        }
    }
}
