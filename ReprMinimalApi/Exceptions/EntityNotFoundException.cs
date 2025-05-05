namespace ReprMinimalApi.Exceptions;

public sealed class EntityNotFoundException(Id id)
	: Exception(message: $"Entity not found (id: {id})");
