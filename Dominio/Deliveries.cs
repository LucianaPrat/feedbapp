using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.DTO;

namespace Dominio
{
    public class Deliveries
    {
        private static int UltimoId { get; set; }
        public int Id { get; set; }
        public Position Position { get; set; }
        public DateTime Date { get; set; }    
        
        public EmailDTO Email { get; set; }

        public Deliveries() 
        {
        }

        public Deliveries(Position position, EmailDTO email)
        {
            Id = UltimoId++;
            Date = DateTime.Now;
            Position = position;
            Email = email;
        }
    }
}
