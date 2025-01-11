namespace Dominio.Entity
{
    public class Developer 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Leader? Leader { get; set; }
        public int LeaderId { get; set; }
        public bool Active { get; set; }
        public bool Removed { get; set; }
         
    }
}
