using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTO
{
    public class ClientDTO : IValidation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public bool Removed { get; set; }

        #region Builders
        public ClientDTO()
        {
            Active = true;
        }
        public ClientDTO(string name)
        {
            Name = name;
            Active = true;
            Removed = false;
        }
        #endregion

        #region Methods
        public void Desactivate()
        {
            if (Active)
            {
                Active = false;
            }
        }
        public void Delete()
        {
            if (!Removed)
            {
                Removed = true;
            }
        }
        public virtual void IsValid()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentException("The name cannot be empty or contain only spaces.");
            }

            if (Name.Length > 30)
            {
                throw new ArgumentException("The name must be less than 30 characters.");
            }

            if (Name.Length < 5)
            {
                throw new ArgumentException("The name must be more than 3 characters.");
            }
        }
        #endregion
    }

}
