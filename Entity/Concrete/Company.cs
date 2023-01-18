using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public bool Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}
