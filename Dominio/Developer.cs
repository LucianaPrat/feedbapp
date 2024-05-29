using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Dominio.DTO;

namespace Dominio
{
    public class Developer : PersonDTO, IValidation
    {
        public LeaderDTO? Leader { get; set; } 
        public Developer() : base() {             
        }

        public Developer(string name,string lastName, string email, LeaderDTO leader) : base(name,lastName,email) 
        {
            Leader = leader;
        }
        public virtual void IsValid()
        {
            base.IsValid();            
        }
    }
}
