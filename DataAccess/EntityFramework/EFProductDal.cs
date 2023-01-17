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
    public class EFProductDal : GenericRepository<Product>, IProductDal
    {
        public List<Product> GetListWithCompany()
        {
            using (var c = new Context())
            {
                return c.Products.Include(x=>x.Company).ToList();
            }
        }
    }
}
