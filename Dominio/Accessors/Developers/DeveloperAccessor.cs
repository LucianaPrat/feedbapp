using Dominio.Accessors.Leaders;
using Dominio.Accessors.Positions;
using Dominio.DTO;
using Dominio.Entity;
using Microsoft.EntityFrameworkCore;

namespace Dominio.Accessors.Developers
{
    public class DeveloperAccessor : IDeveloperAccessor
    {
        private ApplicationDbContext _context;

        public DeveloperAccessor(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Exist(int id)
        {
            return _context.Developers.Where(c => c.Id == id).Count() > 0;
        }

        public List<DeveloperDTO> GetAll()
        {
            return _context.Developers.Where(c => c.Active && !c.Removed)
                .Include(c=>c.Leader)
                                   .ToList()
                                             .Select(c => ConvertToDTO(c))
                                   .ToList();
        }

        public DeveloperDTO GetById(int id)
        {
            var developer = _context.Developers.FirstOrDefault(c => c.Id == id);
            if (developer == null)
            {
                throw new Exception("Not found developer with id " + id);
            }
            return ConvertToDTO(developer);
        }

        public void Save(DeveloperDTO developerDTO)
        {
            var developer = ConvertToEntity(developerDTO);
            _context.Developers.Add(developer);
            _context.SaveChanges();
        }

        public void Update(DeveloperDTO developerDto)
        {
            if (developerDto == null)
            {
                throw new ArgumentNullException();
            }
            var developer = _context.Developers.FirstOrDefault(c => c.Id == developerDto.Id);
            if (developer == null)
            {
                throw new Exception("Not found developer with id " + developerDto.Id);
            }

            developer.Active = developerDto.Active;
            developer.Name = developerDto.Name;
            developer.LastName = developerDto.LastName;
            developer.Email = developerDto.Email;
            developer.Active = developerDto.Active;
            developer.Removed = developerDto.Removed;

            _context.SaveChanges();
        }

        public void Delete(DeveloperDTO developerDto)
        {
            var developer = _context.Developers.FirstOrDefault(c => c.Id == developerDto.Id);
            if (developer == null)
            {
                throw new Exception("Not found developer with id " + developerDto.Id);
            }
            developer.Removed = true;

            _context.SaveChanges();
        }


        public static DeveloperDTO ConvertToDTO(Developer developer)
        {
            if (developer == null)
            {
                throw new ArgumentNullException("developer");
            }

            return new DeveloperDTO
            {
                Id = developer.Id,
                Name = developer.Name,
                LastName = developer.LastName,
                Email = developer.Email,
                Leader = developer.Leader!=null? LeaderAccessor.ConvertToDTO(developer.Leader):null,
                Active = developer.Active,
                Removed = developer.Removed
            };
        }


        public static Developer ConvertToEntity(DeveloperDTO developer)
        {
            if (developer == null)
            {
                throw new ArgumentNullException("developer");
            }

            return new Developer
            {
                Id = developer.Id,
                Name = developer.Name,
                LastName = developer.LastName,
                Email = developer.Email,
                LeaderId = developer.LeaderId,
                Active = developer.Active,
                Removed = developer.Removed
            };
        }
    }
}
