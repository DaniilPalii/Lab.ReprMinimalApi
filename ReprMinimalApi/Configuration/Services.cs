using ReprMinimalApi.Repositories;

namespace ReprMinimalApi.Configuration;

public static class Services
{
	public static void AddInto(IHostApplicationBuilder builder)
	{
		builder.Services.AddSingleton<IBookRepository, InMemoryBookRepository>();
	}
}
