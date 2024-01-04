using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Leader : Person
    {
        public Client Client {  get; set; }
        public Leader() : base() {            
        }
        public Leader(string name, string lastName, string email, Client client) : base(name, lastName, email)
        {            
            Name = name;
            LastName = lastName;
            Email = email;
            Client = client;
            Active = true;
            Removed = false;
        }
    }
}
