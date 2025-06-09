using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class SubScribe
    {
        [Key]
        public int SubID { get; set; }
        public string? SubEmail { get; set; }
        public DateTime SubDate{ get; set; }
        public bool SubStatus{ get; set; }
    }
}
