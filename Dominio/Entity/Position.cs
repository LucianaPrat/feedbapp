using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entity
{
    public class Position
    {
        public int Id { get; set; }
        public Developer Developer { get; set; }
        public int DeveloperId { get; set; }
        public string Description { get; set; }
        public Recurrence Recurrence { get; set; }
        public bool Removed { get; set; }   
    }
}
