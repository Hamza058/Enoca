using DataAccessLayer.Absract;
using DataAccessLayer.Repository;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFCompanyDal : GenericRepository<Company>, ICompanyDal
    {
    }
}
