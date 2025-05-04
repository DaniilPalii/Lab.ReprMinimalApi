using ReprMinimalApi.DTO;
using ReprMinimalApi.Repositories;

namespace ReprMinimalApi.Endpoints;

public static class UpdateBookEndpoint
{
	public static void Handle(
		long id, 
		NewBook newBook,
		IBookRepository bookRepository)
	{
		var entity = newBook.ToEntity();
		entity.Id = id;
		bookRepository.Update(entity);
	}
}
