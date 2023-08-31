using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Account
    {
        public string? name { get; set; }
        public string? accountId { get; set; }
        public string? customerRelation { get; set; }
        public int balance { get; set; }
    }
}
