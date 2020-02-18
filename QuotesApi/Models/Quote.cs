using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuotesApi.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Author { get; set; }
        public String Description { get; set; }
    }
}