using Dominio.DTO;
using Dominio.Entity;

<<<<<<<< HEAD:Dominio/Accessors/Clients/ClientAccessor.cs
namespace Dominio.Accessors.Clients
========
namespace Dominio.Accessors.Client
>>>>>>>> c7611e51e40c18115851cd6693e74ed16c6de037:Dominio/Accessors/Client/ClientAccessor.cs
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

<<<<<<<< HEAD:Dominio/Accessors/Clients/ClientAccessor.cs
     public static   ClientDTO ConvertToDTO(Client client)
========
        ClientDTO ConvertToDTO(Entity.Client client)
>>>>>>>> c7611e51e40c18115851cd6693e74ed16c6de037:Dominio/Accessors/Client/ClientAccessor.cs
        {
            return new ClientDTO
            {
                Id = client.Id,
                Active = client.Active,
                Name = client.Name,
                Removed = client.Removed
            };
        }

<<<<<<<< HEAD:Dominio/Accessors/Clients/ClientAccessor.cs
        public static Client ConvertToEntity(ClientDTO client)
========
        Entity.Client ConvertToEntity(ClientDTO client)
>>>>>>>> c7611e51e40c18115851cd6693e74ed16c6de037:Dominio/Accessors/Client/ClientAccessor.cs
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
