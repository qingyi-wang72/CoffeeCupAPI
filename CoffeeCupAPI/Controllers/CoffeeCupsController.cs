using Microsoft.AspNetCore.Http;

namespace CoffeeCupAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeCupsController : ControllerBase
    {
        private readonly ICoffeeCupService _coffeeCupService;
        private readonly ILogger<CoffeeCupsController> _logger;

        public CoffeeCupsController(
            ICoffeeCupService coffeeCupService,
            ILogger<CoffeeCupsController> logger)
        {
            _coffeeCupService = coffeeCupService;
            _logger = logger;
        }

        // GET: api/CoffeeCups
        // List all the CoffeeCups
        [HttpGet]
        public async Task<IActionResult> GetCoffeeCups()
        {
            try
            {
                var result = await _coffeeCupService.GetCoffeeCups();
                if (result.Any())
                    return Ok(result);
                return NotFound("Coffee cups not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong inside GetCoffeeCups action: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // GET: api/CoffeeCups/{id}
        // List the corresponding coffee cup by the given id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoffeeCup(int id)
        {
            try
            {
                var result = await _coffeeCupService.GetCoffeeCup(id);
                if (result != null)
                    return Ok(result);
                return NotFound($"Coffee cup with id {id} not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong inside GetCoffeeCup action: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // POST: api/CoffeeCups
        // add a new coffee cup
        [HttpPost]
        public async Task<IActionResult> AddCoffeeCup([FromBody]CoffeeCupReqModel coffeeCup)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _coffeeCupService.AddCoffeeCup(coffeeCup);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong inside AddCoffeeCup action: {ex.Message}");
                return StatusCode(500,"Internal Server Error");
            }
        }

        // PUT: api/CoffeeCups/{id}
        // Update the corresponding coffee cup by the given id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCoffeeCup(int id, [FromBody] CoffeeCupReqModel coffeeCup)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var findCoffeeCup = await _coffeeCupService.GetCoffeeCup(id);
                if (findCoffeeCup == null)
                    return NotFound($"Coffee cup with id {id} not found.");

                var result = await _coffeeCupService.UpdateCoffeeCup(id, coffeeCup);
                if (result != null)
                    return Ok(result);
                return NotFound($"Coffee cup with id {id} not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong inside UpdateCoffeeCup action: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        //// DELETE: api/CoffeeCups/{id}
        //// delete the corresponding coffee cup by the given id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoffeeCup(int id)
        {
            try
            {
                var findCoffeeCup = await _coffeeCupService.GetCoffeeCup(id);
                if (findCoffeeCup == null)
                    return NotFound($"Coffee cup with id {id} not found.");

                var result = await _coffeeCupService.DeleteCoffeeCup(id);
                if (result != null)
                    return Ok(result);
                return NotFound($"Coffee cup with id {id} not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong inside DeleteCoffeeCup action: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
