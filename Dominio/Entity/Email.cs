using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entity
{
    public class Email
    {
        public int Id { get; set; }
        public string Address { get; set; } = null!;
        public string Topic { get; set; } = null!;
        public string Body { get; set; } = null!;
    }
}
