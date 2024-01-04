using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Person
    {
        private static int UltimoId {  get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public bool Removed { get; set; }
        public Person()
        {
        }

        public Person(string name,string lastName, string email)
        {
            Id = UltimoId++;
            Name = name;
            LastName = lastName;
            Email = email;
            Active = true;
            Removed = false;
        }

        public void Delete()
        {
            if(!Removed)
            {
                Removed = true;
            }            
        }
    }
}
