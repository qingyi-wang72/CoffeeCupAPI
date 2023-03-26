namespace CoffeeCupAPI
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<CoffeeCupReqModel, CoffeeCup>();
		}
	}
}

