
namespace Dominio.DTO
{
    public class LeaderDTO : PersonDTO
    {
        public int ClientId { get; set; }
        public ClientDTO Client { get; set; }
    }
}
