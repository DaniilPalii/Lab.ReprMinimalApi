using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using ReprMinimalApi.DTO;
using ReprMinimalApi.Extensions;
using ReprMinimalApi.Repositories;

namespace ReprMinimalApi.Endpoints;

public static class AddBookEndpoint
{
	public static Results<Ok, DetailedBadRequest> Handle(
		NewBook newBook,
		IValidator<NewBook> newBookValidator,
		IBookRepository bookRepository)
	{
		if (newBookValidator.IsInvalid(newBook, out var badRequest))
			return badRequest;
		
		var entity = newBook.ToEntity();
		bookRepository.Add(entity);
		
		return TypedResults.Ok();
	}
}
