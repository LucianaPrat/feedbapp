﻿using Dominio.Accessors.Clients;
using Dominio.DTO;
using Dominio.Entity;

namespace Dominio.Accessors.Admins
{
    public class AdminAccessor : IAdminAccessor
    {
        private ApplicationDbContext _context;

        public AdminAccessor(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Exist(int id)
        {
            var c = _context.Admins.Where(c => c.Id == id).Count();
            return c > 0;
        }

        public List<AdminDTO> GetAll()
        {
            return _context.Admins.Where(c => c.Active && !c.Removed)
                                   .ToList()
                                   .Select(c => ConvertToDTO(c))
                                   .ToList();
        }

        public AdminDTO GetById(int id)
        {
            var admin = _context.Admins.FirstOrDefault(c => c.Id == id);
            if (admin == null)
            {
                throw new Exception("Not found admin with id " + id);
            }
            return ConvertToDTO(admin);
        }

        public AdminDTO Save(AdminDTO adminDto)
        {
            var admin = ConvertToEntity(adminDto);
            _context.Admins.Add(admin);
            _context.SaveChanges();
            AdminDTO a = ConvertToDTO(admin);
            return a;
        }

        public void Update(AdminDTO adminDto)
        {
            if (adminDto == null)
            {
                throw new ArgumentNullException();
            }
            var admin = _context.Admins.FirstOrDefault(a => a.Id == adminDto.Id);
            if (admin == null)
            {
                throw new Exception("Not found client with id " + adminDto.Id);
            }
            admin.Active = adminDto.Active;
            admin.Name = adminDto.Name;
            admin.Removed = adminDto.Removed;
            _context.SaveChanges();
        }

        public void Delete(AdminDTO adminDto)
        {
            var admin = _context.Admins.FirstOrDefault(c => c.Id == adminDto.Id);
            if (admin == null)
            {
                throw new Exception("Not found admin with id " + adminDto.Id);
            }
            admin.Removed = true;

            _context.SaveChanges();
        }

         public static AdminDTO ConvertToDTO(Entity.Admin admin)
        {
            if (admin == null)
            {
                throw new ArgumentNullException("admin");
            }

            return new AdminDTO
            {
                Id = admin.Id,
                Name = admin.Name,
                Email = admin.Email,
                Password = admin.Password,
                Active = admin.Active,
                Removed = admin.Removed
            };
        }

        public static Entity.Admin ConvertToEntity(AdminDTO admin)
        {
            if (admin == null)
            {
                throw new ArgumentNullException("admin");
            }

            return new Entity.Admin
            {
                Id = admin.Id,
                Name = admin.Name,
                Email = admin.Email,
                Password = admin.Password,
                Active = admin.Active,                
                Removed = admin.Removed
            };
        }
    }
}
