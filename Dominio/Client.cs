using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Client
    {
        private static int UltimoId { get; set; } = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public bool Removed { get; set; }

        #region Builders
        public Client()
        {
            Id = UltimoId++;
        }
        public Client(string name)
        {
            Id = UltimoId++;
            Name = name; 
            Active = true;
            Removed = false;
        }
        #endregion

        #region Methods
        public void Deactivate()
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
        #endregion

    }

}
