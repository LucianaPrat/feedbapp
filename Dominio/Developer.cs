using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Developer : Person
    {
        public Leader? Leader { get; set; } 
        public Developer() : base() {             
        }

        public Developer(string name,string lastName, string email, Leader leader) : base(name,lastName,email) 
        {
            Leader = leader;
        }
    }
}
