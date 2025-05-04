using ReprMinimalApi.Repositories;

namespace ReprMinimalApi.Endpoints;

public static class GetAllBooksEndpoint
{
	public static IEnumerable<DTO.Book> Handle(
		IBookRepository bookRepository)
	{
		var books = bookRepository.GetAll();
		
		return books.Select(entity => new DTO.Book(entity));
	}
}
