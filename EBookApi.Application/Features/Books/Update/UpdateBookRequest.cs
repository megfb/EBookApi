namespace EBookApi.Application.Features.Books.Update;

public record UpdateBookRequest(int Id, string Name, decimal UnitPrice, string Description, int CategoryId, int AuthorId, int PublisherId);
