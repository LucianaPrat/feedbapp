using Dominio.Accessors.Clients;
using Dominio.Accessors.Developers;
using Dominio.Accessors.Leaders;
using Dominio.DTO;
using Dominio.Entity;
using Microsoft.EntityFrameworkCore;

namespace Dominio.Accessors.Positions
{
    public class PositionAccessor : IPositionAccessor
    {
        private ApplicationDbContext _context;

        public PositionAccessor(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Exist(int id)
        {
            return _context.Positions.Where(c => c.Id == id).Count() > 0;
        }

        public List<PositionDTO> GetAll()
        {
            return _context.Positions.Where(c => !c.Removed)
                                .Include(c => c.Developer)
                                .Include(c => c.Developer.Leader)
                                .Include(c => c.Developer.Leader.Client)
                                 .Select(c => ConvertToDTO(c))
                                 .ToList();
        }

        public PositionDTO GetById(int id)
        {
            var client = _context.Positions.FirstOrDefault(c => c.Id == id);
            if (client == null)
            {
                throw new Exception("Not found client with id " + id);
            }
            return ConvertToDTO(client);
        }

        public void Save(PositionDTO positionDto)
        {
            var position = ConvertToEntity(positionDto);
            _context.Positions.Add(position);
            _context.SaveChanges();
        }

        public void Update(PositionDTO positionDto)
        {
            if (positionDto == null)
            {
                throw new ArgumentNullException();
            }
            var position = _context.Positions.FirstOrDefault(c => c.Id == positionDto.Id);
            if (position == null)
            {
                throw new Exception("Not found position with id " + positionDto.Id);
            }                        
            position.Removed = positionDto.Removed;
            _context.SaveChanges();
        }

        public void Delete(PositionDTO positionDto)
        {
            var position = _context.Leaders.FirstOrDefault(c => c.Id == positionDto.Id);
            if (position == null)
            {
                throw new Exception("Not found leader with id " + positionDto.Id);
            }
            position.Removed = true;
            _context.SaveChanges();
        }

        public static PositionDTO ConvertToDTO(Position position)
        {
            if (position == null)
            {
                throw new ArgumentNullException("position");
            }

            return new PositionDTO
            {
                Id = position.Id,
                Developer = position.Developer != null ? DeveloperAccessor.ConvertToDTO(position.Developer) : null,
                Description = position.Description,
                Leader = position.Developer.Leader != null ? LeaderAccessor.ConvertToDTO(position.Developer.Leader) : null,
                Client = position.Developer.Leader.Client != null ? ClientAccessor.ConvertToDTO(position.Developer.Leader.Client) : null,
                Recurrence = position.Recurrence,
                Removed = position.Removed
            };
        }

        public static Position ConvertToEntity(PositionDTO position)
        {
            if (position == null)
            {
                throw new ArgumentNullException("position");
            }
            return new Position
            {
                Id = position.Id,              
                DeveloperId = position.Developer.Id,
                Description = position.Description,
                Recurrence = position.Recurrence,
                Removed = position.Removed
            };
        }

        PositionDTO IAccessor<PositionDTO>.GetById(int id)
        {
            var position = _context.Positions.FirstOrDefault(c => c.Id == id);
            if (position == null)
            {
                throw new Exception("Not found position with id " + id);
            }
            return ConvertToDTO(position);
        }
    }
}
