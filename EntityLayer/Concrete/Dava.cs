using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Dava
    {
        [Key]
        public int DavaID { get; set; }
        public string? DavaName { get; set; }
        public string? DavaIcon { get; set; }
        public string? DavaDescription { get; set; }
        public DateTime DavaDate { get; set; }

        public bool DavaStatus { get; set; }
    }
}
