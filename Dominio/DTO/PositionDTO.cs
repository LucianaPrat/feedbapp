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
            
            // Description validation (optional, if applicable)
            if (!string.IsNullOrEmpty(Description) && Description.Length > 200)
            {
                throw new ArgumentException("The description cannot exceed 200 characters.");
            }

            if (DeveloperId <= 0)
            {
                throw new ArgumentException("The description cannot exceed 200 characters.");
            }
            // Relationships validation (optional, if applicable)
            if (Developer == null)
            {
                throw new ArgumentException("The associated developer cannot be null.");
            }

            if (Client == null)
            {
                throw new ArgumentException("The associated client cannot be null.");
            }

            if (Leader == null)
            {
                throw new ArgumentException("The associated leader cannot be null.");
            }
        }
        #endregion
    }
}
