using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Makale
    {
        [Key]
        public int MakaleID { get; set; }
        public string? MakaleTitle { get; set; }

        public string? MakaleContent { get; set; }
        public string? MakaleImage { get; set; }
        public DateTime MakaleCreateDate { get; set; }
        public bool MakaleStatus { get; set; }


        public int CategoryID { get; set; }
        public Category? category { get; set; }
    }
}
