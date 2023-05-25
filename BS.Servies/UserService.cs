using BS.DataAccessLayer;
using BS.Models;
using BS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Servies
{
    public class UserService
    {
        private IUserRepository db;
        public UserService()
        {
            db = new UserRepository(new BookDbContext());
        }
        public ICollection<ApplicationUser> GetAll()
        {
            return db.GetAll();
        }

        public ApplicationUser GetById(string id)
        {
            return db.GetById(id);
        }

        public int Insert(ApplicationUser t)
        {
            db.Insert(t);
            return db.Save();
        }

        public int Update(ApplicationUser t)
        {
            db.Update(t);
            return db.Save();
        }

        public int Delete(int id)
        {
            db.Delete(id);
            return db.Save();
        }

        public ICollection<ApplicationUser> GetPartialApplicationUser()
        {
            return db.GetPartial();
        }

        public int CountApplicationUserAll()
        {
            return db.CountAll();
        }
        public IEnumerable<ApplicationUser> ListAllPaging(string search, int page, int pageSize)
        {
            return db.ListAllPaging(search, page, pageSize);
        }
    }
}
