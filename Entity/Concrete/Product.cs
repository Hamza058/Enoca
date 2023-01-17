using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public int ProductName { get; set; }
        public int Price { get; set; }
        public int CompanyId { get; set; }

        public Company Company { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
