using System.Diagnostics.CodeAnalysis;
using FluentValidation;

namespace ReprMinimalApi.Extensions;

public static class ValidatorExtensions
{
	public static bool IsInvalid<T>(
		this IValidator<T> validator,
		T entity,
		[NotNullWhen(true)] out DetailedBadRequest? badRequest)
	{
		var validationResult = validator.Validate(entity);

		if (validationResult.IsValid)
		{
			badRequest = null;
			return false;
		}

		badRequest = TypedResults.BadRequest(validationResult.ToDictionary());
		return true;
	} 
}
