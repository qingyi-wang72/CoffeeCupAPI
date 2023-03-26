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
        public async Task<List<CoffeeCup>> GetCoffeeCups()
        {
            var coffeeCups = await _context.CoffeeCups.ToListAsync();
            return coffeeCups;
        }

        // GET: api/CoffeeCups/{id}
        // List the corresponding coffee cup by the given id
        [HttpGet("{id}")]
        public async Task<CoffeeCup?> GetCoffeeCup(int id)
        {
            var coffeeCup = await _context.CoffeeCups.FindAsync(id);
            if (coffeeCup != null)
                return coffeeCup;
            return null;
        }

        // POST: api/CoffeeCups
        // add a new coffee cup
        [HttpPost]
        public async Task<List<CoffeeCup>> AddCoffeeCup(CoffeeCupReqModel reqCoffeeCup)
        {

            _context.CoffeeCups.Add(_mapper.Map<CoffeeCup>(reqCoffeeCup));
            await _context.SaveChangesAsync();
            var coffeeCups = await _context.CoffeeCups.ToListAsync();
            return coffeeCups;
        }

        
        // PUT: api/CoffeeCups/{id}
        // Update the corresponding coffee cup by the given id
        [HttpPut("{id}")]
        public async Task<List<CoffeeCup>?> UpdateCoffeeCup(int id, CoffeeCupReqModel reqCoffeeCup)
        {
            var coffeeCup = await _context.CoffeeCups.FindAsync(id);
            if (coffeeCup != null)
            {
                coffeeCup.Name = reqCoffeeCup.Name;
                coffeeCup.Color = reqCoffeeCup.Color;
                coffeeCup.Material = reqCoffeeCup.Material;
                coffeeCup.Description = reqCoffeeCup.Description;
                coffeeCup.Stock = reqCoffeeCup.Stock;
                coffeeCup.Price = reqCoffeeCup.Price;

                await _context.SaveChangesAsync(); // exception
                var coffeeCups = await _context.CoffeeCups.ToListAsync();
                return coffeeCups;
            }
            return null;
        }
        
        // DELETE: api/CoffeeCups/{id}
        // delete the corresponding coffee cup by the given id
        [HttpDelete("{id}")]
        public async Task<List<CoffeeCup>?> DeleteCoffeeCup(int id)
        {
            var coffeeCup = await _context.CoffeeCups.FindAsync(id);
            if (coffeeCup != null)
            {
                _context.CoffeeCups.Remove(coffeeCup);
                await _context.SaveChangesAsync();
                var coffeeCups = await _context.CoffeeCups.ToListAsync();
                return coffeeCups;
            }
            return null;
        }
    }
}

