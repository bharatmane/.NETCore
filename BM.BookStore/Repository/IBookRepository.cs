using System.Collections.Generic;
using System.Threading.Tasks;
using BM.BookStore.Models;

namespace BM.BookStore.Repository
{
    public interface IBookRepository
    {
        Task<int> AddNewBook(BookModel model);
        Task<List<BookModel>> GetAllBooks();
        Task<List<BookModel>> GetTopBooksAsync(int count);
        Task<BookModel> GetBookById(int id);
        List<BookModel> SearchBook(string title, string authorName);
        string GetAppName();
    }
}