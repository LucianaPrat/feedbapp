using Dominio.Accessors.Clients;
using Dominio.DTO;
using Dominio.Entity;
using Microsoft.EntityFrameworkCore;

namespace Dominio.Accessors.Leaders
{
    public class LeaderAccessor : ILeaderAccessor
    {
        private ApplicationDbContext _context;

        public LeaderAccessor(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Exist(int id)
        {
            return _context.Leaders.Where(c => c.Id == id).Count() > 0;
        }

        public List<LeaderDTO> GetAll()
        {
            return _context.Leaders.Where(c => c.Active && !c.Removed)
                                    .Include( c=> c.Client)
                                   .ToList()
                                   .Select(c => ConvertToDTO(c))
                                   .ToList();
        }

        public LeaderDTO GetById(int id)
        {
            var client = _context.Leaders.FirstOrDefault(c => c.Id == id);
            if (client == null)
            {
                throw new Exception("Not found client with id " + id);
            }
            return ConvertToDTO(client);
        }

        public void Save(LeaderDTO leaderDto)
        {
            var leader = ConvertToEntity(leaderDto);
            _context.Leaders.Add(leader);
            _context.SaveChanges();
        }

        public void Update(LeaderDTO leaderDto)
        {
            if (leaderDto == null)
            {
                throw new ArgumentNullException();
            }
            var leader = _context.Leaders.FirstOrDefault(c => c.Id == leaderDto.Id);
            if (leader == null)
            {
                throw new Exception("Not found leader with id " + leaderDto.Id);
            }

            leader.Active = leaderDto.Active;
            leader.Name = leaderDto.Name;
            leader.LastName = leaderDto.LastName;
            leader.Email = leaderDto.Email;
            leader.Active = leaderDto.Active;
            leader.Removed = leaderDto.Removed;
            leader.ClientId = leaderDto.ClientId;

            _context.SaveChanges();
        }

        public void Delete(LeaderDTO leaderDto)
        {
            var leader = _context.Leaders.FirstOrDefault(c => c.Id == leaderDto.Id);
            if (leader == null)
            {
                throw new Exception("Not found leader with id " + leaderDto.Id);
            }
            leader.Removed = true;

            _context.SaveChanges();
        }

        public static LeaderDTO ConvertToDTO(Leader leader)
        {
            return new LeaderDTO
            {
                Id = leader.Id,
                Active = leader.Active,
                Name = leader.Name,
                LastName = leader.LastName,
                Email = leader.Email,
                ClientId = leader.ClientId,
                Client = ClientAccessor.ConvertToDTO(leader.Client),
                Removed = leader.Removed
            };
        }

        public static Leader ConvertToEntity(LeaderDTO leader)
        {
            return new Leader
            {
                Id = leader.Id,
                Name = leader.Name,
                LastName = leader.LastName,
                Email = leader.Email,
                ClientId = leader.ClientId,
                Active = leader.Active,
                Removed = leader.Removed
            };
        }
    }
}
