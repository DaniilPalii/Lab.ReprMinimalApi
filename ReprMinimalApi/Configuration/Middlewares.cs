using ReprMinimalApi.Exceptions;

namespace ReprMinimalApi.Configuration;

public static class Middlewares
{
	public static void AddInto(IHostApplicationBuilder builder)
	{
		builder.Services.AddTransient<ExceptionHandlingMiddleware>();
	}
	
	public static void UseIn(IApplicationBuilder app)
	{
		app.UseMiddleware<ExceptionHandlingMiddleware>();
	}
}
