using System.Collections.Concurrent;
using ReprMinimalApi.Exceptions;

namespace ReprMinimalApi.Repositories;

public sealed class InMemoryBookRepository : IBookRepository
{
	public void Add(Entities.Book entity)
	{
		lock (addingLock)
		{
			entity.Id = nextId;
			dictionary[nextId] = entity;
			nextId++;
		}
	}

	public Entities.Book? Get(long id)
	{
		return dictionary.GetValueOrDefault(id);
	}

	public IEnumerable<Entities.Book> GetAll()
	{
		return dictionary.Values;
	}

	public void Update(Entities.Book entity)
	{
		var existingEntity = Get(entity.Id);

		if (existingEntity is null)
			throw new EntityNotFoundException(entity.Id);

		existingEntity.Title = entity.Title;
		existingEntity.Author = entity.Author;
		existingEntity.DateOfPublication = entity.DateOfPublication;
	}

	public void Delete(long id)
	{
		var succeed = dictionary.TryRemove(id, out _);

		if (!succeed)
			throw new EntityNotFoundException(id);
	}

	private long nextId = 1;
	private readonly ConcurrentDictionary<long, Entities.Book> dictionary = new();
	private readonly Lock addingLock = new();
}
