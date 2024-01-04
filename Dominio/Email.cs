using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Email
    {
        private static int UltimoId { get; set; } = 1;
        public int Id { get; set; }
        public Leader Leader {  get; set; }
        public string Select { get; set; }
        public string Body { get; set; }
        public Email() { }
        public Email(Leader leader,string select, string body) { 
            Leader = leader;
            Select = select;
            Body = body;
        }
    }
}
