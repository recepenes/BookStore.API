using BookStore.API.Data;
using BookStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repository
{
    public class BookRepository : IBookRepository
    {
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public BookStoreContext _context { get; }

        public async Task<List<BookModel>> GetAllBooksAsync()
        {

            var records = await _context.Books.Select(x => new BookModel()
            {
                BookId = x.BookId,
                Desctription = x.Desctription,
                Title = x.Title,
            }).ToListAsync();

            return records;
        }
        public async Task<BookModel> GetBookByIdAsync(int bookId)
        {

            var records = await _context.Books.Where(x => x.BookId == bookId).Select(x => new BookModel()
            {
                BookId = x.BookId,
                Desctription = x.Desctription,
                Title = x.Title,
            }).FirstOrDefaultAsync();

            return records;
        }
    }
}
