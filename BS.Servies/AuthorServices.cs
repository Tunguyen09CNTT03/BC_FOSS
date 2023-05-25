namespace BS.Servies
{
    using BS.DataAccessLayer;
    using BS.Models;
    using BS.Repository;
    using System.Collections.Generic;

    public class AuthorServcies
    {
        private IAuthor db;

        public AuthorServcies()
        {
            db = new AuthorRepository(new BookDbContext());
        }

        public ICollection<Author> GetAll()
        {
            return db.GetAll();
        }

        public Author GetById(int id)
        {
            return db.GetById(id);
        }

        public int Insert(Author t)
        {
            db.Insert(t);
            return db.Save();
        }

        public int Update(Author t)
        {
            db.Update(t);
            return db.Save();
        }

        public int Delete(int id)
        {
            db.Delete(id);
            return db.Save();
        }

        public ICollection<Author> GetPartialAuthor()
        {
            return db.GetPartial();
        }

        public int CountAuthorAll()
        {
            return db.CountAll();
        }
        public IEnumerable<Author> ListAllPaging(string search, int page, int pageSize)
        {
            return db.ListAllPaging(search, page, pageSize);
        }
    }
}
