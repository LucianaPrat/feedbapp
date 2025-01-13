using Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTO
{
    public class PositionDTO
    {
        public int Id { get; set; }
        public int DeveloperId { get; set; }
        public DeveloperDTO Developer { get; set; }
        public string Description { get; set; }
        public ClientDTO Client { get; set; }
        public LeaderDTO Leader { get; set; }
        public Recurrence Recurrence { get; set; }
        public bool Removed { get; set; }

        #region Builders
        
        #endregion

        #region Methods
        public void Delete()
        {
            if (!Removed)
            {
                Removed = true;
            }
        }
        public virtual void IsValid()
        {
            //if (string.IsNullOrEmpty(Name))
            //{
            //    throw new Exception("El nombre puede estar vacio.");
            //}
            //if (Name.Length > 40)
            //{
            //    throw new Exception("El nombre tiene que tener menos de 40 caracteres.");
            //}
            //if (Name.Length < 5)
            //{
            //    throw new Exception("El nombre tiene que tener mas de 3 caracteres.");
            //}
        }
        #endregion
    }
}
