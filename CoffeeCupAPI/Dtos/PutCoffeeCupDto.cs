namespace CoffeeCupAPI.Dtos
{
	public class PutCoffeeCupDto
	{
        public string? Name { get; set; }
        public string? Color { get; set; }
        public string? Material { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
    }
}

