using ReprMinimalApi.Repositories;

namespace ReprMinimalApi.Endpoints;

public sealed class RemoveBookEndpoint
{
	public static void Handle(
		long id,
		IBookRepository bookRepository)
	{
		bookRepository.Delete(id);
	}
}
