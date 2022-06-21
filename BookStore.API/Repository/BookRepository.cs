using BookStore.API.Data;
using BookStore.API.Models;
using Microsoft.AspNetCore.JsonPatch;
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

            var boks = await _context.Books.Where(x => x.BookId == bookId).Select(x => new BookModel()
            {
                BookId = x.BookId,
                Desctription = x.Desctription,
                Title = x.Title,
            }).FirstOrDefaultAsync();

            return boks;
        }
        public async Task<int> AddBookAsync(BookModel bookModel)
        {
            var book = new Books()
            {
                Title = bookModel.Title,
                Desctription = bookModel.Desctription,
            };
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return book.BookId;
        }
        public async Task UpdateBookAsync(int bookId, BookModel bookModel)
        {

            var book = new Books()
            {
                BookId = bookId,
                Title = bookModel.Title,
                Desctription = bookModel.Desctription,
            };
            _context.Books.Update(book);
            await _context.SaveChangesAsync();

        }
        public async Task UpdateBookPatchAsync(int bookId, JsonPatchDocument bookModel)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book != null)
            {
                bookModel.ApplyTo(book);
                await _context.SaveChangesAsync();
            }

        }
    }
}
