using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Deliveries
    {
        private static int UltimoId { get; set; }
        public int Id { get; set; }
        public Position Position { get; set; }
        public DateTime Date { get; set; }        

        public Deliveries() 
        {
        }

        public Deliveries(DateTime date, Position position)
        {
            Id = UltimoId++;
            Date = date;
            Position = position;
        }
    }
}
