using BS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Repository
{
    public interface IOrder:IRepository<Order>
    {
        void AddOrder(Order order, List<OrderDetail> listOrderDetail);
    }
}
