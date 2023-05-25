using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BS.DataAccessLayer;
using BS.Models;
using PagedList;

namespace BS.Repository
{
    public class OrderRepository : IOrder
    {
        private BookDbContext dBContext;

        public OrderRepository(BookDbContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public void AddOrder(Order order, List<OrderDetail> listOrderDetail)
        {
            using (DbContextTransaction transaction = dBContext.Database.BeginTransaction())
            {
                try
                {
                    var AddOrder = dBContext.Orders.Add(order);
                    int orderId = AddOrder.OrderId;
                    foreach (var item in listOrderDetail)
                    {
                        item.OrderId = orderId;
                        Book book = dBContext.Books.Find(item.BookId);
                        int orderQuantity = item.Quantity;
                        if (book.Quantity >= orderQuantity)
                        {
                            book.Quantity -= orderQuantity;  
                            dBContext.OrderDetails.Add(item);
                            dBContext.Entry(book).State = EntityState.Modified;
                        }
                        else
                        {
                            throw new Exception(book.Title +"sách trong kho không đủ số lượng.");
                        }
                    }
                    dBContext.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {

                    transaction.Rollback();
                }
            }
        }

        public int CountAll()
        {
            return dBContext.Orders.Count();
        }


        public IEnumerable<Order> ListAllPaging(string search, int page, int pageSize)
        {
            IQueryable<Order> model = dBContext.Orders;
            if (!string.IsNullOrEmpty(search))
            {
                model = model.Where(x => x.User.UserName.Contains(search));
            }
            return model.OrderBy(x => x.OrderId).ToPagedList(page, pageSize);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetById(object id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Order> GetPartial()
        {
            throw new NotImplementedException();
        }

        public void Insert(Order t)
        {
            throw new NotImplementedException();
        }

        

        public int Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Order t)
        {
            throw new NotImplementedException();
        }
    }
}
