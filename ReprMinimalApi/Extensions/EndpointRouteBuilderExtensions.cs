namespace ReprMinimalApi.Extensions;

public static class EndpointRouteBuilderExtensions
{
	public static RouteHandlerBuilder MapGet(this IEndpointRouteBuilder endpoints, Delegate handler)
	{
		return endpoints.MapGet(pattern: string.Empty, handler);
	}
	
	public static RouteHandlerBuilder MapPost(this IEndpointRouteBuilder endpoints, Delegate handler)
	{
		return endpoints.MapPost(pattern: string.Empty, handler);
	}
	
	public static RouteHandlerBuilder MapPut(this IEndpointRouteBuilder endpoints, Delegate handler)
	{
		return endpoints.MapPut(pattern: string.Empty, handler);
	}
	
	public static RouteHandlerBuilder MapDelete(this IEndpointRouteBuilder endpoints, Delegate handler)
	{
		return endpoints.MapDelete(pattern: string.Empty, handler);
	}
}
