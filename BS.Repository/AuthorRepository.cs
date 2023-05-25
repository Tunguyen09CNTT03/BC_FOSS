
namespace BS.Repository
{
    using BS.DataAccessLayer;
    using BS.Models;
    using PagedList;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AuthorRepository : IAuthor
    {
        private BookDbContext dBContext;

        public AuthorRepository(BookDbContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public ICollection<Author> GetAll()
        {
            return dBContext.Authors.ToList();
        }

        public Author GetById(object id)
        {
            if (id != null && int.TryParse(id.ToString(), out int authorId))
            {
                return dBContext.Authors.FirstOrDefault(x => x.AuthorId == authorId);
            }

            return null; // or handle the case when id is null or not convertible
        }


        public void Insert(Author t)
        {
            dBContext.Authors.Add(t);
        }

        public void Update(Author t)
        {
            dBContext.Entry<Author>(t).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int id)
        {
            var author = dBContext.Authors.Where(x => x.AuthorId == id).SingleOrDefault();
        }

        public int Save()
        {
            return dBContext.SaveChanges();
        }

        public ICollection<Author> GetPartial()
        {
            return dBContext.Authors.Take(6).ToList();
        }

        public int CountAll()
        {
            var authors = dBContext.Authors.ToList();
            int result = authors.Count;
            return result;
        }

        public IEnumerable<Author> ListAllPaging(string search, int page, int pageSize)
        {
            IQueryable<Author> model = dBContext.Authors;
            if (!string.IsNullOrEmpty(search))
            {
                model = model.Where(x => x.AuthorName.Contains(search));
            }
            return model.OrderBy(x => x.AuthorId).ToPagedList(page, pageSize);
        }
    }
}
