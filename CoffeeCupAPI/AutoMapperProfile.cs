namespace CoffeeCupAPI
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<PostCoffeeCupDto, CoffeeCup>();
		}
	}
}

