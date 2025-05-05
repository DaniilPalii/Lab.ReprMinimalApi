using ReprMinimalApi.Entities;

namespace ReprMinimalApi.Repositories;

public interface IBookRepository
{
	void Add(Book entity);

	Book? Get(Id id);

	IEnumerable<Book> GetAll();

	void Update(Book entity);

	void Delete(Id id);
}
