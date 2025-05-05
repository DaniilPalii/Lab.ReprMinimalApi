using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using ReprMinimalApi.DTO;
using ReprMinimalApi.Repositories;
using ReprMinimalApi.Extensions;

namespace ReprMinimalApi.Endpoints;

public static class UpdateBookEndpoint
{
	public static Results<Ok, DetailedBadRequest> Handle(
		Id id, 
		NewBook newBook,
		IValidator<NewBook> newBookValidator,
		IBookRepository bookRepository)
	{
		if (newBookValidator.IsInvalid(newBook, out var badRequest))
			return badRequest;
		
		var entity = newBook.ToEntity();
		entity.Id = id;
		bookRepository.Update(entity);
		
		return TypedResults.Ok();
	}
}
