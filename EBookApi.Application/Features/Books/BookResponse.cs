namespace EBookApi.Application.Features.Books;

public record BookResponse(int Id, string Name, decimal UnitPrice, string Description, int CategoryId, int AuthorId, int PublisherId);
