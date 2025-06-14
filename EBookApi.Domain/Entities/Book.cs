﻿using EBookApi.Domain.Entities.Common;


namespace EBookApi.Domain.Entities
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public decimal UnitPrice { get; set; }
        public string Description { get; set; } = default!;
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
        public Author? Author { get; set; }
        public int AuthorId { get; set; }
        public Publisher? Publisher { get; set; }
        public int PublisherId { get; set; }
    }
}
