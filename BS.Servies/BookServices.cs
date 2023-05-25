
namespace BS.Servies
{
    using BS.DataAccessLayer;
    using BS.Models;
    using BS.Repository;
    using System.Collections.Generic;
    public class BookServices
    {
        private IBook db;

        public BookServices()
        {
            db = new BookRepository(new BookDbContext());
        }

        public ICollection<Book> GetAll()
        {
            return db.GetAll();
        }

        public Book GetById(int id)
        {
            return db.GetById(id);
        }

        public int Insert(Book t)
        {
            db.Insert(t);
            return db.Save();
        }

        public int Update(Book t)
        {
            db.Update(t);
            return db.Save();
        }

        public int Delete(int id)
        {
            db.Delete(id);
            return db.Save();
        }

        public ICollection<Book> GetPartialBook()
        {
            return db.GetPartial();
        }

        public int CountAuthorAll()
        {
            return db.CountAll();
        }
        public IEnumerable<Book> ListAllPaging(string search, int page, int pageSize)
        {
            return db.ListAllPaging(search, page, pageSize);
        }
        
    }
}
