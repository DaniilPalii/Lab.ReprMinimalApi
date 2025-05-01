using ReprMinimalApi.Configuration;

var builder = WebApplication.CreateBuilder(args);

ApiReference.AddInto(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	ApiReference.UseIn(app);
}

app.UseHttpsRedirection();

app.Run();
