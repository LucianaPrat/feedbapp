using Dominio.Accessors.Deliveries;
using Dominio.Accessors.Email;
using Dominio.Accessors.Positions;
using Dominio.DTO;
using Dominio.Entity;
using Microsoft.EntityFrameworkCore;

namespace Dominio.Accessors.Delivery
{
    public class DeliveryAccessor : IDeliveryAccessor
    {
        private ApplicationDbContext _context;

        public DeliveryAccessor(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Exist(int id)
        {
            var c = _context.Deliveries.Where(c => c.Id == id).Count();
            return c > 0;
        }

        public List<DeliveryDTO> GetAll()
        {
            return _context.Deliveries.Where(d => !d.Removed)
                                      .Include(d => d.Email)
                                      .Include(d => d.Position)
                                      .Include(d => d.Position.Developer)
                                      .Include(d => d.Position.Developer.Leader)
                                      .Include(d => d.Position.Developer.Leader.Client)
                                      .ToList()
                                      .Select(c => ConvertToDTO(c))
                                      .ToList();
        }

        public DeliveryDTO GetById(int id)
        {
            var delivery = _context.Deliveries.FirstOrDefault(c => c.Id == id);
            if (delivery == null)
            {
                throw new Exception("Not found deliverie with id " + id);
            }
            return ConvertToDTO(delivery);
        }

        public DeliveryDTO Save(DeliveryDTO deliveryDto)
        {
            var delivery = ConvertToEntity(deliveryDto);
            _context.Deliveries.Add(delivery);
            _context.SaveChanges();
            DeliveryDTO d = ConvertToDTO(delivery);
            return d;
        }

        public void Update(DeliveryDTO deliveryDto)
        {
            if (deliveryDto == null)
            {
                throw new ArgumentNullException();
            }
            var deliverie = _context.Deliveries.FirstOrDefault(c => c.Id == deliveryDto.Id);
            if (deliverie == null)
            {
                throw new Exception("Not found deliverie with id " + deliveryDto.Id);
            }

            deliverie.Removed = deliveryDto.Removed;

            _context.SaveChanges();
        }

        public void Delete(DeliveryDTO deliveryDto)
        {
            var delivery = _context.Admins.FirstOrDefault(c => c.Id == deliveryDto.Id);
            if (delivery == null)
            {
                throw new Exception("Not found admin with id " + deliveryDto.Id);
            }
            delivery.Removed = true;

            _context.SaveChanges();
        }

         public static DeliveryDTO ConvertToDTO(Entity.Delivery delivery)
        {
            if (delivery == null)
            {
                throw new ArgumentNullException("deliverie");
            }

            return new DeliveryDTO
            {
                Id = delivery.Id,
                Position = delivery.Position != null ? PositionAccessor.ConvertToDTO(delivery.Position) : null,
                PositionId = delivery.Position != null ? delivery.Position.Id : 0,
                Date = delivery.Date,
                Email = delivery.Email != null ? EmailAccessor.ConvertToDTO(delivery.Email) : null,
                EmailId = delivery.Email != null ? delivery.Email.Id : 0,
                Removed = delivery.Removed
            };
        }

        public static Entity.Delivery ConvertToEntity(DeliveryDTO delivery)
        {
            if (delivery == null)
            {
                throw new ArgumentNullException("deliverie");
            }

            return new Entity.Delivery
            {
                Id = delivery.Id,
                PositionId = delivery.Position.Id,
                Date = delivery.Date,
                EmailId = delivery.EmailId,
                Removed = delivery.Removed
            };
        }

    }
}
