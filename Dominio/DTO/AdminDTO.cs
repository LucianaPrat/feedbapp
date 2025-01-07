using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTO
{
    public class AdminDTO : IValidation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public bool Removed { get; set; }

        #region Builders
        public AdminDTO()
        {
            Active = true;
        }
        public AdminDTO(string name, string email,string password)
        {
            Name = name;
            Email = email;
            Password = password;
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
            if (string.IsNullOrEmpty(Name))
            {
                throw new Exception("El nombre puede estar vacio.");
            }
            if (Name.Length > 40)
            {
                throw new Exception("El nombre tiene que tener menos de 40 caracteres.");
            }
            if (Name.Length < 5)
            {
                throw new Exception("El nombre tiene que tener mas de 3 caracteres.");
            }
        }
        #endregion
    }
}
