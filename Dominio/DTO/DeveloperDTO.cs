using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Dominio.DTO;
using Dominio.Entity;

namespace Dominio.DTO
{
    public class DeveloperDTO : PersonDTO 
    {         
        public int LeaderId { get; set; }
        public LeaderDTO? Leader { get; set; }
        public override void IsValid()
        {
            // Call the base validation
            base.IsValid();

            // Additional validation for DeveloperDTO
            if (LeaderId <= 0)
            {
                throw new Exception("The LeaderId must be greater than 0.");
            }
            //if (Leader == null)
            //{
            //    throw new Exception("A Leader is required for the Developer.");
            //}
        }

    }
   

}
