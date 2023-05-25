using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BS.Repository;

namespace BS.Servies
{
    public class OrderDetailServices
    {
        private IOrderDetail db;
        public OrderDetailServices()
        {
            db = new OrderDetailRepository(new DataAccessLayer.BookDbContext());
        }
        public IEnumerable<BS.Models.OrderDetail> ListAllPaging(string search, int page, int pageSize)
        {
            return db.ListAllPaging(search, page, pageSize);
        }
    }
}
