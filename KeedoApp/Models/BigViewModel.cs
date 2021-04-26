using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeedoApp.Models
{
    public class BigViewModel
    {
        public IEnumerable<Post> Post { get; set; }
        public Comment Comment { get; set; }

    }
}