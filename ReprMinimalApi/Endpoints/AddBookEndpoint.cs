using ReprMinimalApi.DTO;
using ReprMinimalApi.Repositories;

namespace ReprMinimalApi.Endpoints;

public static class AddBookEndpoint
{
	public static void Handle(
		NewBook newBook,
		IBookRepository bookRepository)
	{
		var entity = newBook.ToEntity();
		bookRepository.Add(entity);
	}
}
