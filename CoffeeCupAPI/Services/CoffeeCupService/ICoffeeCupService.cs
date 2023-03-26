namespace CoffeeCupAPI.Services.CoffeeCupService
{
	public interface ICoffeeCupService
	{
        // GET: api/CoffeeCups
        // List all the CoffeeCups
        Task<List<CoffeeCup>> GetCoffeeCups();

        // GET: api/CoffeeCups/{id}
        // List the corresponding coffee cup by the given id
        Task<CoffeeCup?> GetCoffeeCup(int id);

        // POST: api/CoffeeCups
        // add a new coffee cup
        Task<List<CoffeeCup>> AddCoffeeCup(CoffeeCupReqModel coffeeCup);

        //// PUT: api/CoffeeCups/{id}
        //// Update the corresponding coffee cup by the given id
        Task<List<CoffeeCup>?> UpdateCoffeeCup(int id, CoffeeCupReqModel coffeeCup);

        //// DELETE: api/CoffeeCups/{id}
        //// delete the corresponding coffee cup by the given id
        Task<List<CoffeeCup>?> DeleteCoffeeCup(int id);
    }
}

