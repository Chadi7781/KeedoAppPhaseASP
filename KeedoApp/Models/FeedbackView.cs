using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeedoApp.Models
{
    public class FeedbackView
    {


        public  Feedback feedback { get; set; }
        public IEnumerable<Question> questions { get; set; }
        public Response response { get; set; }



    }
}