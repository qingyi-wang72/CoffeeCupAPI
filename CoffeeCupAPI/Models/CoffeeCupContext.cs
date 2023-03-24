using System;

namespace CoffeeCupAPI.Models
{
	public class CoffeeCupContext : DbContext
	{
		public CoffeeCupContext(DbContextOptions<CoffeeCupContext> options) : base(options)
		{
		}

		public DbSet<CoffeeCup> CoffeeCups { get; set; }
	}
}

