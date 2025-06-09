using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryIcon { get; set; }
        public DateTime CategoryDate { get; set; }

        public bool CategoryStatus { get; set; }

        public List<Makale>? makales { get; set; }   
    }
}
