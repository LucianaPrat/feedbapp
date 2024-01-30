using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.DTO;

namespace Dominio
{
    public class Admin : PersonDTO, IValidation
    {
        private static int UltimoId { get; set; } = 1;
        public int Id { get; set; }
        public string Password { get; set; }
        public Admin() : base()
        {
        }
        public Admin(string name, string lastName, string email,string password) : base(name, lastName, email)
        {
            Password = password;
        }
        public virtual void IsValid()
        {
            base.IsValid();
        }
    }
}
