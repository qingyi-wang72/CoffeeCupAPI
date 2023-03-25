
namespace CoffeeCupAPI.Tests.Systems.Controllers
{
	public class TestCoffeeCupsController
	{
		[Fact]
		public async Task Get_OnSuccess_ReturnsStatusCode200()
		{
            // Arrange
            var mockCoffeeCupsService = new Mock<ICoffeeCupService>();
            mockCoffeeCupsService
                .Setup(service => service.GetCoffeeCups())
                .ReturnsAsync(CoffeeCupsFixture.GetTestCoffeeCups());

            var sut = new CoffeeCupsController(mockCoffeeCupsService.Object);

			// Act
			var result = await sut.GetCoffeeCups();

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.StatusCode.Should().Be(200);
        }

		[Fact]
		public async Task Get_OnSuccess_ReturnsListOfCoffeeCups()
		{
            // Arrange
            var mockCoffeeCupsService = new Mock<ICoffeeCupService>();
            mockCoffeeCupsService
                .Setup(service => service.GetCoffeeCups())
                .ReturnsAsync(CoffeeCupsFixture.GetTestCoffeeCups());

            var sut = new CoffeeCupsController(mockCoffeeCupsService.Object);

            // Act
            var result = await sut.GetCoffeeCups();

			// Assert
			result.Should().BeOfType<OkObjectResult>();
			var objectResult = (OkObjectResult)result;
			objectResult.Value.Should().BeOfType<List<CoffeeCup>>();
        }

        [Fact]
        public async Task Get_OnNoCoffeeCupsFound_Returns404()
        {
            // Arrange
            var mockCoffeeCupsService = new Mock<ICoffeeCupService>();
            mockCoffeeCupsService
                .Setup(service => service.GetCoffeeCups())
                .ReturnsAsync(new List<CoffeeCup>());

            var sut = new CoffeeCupsController(mockCoffeeCupsService.Object);

            // Act
            var result = await sut.GetCoffeeCups();

            // Assert
            result.Should().BeOfType<NotFoundResult>();
            var objectResult = (NotFoundResult)result;
            objectResult.StatusCode.Should().Be(404);
        }
    }
}

