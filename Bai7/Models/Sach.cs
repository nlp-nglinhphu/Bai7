using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai7.Models
{
    public class Sach
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public string Content { get; set; }
        public string AuthorName { get; set; }
        public decimal Price { get; set; }
    }
}