using ReprMinimalApi.Entities;

namespace ReprMinimalApi.Repositories;

public interface IBookRepository
{
	void Add(Book entity);

	Book? Get(long id);

	IEnumerable<Book> GetAll();

	void Update(Book entity);

	void Delete(long id);
}
