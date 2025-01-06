using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entity
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public bool Removed { get; set; }
        
        public ICollection<Leader> Leaders { get; set; }
    } 
}
