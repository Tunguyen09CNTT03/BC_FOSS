using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BS.DataAccessLayer;
using BS.Models;
using Microsoft.AspNet.Identity;

namespace BS.Repository
{
    public class UserRepository : IUserRepository
    {
        private BookDbContext dBContext;

        public UserRepository(BookDbContext dBContext)
        {
            this.dBContext = dBContext;
        }


        public int CountAll()
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<ApplicationUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public ApplicationUser GetById(object id)
        {
            var i = Convert.ToString(id.ToString());
            return dBContext.Users.Where(x => x.Id == i).SingleOrDefault();
           
        }

        public ICollection<ApplicationUser> GetPartial()
        {
            throw new NotImplementedException();
        }

        public void Insert(ApplicationUser t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> ListAllPaging(string searh, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            return dBContext.SaveChanges();
        }

        public void Update(ApplicationUser t)
        {
            //dBContext.Entry<IUser>(t).State = System.Data.Entity.EntityState.Modified;
            dBContext.Set<ApplicationUser>().AddOrUpdate(t);
        }
    }
}
