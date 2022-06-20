using BookStore.API.Models;

namespace BookStore.API.Repository
{
    public interface IBookRepository
    {
        Task<int> AddBookAsync(BookModel bookModel);
        Task<List<BookModel>> GetAllBooksAsync();
        Task<BookModel> GetBookByIdAsync(int bookId);
        Task UpdateBookAsync(int bookId, BookModel bookModel);
    }
}
