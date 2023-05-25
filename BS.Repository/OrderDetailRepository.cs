using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BS.DataAccessLayer;
using BS.Models;
using PagedList;

namespace BS.Repository
{
    public class OrderDetailRepository : IOrderDetail
    {
        private BookDbContext dBContext;

        public OrderDetailRepository(BookDbContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public IEnumerable<OrderDetail> ListAllPaging(string search, int page, int pageSize)
        {
            IQueryable<OrderDetail> model = dBContext.OrderDetails;
            if (!string.IsNullOrEmpty(search))
            {
                model = model.Where(x => x.Order.User.UserName.Contains(search));
            }
            return model.OrderBy(x => x.OrderId).ToPagedList(page, pageSize);
        }


        public int CountAll()
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<OrderDetail> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderDetail GetById(object id)
        {
            throw new NotImplementedException();
        }

        public ICollection<OrderDetail> GetPartial()
        {
            throw new NotImplementedException();
        }

        public void Insert(OrderDetail t)
        {
            throw new NotImplementedException();
        }

        

        public int Save()
        {
            throw new NotImplementedException();
        }

        public void Update(OrderDetail t)
        {
            throw new NotImplementedException();
        }
    }
}
