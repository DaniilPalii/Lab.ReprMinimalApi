using System.Collections.Concurrent;
using ReprMinimalApi.Exceptions;

namespace ReprMinimalApi.Repositories;

public sealed class InMemoryBookRepository : IBookRepository
{
	public InMemoryBookRepository()
	{
		Add(new() { Title = "Example Book 1", Author = "Author 1", DateOfPublication = DateOnly.FromDateTime(DateTime.Now) });
		Add(new() { Title = "Example Book 2", Author = "Author 2", DateOfPublication = DateOnly.FromDateTime(DateTime.Now) });
		Add(new() { Title = "Example Book 3", Author = "Author 3", DateOfPublication = DateOnly.FromDateTime(DateTime.Now) });
	}
	
	public void Add(Entities.Book entity)
	{
		lock (addingLock)
		{
			entity.Id = nextId;
			dictionary[nextId] = entity;
			nextId++;
		}
	}

	public Entities.Book? Get(Id id)
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

	public void Delete(Id id)
	{
		var succeed = dictionary.TryRemove(id, out _);

		if (!succeed)
			throw new EntityNotFoundException(id);
	}

	private Id nextId = 1;
	private readonly ConcurrentDictionary<Id, Entities.Book> dictionary = new();
	private readonly Lock addingLock = new();
}
