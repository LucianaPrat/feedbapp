
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dominio.DTO
{
    public abstract class PersonDTO : IValidation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public bool Removed { get; set; }
        public PersonDTO()
        {
            Active = true;
        }

        public PersonDTO(string name, string lastName, string email)
        {
            Active = true;
            Name = name;
            LastName = lastName;
            Email = email;
            Active = true;
            Removed = false;
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
                throw new Exception("El nombre no debe estar vacio.");
            }
            if (string.IsNullOrEmpty(LastName))
            {
                throw new Exception("El apellido no puede estar vacio.");
            }
            if (Name.Length > 20)
            {
                throw new Exception("El nombre debe tener menos de 20 caracteres.");
            }
            if (Name.Length < 3)
            {
                throw new Exception("El nombre debe tener mas de 3 caracteres.");
            }
            if (string.IsNullOrEmpty(LastName))
            {
                throw new Exception("El apellido no puede estar vacio.");
            }
            if (string.IsNullOrEmpty(Email))
            {
                throw new Exception("El email no puede estar vacio.");
            }
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (emailRegex.IsMatch(Email))
            {
                throw new Exception("El email no cumple el formato.");
            }
        }

    }
}
