using Moq;

namespace CoffeeCupAPI.Tests.Systems.Controllers
{
	public class TestCoffeeCupsController
	{
        private readonly CoffeeCupsController _coffeeCupsControlle;
        private readonly Mock<ICoffeeCupService> _mockCoffeeCupsService;
        private readonly Mock<ILogger<CoffeeCupsController>> _mockLogger;

        public TestCoffeeCupsController()
        {
            _mockLogger = new Mock<ILogger<CoffeeCupsController>>();
            _mockCoffeeCupsService = new Mock<ICoffeeCupService>();
            _coffeeCupsControlle = new CoffeeCupsController(
                _mockCoffeeCupsService.Object,
                _mockLogger.Object);
        }

        [Fact]
		public async Task GetCoffeeCups_OnSuccess_ReturnsStatusCode200()
		{
            // Arrange
            _mockCoffeeCupsService
                .Setup(service => service.GetCoffeeCups())
                .ReturnsAsync(CoffeeCupsFixture.GetTestCoffeeCups());

			// Act
			var result = await _coffeeCupsControlle.GetCoffeeCups();

            // Assert
            var notFoundResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, notFoundResult.StatusCode);
        }

        [Fact]
        public async Task GetCoffeeCups_OnNotFound_Returns404()
        {
            // Arrange
            _mockCoffeeCupsService
                .Setup(service => service.GetCoffeeCups())
                .ReturnsAsync(new List<CoffeeCup>());

            // Act
            var result = await _coffeeCupsControlle.GetCoffeeCups();

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(404, notFoundResult.StatusCode);
        }

        [Fact]
        public async Task GetCoffeeCups_OnInternalServerError_Returns500()
        {
            // Arrange
            _mockCoffeeCupsService
                .Setup(service => service.GetCoffeeCups())
                .Throws<Exception>();

            // Act
            var result = await _coffeeCupsControlle.GetCoffeeCups();

            // Assert
            var errorResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, errorResult.StatusCode);
        }

        [Fact]
        public async Task GetCoffeeCups_OnSuccess_ReturnsListOfCoffeeCups()
        {
            // Arrange
            _mockCoffeeCupsService
                .Setup(service => service.GetCoffeeCups())
                .ReturnsAsync(CoffeeCupsFixture.GetTestCoffeeCups());

            // Act
            var result = await _coffeeCupsControlle.GetCoffeeCups();

            // Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<CoffeeCup>>(objectResult.Value);
            Assert.Equal(200, objectResult.StatusCode);
        }

        [Fact]
        public async Task GetCoffeeCup_OnSuccess_ReturnsACoffeeCup()
        {
            // Arrange
            _mockCoffeeCupsService
                .Setup(service => service.GetCoffeeCup(1))
                .ReturnsAsync(CoffeeCupsFixture.GetTestCoffeeCup());

            // Act
            var result = await _coffeeCupsControlle.GetCoffeeCup(1);

            // Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<CoffeeCup>(objectResult.Value);
            Assert.Equal(200, objectResult.StatusCode);
        }

        [Fact]
        public async Task AddCoffeeCup_OnBadRequestWithMissingField_Returns400()
        {
            // Arrange
            _coffeeCupsControlle.ModelState.AddModelError("Name", "Required");

            // Act
            var result = await _coffeeCupsControlle.AddCoffeeCup(CoffeeCupsFixture.reqModelWithMissingField);

            // Assert
            var objectResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, objectResult.Value);
        }
    }
}

