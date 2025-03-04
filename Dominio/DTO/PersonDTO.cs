
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Dominio.DTO
{
    public abstract class PersonDTO : IValidation
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required.")]
        [StringLength(20, ErrorMessage = "The name cannot exceed 20 characters.")]
        [MinLength(3, ErrorMessage = "The name must have at least 3 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The last name is required.")]
        [StringLength(20, ErrorMessage = "The last name cannot exceed 20 characters.")]
        [MinLength(3, ErrorMessage = "The last name must have at least 3 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The email address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }
        public bool Active { get; set; } = true;
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
                throw new Exception("The Name field is required.");
            }
            if (string.IsNullOrEmpty(LastName))
            {
                throw new Exception("The LastName field is required.");
            }
            if (Name.Length > 20)
            {
                throw new Exception("The name must be less than 20 characters.");
            }
            if (Name.Length < 3)
            {
                throw new Exception("The name must have more than 3 characters.");
            }
            if (LastName.Length > 20)
            {
                throw new Exception("The last name must be less than 20 characters.");
            }
            if (LastName.Length < 3)
            {
                throw new Exception("The last name must have more than 3 characters.");
            }
            if (string.IsNullOrEmpty(Email))
            {
                throw new Exception("The Email field is required.");
            }
            //var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            //if (emailRegex.IsMatch(Email))
            //{
            //    throw new Exception("The email does not comply with the format.");
            //}
        }

    }
}
