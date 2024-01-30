using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.DTO;

namespace Dominio
{
    public class Leader : PersonDTO
    {
        public ClientDTO Client {  get; set; }
        public Leader() : base() {            
        }
        public Leader(string name, string lastName, string email, ClientDTO client) : base(name, lastName, email)
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
