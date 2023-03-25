
namespace CoffeeCupAPI.Tests.Fixtures
{
	public static class CoffeeCupsFixture
	{
		public static List<CoffeeCup> GetTestCoffeeCups()
        {
            return new()
                {
                new CoffeeCup {
                    Id = 1,
                    Name = "Bunny cup",
                    Color = "White",
                    Material = "Ceramic",
                    Description = "convallis convallis tellus id interdum velit laoreet id donec ultrices",
                    Stock = 200,
                    Price = (float)4.99,
                },
                new CoffeeCup {
                    Id = 2,
                    Name = "Puppy cup",
                    Color = "Green",
                    Material = "Ceramic",
                    Description = "convallis convallis tellus id interdum velit laoreet id donec ultrices",
                    Stock = 252,
                    Price = (float)6.99,
                },
                new CoffeeCup {
                    Id = 3,
                    Name = "Pippy cup",
                    Color = "Pink",
                    Material = "Plastic",
                    Description = "convallis convallis tellus id interdum velit laoreet id donec ultrices",
                    Stock = 44,
                    Price = (float)5.59,
                },
            };
        }
    }
}

