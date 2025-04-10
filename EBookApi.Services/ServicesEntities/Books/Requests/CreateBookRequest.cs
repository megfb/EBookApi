namespace EBookApi.Services.ServicesEntities.Books.Requests;

public record CreateBookRequest(string Name, decimal UnitPrice, string Description, int CategoryId, int AuthorId, int PublisherId);

