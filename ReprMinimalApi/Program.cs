using ReprMinimalApi.Configuration;

var builder = WebApplication.CreateBuilder(args);
ApiReference.AddInto(builder);
Services.AddInto(builder);
Middlewares.AddInto(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	ApiReference.UseIn(app);
}

app.UseHttpsRedirection();
Middlewares.UseIn(app);
Routes.Map(app);

app.Run();
