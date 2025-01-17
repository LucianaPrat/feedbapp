
using Dominio.Entity;

namespace Dominio.DTO
{
    public class LeaderDTO : PersonDTO
    {
        public int ClientId { get; set; }
        public ClientDTO Client { get; set; }
        public override void IsValid()
        {
            // Call the base validation
            base.IsValid();

            // Additional validation for DeveloperDTO
            if (ClientId <= 0)
            {
                throw new Exception("The LeaderId must be greater than 0.");
            }
            if (Client == null)
            {
                throw new Exception("A Leader is required for the Developer.");
            }
        }
    }
}
