using AutoMapper;
using BookStore.API.Data;
using BookStore.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repository
{
    public class BookRepository : IBookRepository
    {
        public BookRepository(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public BookStoreContext _context { get; }
        public IMapper _mapper { get; }

        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            var books = await _context.Books.ToListAsync();
            return _mapper.Map<List<BookModel>>(books);
        }
        public async Task<BookModel> GetBookByIdAsync(int bookId)
        {
            var book = await _context.Books.FindAsync(bookId);
            return _mapper.Map<BookModel>(book);
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
        public async Task DeleteBookAsync(int id)
        {
            var book = new Books()
            {
                BookId = id,
            };
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

        }
    }
}
