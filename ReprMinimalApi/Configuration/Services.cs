using FluentValidation;
using ReprMinimalApi.DTO;
using ReprMinimalApi.Repositories;
using ReprMinimalApi.Validation;

namespace ReprMinimalApi.Configuration;

public static class Services
{
	public static void AddInto(IHostApplicationBuilder builder)
	{
		builder.Services.AddSingleton<IBookRepository, InMemoryBookRepository>();

		builder.Services.AddSingleton<IValidator<NewBook>, NewBookValidator>();
	}
}
