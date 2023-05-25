using BS.Models;
using BS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Servies
{
    public class OrderServices
    {
        private IOrder db;
        public OrderServices()
        {
            db = new OrderRepository(new DataAccessLayer.BookDbContext());
        }
        public void AddOrder(Order order, List<OrderDetail> listOrderDetail)
        {
            if (listOrderDetail != null)
            {
                db.AddOrder(order, listOrderDetail);
            }
            else
            {
                throw new Exception(" order null");
            }
        }
        public int CountOrder()
        {
            return db.CountAll();
        }

        public IEnumerable<Order> ListAllPaging(string search, int page, int pageSize)
        {
            return db.ListAllPaging(search, page, pageSize);
        }
    }
}
