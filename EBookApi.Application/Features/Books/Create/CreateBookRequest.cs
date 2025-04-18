namespace EBookApi.Application.Features.Books.Create;

public record CreateBookRequest(string Name, decimal UnitPrice, string Description, int CategoryId, int AuthorId, int PublisherId);

