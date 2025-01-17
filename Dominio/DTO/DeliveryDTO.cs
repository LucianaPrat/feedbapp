using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTO
{
    public class DeliveryDTO
    {
        public int Id { get; set; }
        public PositionDTO Position { get; set; }
        public int PositionId { get; set; }
        public DateTime Date { get; set; }
        public EmailDTO Email { get; set; }
        public int EmailId { get; set; }
        public bool Removed { get; set; }

        public DeliveryDTO()
        {
        }
        public DeliveryDTO(PositionDTO position, EmailDTO email)
        {
            Date = DateTime.Now;
            Position = position;
            PositionId = position.Id;
            Email = email;
            EmailId = email.Id;
            Removed = false;
        }

    }
}
