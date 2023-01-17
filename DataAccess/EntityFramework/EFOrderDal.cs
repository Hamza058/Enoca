using DataAccess.Concrete;
using DataAccessLayer.Absract;
using DataAccessLayer.Repository;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFOrderDal : GenericRepository<Order>, IOrderDal
    {
        public List<Order> GetListWithProduct()
        {
            using (var c = new Context())
            {
                return c.Orders.Include(x => x.Product).ToList();
            }
        }
    }
}
