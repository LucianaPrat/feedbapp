using Dominio.DTO;
using Dominio.Entity;
using Dominio.Migrations;
using System.Net;
using System.Net.Mail;

namespace Dominio.Accessors.Email
{
    public class EmailAccessor : IEmailAccessor
    {
        private ApplicationDbContext _context;

        public EmailAccessor(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Exist(int id)
        {
            var c = _context.Emails.Where(c => c.Id == id).Count();
            return c > 0;
        }

        public List<EmailDTO> GetAll()
        {
            return _context.Emails.ToList()
                                   .Select(c => ConvertToDTO(c))
                                   .ToList();
        }

        public EmailDTO GetById(int id)
        {
            var email = _context.Emails.FirstOrDefault(c => c.Id == id);
            if (email == null)
            {
                throw new Exception("Not found client with id " + id);
            }
            return ConvertToDTO(email);
        }

        public EmailDTO Save(EmailDTO emailDto)
        {
            var email = ConvertToEntity(emailDto);
            _context.Emails.Add(email);
            _context.SaveChanges();
            EmailDTO e = ConvertToDTO(email);
            return e;
        }

        public void Update(EmailDTO emailDto)
        {
            if (emailDto == null)
            {
                throw new ArgumentNullException();
            }
            var email = _context.Emails.FirstOrDefault(c => c.Id == emailDto.Id);
            if (email == null)
            {
                throw new Exception("Not found client with id " + emailDto.Id);
            }

            email.Address = emailDto.Address;
            email.Topic = emailDto.Topic;
            email.Body = emailDto.Body;

            _context.SaveChanges();
        }

        public void Delete(EmailDTO emailDto)
        {
            var email = _context.Emails.FirstOrDefault(c => c.Id == emailDto.Id);
            if (email == null)
            {
                throw new Exception("Not found client with id " + emailDto.Id);
            }            

            _context.SaveChanges();
        }

        public static EmailDTO ConvertToDTO(Entity.Email email)
        {
            return new EmailDTO
            {
                Id = email.Id,
                Address = email.Address,
                Topic = email.Topic,
                Body = email.Body,
            };
        }

        public Entity.Email ConvertToEntity(EmailDTO email)
        {
            return new Entity.Email
            {
                Id = email.Id,
                Address = email.Address,
                Topic = email.Topic,
                Body = email.Body,
            };
        }

        
    }
}
