using EBookApi.Domain.Entities.Common;


namespace EBookApi.Domain.Entities
{
    public class Author : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Biography { get; set; } = default!;
        public List<Book>? Book { get; set; }
    }
}