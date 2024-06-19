using BookShop.Data;

namespace BookShop.Domain.Interfaces
{
    public interface IBookServices : ICRUD<Book>
    {
        public ValueTask<Book?> SearchAsync(string BookTitle);
    }
}
