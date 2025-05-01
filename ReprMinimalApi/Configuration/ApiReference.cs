namespace ReprMinimalApi.Configuration;

public static class ApiReference
{
	public static void AddInto(IHostApplicationBuilder builder)
	{
		builder.Services.AddOpenApi();
		builder.Services.AddOpenApiDocument();
	}

	public static void UseIn(IApplicationBuilder app)
	{
		app.UseOpenApi();
		app.UseSwaggerUi(configure => configure.Path = "/docs");
	}
}
