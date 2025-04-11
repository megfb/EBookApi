using EBookApi.Entities.Abstract;

namespace EBookApi.Entities.Entities
{
    public class Publisher : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public List<Book>? Book { get; set; }
    }
}