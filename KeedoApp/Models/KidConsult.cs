using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KeedoApp.Models
{
    public class KidConsult
    {
        public int id { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateConsultation { get; set; }
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
        public int IdUser { get; set; }
        public IEnumerable<User> Doctors { get; set; }
        public int IdKid { get; set; }
        public IEnumerable<Kid> Kids { get; set; }
    }
}