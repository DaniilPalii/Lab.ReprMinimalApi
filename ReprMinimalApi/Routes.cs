using ReprMinimalApi.Endpoints;
using ReprMinimalApi.Extensions;

namespace ReprMinimalApi;

public static class Routes
{
	public static void Map(WebApplication app)
	{
		var books = app.MapGroup("books").WithTags("Books");

		books.MapPost(AddBookEndpoint.Handle);
		books.MapGet(GetAllBooksEndpoint.Handle);
		
		var bookById = books.MapGroup("{id}");
		
		bookById.MapGet(GetBookEndpoint.Handle);
		bookById.MapPut(UpdateBookEndpoint.Handle);
		bookById.MapDelete(RemoveBookEndpoint.Handle);
	}
}
