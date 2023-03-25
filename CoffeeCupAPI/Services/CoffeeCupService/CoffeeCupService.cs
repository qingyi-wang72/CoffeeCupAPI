namespace CoffeeCupAPI.Services.CoffeeCupService
{
	public class CoffeeCupService : ICoffeeCupService
	{
        private readonly CoffeeCupContext _context;
        private readonly IMapper _mapper;

        public CoffeeCupService(CoffeeCupContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/CoffeeCups
        // List all the CoffeeCups
        [HttpGet]
        public async Task<ServiceResponse<List<CoffeeCup>>> GetCoffeeCups()
        {
            var serResponse = new ServiceResponse<List<CoffeeCup>>();
            var coffeeCups = await _context.CoffeeCups.ToListAsync();
            serResponse.Data = coffeeCups;
            return serResponse;
        }

        // GET: api/CoffeeCups/{id}
        // List the corresponding coffee cup by the given id
        [HttpGet("{id}")]
        public async Task<ServiceResponse<CoffeeCup>> GetCoffeeCup(int id)
        {
            var serResponse = new ServiceResponse<CoffeeCup>();

            try
            {
                var coffeeCup = await _context.CoffeeCups.FindAsync(id);
                if (coffeeCup is null)
                    throw new Exception($"coffeeCup with id {id} not found");
                serResponse.Data = coffeeCup;
            }
            catch (Exception ex)
            {
                serResponse.Success = false;
                serResponse.Message = ex.Message;
            }

            return serResponse;
        }

        // PUT: api/CoffeeCups/{id}
        // Update the corresponding coffee cup by the given id
        [HttpPut("{id}")]
        public async Task<ServiceResponse<List<CoffeeCup>>> UpdateCoffeeCup(int id, PutCoffeeCupDto reqCoffeeCup)
        {
            var serResponse = new ServiceResponse<List<CoffeeCup>>();

            try
            {
                var coffeeCup = await _context.CoffeeCups.FindAsync(id);
                if (coffeeCup is null)
                    throw new Exception($"coffeeCup with id {id} not found");

                coffeeCup.Name = reqCoffeeCup.Name;
                coffeeCup.Color = reqCoffeeCup.Color;
                coffeeCup.Material = reqCoffeeCup.Material;
                coffeeCup.Description = reqCoffeeCup.Description;
                coffeeCup.Stock = reqCoffeeCup.Stock;
                coffeeCup.Price = reqCoffeeCup.Price;

                await _context.SaveChangesAsync();
                var coffeeCups = await _context.CoffeeCups.ToListAsync();
                serResponse.Data = coffeeCups;

            }
            catch (Exception ex)
            {
                serResponse.Success = false;
                serResponse.Message = ex.Message;
            }

            return serResponse;
        }

        // POST: api/CoffeeCups
        // add a new coffee cup
        [HttpPost]
        public async Task<ServiceResponse<List<CoffeeCup>>> AddCoffeeCup(PostCoffeeCupDto reqCoffeeCup)
        {
            var serResponse = new ServiceResponse<List<CoffeeCup>>();

            _context.CoffeeCups.Add(_mapper.Map<CoffeeCup>(reqCoffeeCup));
            await _context.SaveChangesAsync();

            var coffeeCups = await _context.CoffeeCups.ToListAsync();
            serResponse.Data = coffeeCups;

            return serResponse;
        }

        // DELETE: api/CoffeeCups/{id}
        // delete the corresponding coffee cup by the given id
        [HttpDelete("{id}")]
        public async Task<ServiceResponse<List<CoffeeCup>>> DeleteCoffeeCup(int id)
        {
            var serResponse = new ServiceResponse<List<CoffeeCup>>();

            try
            {
                var coffeeCup = await _context.CoffeeCups.FindAsync(id);
                if (coffeeCup is null)
                    throw new Exception($"coffeeCup with id {id} not found");

                _context.CoffeeCups.Remove(coffeeCup);
                await _context.SaveChangesAsync();

                var coffeeCups = await _context.CoffeeCups.ToListAsync();
                serResponse.Data = coffeeCups;

            }
            catch (Exception ex)
            {
                serResponse.Success = false;
                serResponse.Message = ex.Message;
            }

            return serResponse;
        }
    }
}

