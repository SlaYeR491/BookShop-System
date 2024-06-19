﻿using BookShop.Data;
using BookShop.Domain.Interfaces;

namespace BookShop.Application.Services
{
    public class BookServices(IRepository<Book> _repo) : IBookServices
    {
        public async ValueTask<Book?> AddAsync(Book book)
        {
            var Exist = await ExistenceAsync(book);
            if (Exist != null)
                return null;
            await _repo.CreateAsync(book);
            await _repo.SaveChangesAsync();
            return book;
        }

        public async ValueTask<Book?> ExistenceAsync(Book? book)
        {
            if (book == null)
                return null;
            return await _repo.ReadAsync(a => a.Code == book.Code);
        }

        public async ValueTask<Book?> DeleteAsync(object bookId)
        {
            var Exist = await _repo.ReadAsync(bookId);
            if (Exist == null)
                return null;
            await _repo.DeleteAsync(bookId);
            await _repo.SaveChangesAsync();
            return Exist;
        }

        public async ValueTask<IEnumerable<Book>?> ReadAllAsync()
        {
            return await _repo.ReadAllAsync();
        }

        public async ValueTask<Book?> ReadAsync(object bookId)
        {
            return await _repo.ReadAsync(bookId);
        }

        public async ValueTask<Book?> UpdateAsync(Book book)
        {
            var Exist = await ExistenceAsync(book);
            if (Exist == null)
                return null;
            book.Id = Exist.Id;
            _repo.Update(book);
            await _repo.SaveChangesAsync();
            return book;
        }

        public async ValueTask<Book?> SearchAsync(string BookTitle)
        {
            return await _repo.ReadAsync(a => a.Title.ToLower()==BookTitle.ToLower());
        }
    }
}