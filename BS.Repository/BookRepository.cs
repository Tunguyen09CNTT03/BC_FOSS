

namespace BS.Repository
{
    using BS.DataAccessLayer;
    using BS.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using PagedList;

    public class BookRepository : IBook
    {
        private BookDbContext dBContext;

        public BookRepository(BookDbContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public ICollection<Book> GetAll()
        {
            return dBContext.Books.ToList();
        }

        public Book GetById(object id)
        {
            var i = Convert.ToInt16(id.ToString());
            return dBContext.Books.Where(x => x.BookId == i).SingleOrDefault();
        }

        public void Insert(Book t)
        {
            dBContext.Books.Add(t);
        }

        public void Update(Book t)
        {
            dBContext.Entry<Book>(t).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int id)
        {
            var book = dBContext.Books.SingleOrDefault(x => x.BookId == id);
            dBContext.Books.Remove(book);
        }

        public int Save()
        {
            return dBContext.SaveChanges();
        }

        public ICollection<Book> GetPartial()
        {
            return dBContext.Books.Take(4).ToList();
        }

        public int CountAll()
        {
            return dBContext.Books.ToList().Count;
        }

        public IEnumerable<Book> ListAllPaging(string search, int page, int pageSize)
        {
            IQueryable<Book> model = dBContext.Books;
            if (!string.IsNullOrEmpty(search))
            {
                model = model.Where(x => x.Category.CateName.Contains(search) || x.Publisher.Name.Contains(search) || x.Author.AuthorName.Contains(search) || x.Title.Contains(search));
            }
            return model.OrderBy(x => x.BookId).ToPagedList(page, pageSize);
        }

    }
}
