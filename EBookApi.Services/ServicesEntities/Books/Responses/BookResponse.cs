namespace EBookApi.Services.ServicesEntities.Books.Responses;

public record BookResponse(int Id, string Name, decimal UnitPrice, string Description, int CategoryId, int AuthorId, int PublisherId );
