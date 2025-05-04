namespace ReprMinimalApi.DTO;

public sealed record Book(
	long Id,
	string Title,
	string Author,
	DateOnly DateOfPublication)
{
	public Book(Entities.Book entity)
		: this(
			Id: entity.Id,
			Title: entity.Title,
			Author: entity.Author,
			DateOfPublication: entity.DateOfPublication)
	{ }
}
