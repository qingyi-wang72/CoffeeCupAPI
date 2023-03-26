using System;
namespace CoffeeCupAPI.Models
{
	public class CoffeeCup
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Color { get; set; } = string.Empty;
        public string Material { get; set; } = string.Empty;
        public string? Description { get; set; }
		public int Stock { get; set; }
		public float Price { get; set; }
	}
}

