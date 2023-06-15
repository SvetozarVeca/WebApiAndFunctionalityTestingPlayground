using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ContactEntry
    {
        public string firstName { get;set; }
        public string lastName { get; set; }
        public string dateOfBirth { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string streetAdd1 { get; set; }
        public string streetAdd2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
    }
}
