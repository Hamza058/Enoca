using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public int CompanyId { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
