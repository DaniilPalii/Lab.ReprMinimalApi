using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using ReprMinimalApi.DTO;
using ReprMinimalApi.Repositories;

namespace ReprMinimalApi.Endpoints;

public static class AddBookEndpoint
{
	public static Results<Ok, BadRequest<IDictionary<string, string[]>>> Handle(
		NewBook newBook,
		IValidator<NewBook> newBookValidator,
		IBookRepository bookRepository)
	{
		var validationResult = newBookValidator.Validate(newBook);
		
		if (!validationResult.IsValid)
			return TypedResults.BadRequest(validationResult.ToDictionary());
		
		var entity = newBook.ToEntity();
		bookRepository.Add(entity);
		
		return TypedResults.Ok();
	}
}
