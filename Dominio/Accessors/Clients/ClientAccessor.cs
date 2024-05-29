using Dominio.DTO;
using Dominio.Entity;

namespace Dominio.Accessors.Clients
{
    public class ClientAccessor : IClientAccessor
    {
        private ApplicationDbContext _context;

        public ClientAccessor(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Exist(int id)
        {
            var c = _context.Clients.Where(c => c.Id == id).Count();
            return c > 0;
        }

        public List<ClientDTO> GetAll()
        {
            return _context.Clients.Where(c => c.Active && !c.Removed)
                                   .ToList()
                                   .Select(c => ConvertToDTO(c))
                                   .ToList();
        }

        public ClientDTO GetById(int id)
        {
            var client = _context.Clients.FirstOrDefault(c => c.Id == id);
            if (client == null)
            {
                throw new Exception("Not found client with id " + id);
            }
            return ConvertToDTO(client);
        }

        public void Save(ClientDTO clientDto)
        {
            var client = ConvertToEntity(clientDto);
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        public void Update(ClientDTO clientDto)
        {
            if (clientDto == null)
            {
                throw new ArgumentNullException();
            }
            var client = _context.Clients.FirstOrDefault(c => c.Id == clientDto.Id);
            if (client == null)
            {
                throw new Exception("Not found client with id " + clientDto.Id);
            }

            client.Active = clientDto.Active;
            client.Name = clientDto.Name;
            client.Removed = clientDto.Removed;

            _context.SaveChanges();
        }

        public void Delete(ClientDTO clientDto)
        {
            var client = _context.Clients.FirstOrDefault(c => c.Id == clientDto.Id);
            if (client == null)
            {
                throw new Exception("Not found client with id " + clientDto.Id);
            }
            client.Removed = true;

            _context.SaveChanges();
        }

     public static   ClientDTO ConvertToDTO(Client client)
        {
            return new ClientDTO
            {
                Id = client.Id,
                Active = client.Active,
                Name = client.Name,
                Removed = client.Removed
            };
        }

        public static Client ConvertToEntity(ClientDTO client)
        {
            return new Entity.Client
            {
                Id = client.Id,
                Active = client.Active,
                Name = client.Name,
                Removed = client.Removed
            };
        }
    }
}
