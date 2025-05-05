global using Id = long;

global using DetailedBadRequest
	= Microsoft.AspNetCore.Http.HttpResults.BadRequest<System.Collections.Generic.IDictionary<string, string[]>>;