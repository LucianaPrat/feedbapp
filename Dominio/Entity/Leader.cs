namespace Dominio.Entity
{
    public class Leader  
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; } 
        public bool Active { get; set; }
        public bool Removed { get; set; }
    }
}
