namespace CoffeeCupAPI.Services.CoffeeCupService
{
	public interface ICoffeeCupService
	{
        // GET: api/CoffeeCups
        // List all the CoffeeCups
        Task<List<CoffeeCup>> GetCoffeeCups();

        // GET: api/CoffeeCups/{id}
        // List the corresponding coffee cup by the given id
        Task<ServiceResponse<CoffeeCup>> GetCoffeeCup(int id);

        // PUT: api/CoffeeCups/{id}
        // Update the corresponding coffee cup by the given id
        Task<ServiceResponse<List<CoffeeCup>>> UpdateCoffeeCup(int id, PutCoffeeCupDto coffeeCup);

        // POST: api/CoffeeCups
        // add a new coffee cup
        Task<ServiceResponse<List<CoffeeCup>>> AddCoffeeCup(PostCoffeeCupDto coffeeCup);

        // DELETE: api/CoffeeCups/{id}
        // delete the corresponding coffee cup by the given id
        Task<ServiceResponse<List<CoffeeCup>>> DeleteCoffeeCup(int id);
    }
}

