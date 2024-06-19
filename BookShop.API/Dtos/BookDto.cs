﻿namespace BookShop.API.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}