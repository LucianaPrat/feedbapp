using Dominio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entity
{
    public class Delivery
    {
        public int Id { get; set; }
        public Position Position { get; set; }
        public int PositionId { get; set; }
        public DateTime Date { get; set; }
        public Email Email { get; set; }
        public int EmailId { get; set; }
        public bool Removed { get; set; }

        public Delivery(Position position, Email email)
        {
            Position = position;
            Email = email;
            Removed = false;
        }
        public Delivery()
        {
        }
    }
}
