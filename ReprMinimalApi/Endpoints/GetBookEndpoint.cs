using Microsoft.AspNetCore.Http.HttpResults;
using ReprMinimalApi.Repositories;

namespace ReprMinimalApi.Endpoints;

public static class GetBookEndpoint
{
	public static Results<Ok<DTO.Book>, NotFound> Handle(
		long id,
		IBookRepository bookRepository)
	{
		var entity = bookRepository.Get(id);

		if (entity is null)
			return TypedResults.NotFound();

		var dto = new DTO.Book(entity);
		return TypedResults.Ok(dto);
	}
}
