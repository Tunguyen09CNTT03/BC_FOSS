
namespace BS.Servies
{
    using System.Collections.Generic;
    using BS.DataAccessLayer;
    using BS.Models;
    using BS.Repository;
    public class PublisherServices
    {
        private IPublisher db;
        public PublisherServices()
        {
            db = new PublisherRepository(new BookDbContext());
        }

        public ICollection<Publisher> GetAll()
        {
            return db.GetAll();
        }

        public Publisher GetById(int id)
        {
            return db.GetById(id);
        }
        public int Insert(Publisher t)
        {
            db.Insert(t);
            return db.Save();
        }
        public int Update(Publisher t)
        {
            db.Update(t);
            return db.Save();
        }
        public int Delete(int id)
        {
            db.Delete(id);
            return db.Save();
        }
        public ICollection<Publisher> GetPartialPublisher()
        {
            return db.GetPartial();
        }
        public int CountPublisherAll()
        {
            return db.CountAll();
        }
        public IEnumerable<Publisher> ListAllPaging(string search, int page, int pageSize)
        {
            return db.ListAllPaging(search, page, pageSize);
        }
    }

}
