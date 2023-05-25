
namespace BS.Repository
{
    using BS.DataAccessLayer;
    using BS.Models;
    using PagedList;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PublisherRepository : IPublisher
    {
        private BookDbContext dBContext;
        public PublisherRepository(BookDbContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public ICollection<Publisher> GetAll()
        {
            return dBContext.Publishers.ToList();
        }

        public Publisher GetById(object id)
        {
            if (id != null && Int32.TryParse(id.ToString(), out int publisherId))
            {
                return dBContext.Publishers.FirstOrDefault(x => x.PubId == publisherId);
            }

            return null; // or handle the case when id is null or not convertible
        }


        public void Insert(Publisher t)
        {
            dBContext.Publishers.Add(t);
        }

        public void Update(Publisher t)
        {
            dBContext.Entry<Publisher>(t).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int id)
        {
            var publisher = dBContext.Publishers.Where(x => x.PubId == id).SingleOrDefault();
            dBContext.Publishers.Remove(publisher);
        }

        public int Save()
        {
            return dBContext.SaveChanges();
        }

        public ICollection<Publisher> GetPartial()
        {
            return dBContext.Publishers.Take(6).ToList();
        }

        public int CountAll()
        {
            int result = dBContext.Publishers.ToList().Count;
            return result;
        }

        public IEnumerable<Publisher> ListAllPaging(string search, int page, int pageSize)
        {
            IQueryable<Publisher> model = dBContext.Publishers;
            if (!string.IsNullOrEmpty(search))
            {
                model = model.Where(x => x.Name.Contains(search));
            }
            return model.OrderBy(x => x.PubId).ToPagedList(page, pageSize);
        }
    }
}
