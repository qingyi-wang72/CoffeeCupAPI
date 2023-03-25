using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoffeeCupAPI.Models;

namespace CoffeeCupAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeCupsController : ControllerBase
    {
        private readonly ICoffeeCupService _coffeeCupService;

        public CoffeeCupsController(ICoffeeCupService coffeeCupService)
        {
            _coffeeCupService = coffeeCupService;
        }

        // GET: api/CoffeeCups
        // List all the CoffeeCups
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<CoffeeCup>>>> GetCoffeeCups()
        {
            return Ok(await _coffeeCupService.GetCoffeeCups());
        }

        // GET: api/CoffeeCups/{id}
        // List the corresponding coffee cup by the given id
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<CoffeeCup>>> GetCoffeeCup(int id)
        {
            var serResult = await _coffeeCupService.GetCoffeeCup(id);
            if (serResult.Data is null)
                return NotFound(serResult);
            return Ok(serResult);
        }

        // PUT: api/CoffeeCups/{id}
        // Update the corresponding coffee cup by the given id
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<List<CoffeeCup>>>> UpdateCoffeeCup(int id, [FromBody]PutCoffeeCupDto coffeeCup)
        {
            var serResult = await _coffeeCupService.UpdateCoffeeCup(id, coffeeCup);
            if (serResult.Data is null)
                return NotFound(serResult);
            return Ok(serResult);
        }

        // POST: api/CoffeeCups
        // add a new coffee cup
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<CoffeeCup>>>> AddCoffeeCup([FromBody]PostCoffeeCupDto coffeeCup)
        {
            return Ok(await _coffeeCupService.AddCoffeeCup(coffeeCup));
        }

        // DELETE: api/CoffeeCups/{id}
        // delete the corresponding coffee cup by the given id
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<CoffeeCup>>>> DeleteCoffeeCup(int id)
        {
            var serResult = await _coffeeCupService.DeleteCoffeeCup(id);
            if (serResult.Data is null)
                return NotFound(serResult);
            return Ok(serResult);
        }
    }
}
