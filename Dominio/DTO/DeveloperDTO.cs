using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Dominio.DTO;

namespace Dominio.DTO
{
    public class DeveloperDTO : PersonDTO 
    {         
        public int LeaderId { get; set; }
        public LeaderDTO? Leader { get; set; } 
    }
}
