using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace EntityLayer.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        
        public string?  UserName { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? ShortDescription { get; set; }
        public string? ImageUrl { get; set; }
        public string? Banner { get; set; }
        public string? icon { get; set; }
        public string? Role { get; set; }
        public string? Adress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Mail { get; set; }
        public string? InstagramAdress { get; set; }
        public string? FacebookAdress { get; set; }

    }
}
