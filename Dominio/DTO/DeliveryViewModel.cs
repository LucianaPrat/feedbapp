using Dominio.DTO;
using System;
using System.Collections.Generic;

namespace Domain.DTO
{
    public class DeliveryViewModel
    {
        // Selected filters
        public int? SelectedDeveloperId { get; set; }
        public int? SelectedLeaderId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        // List of deliveries
        public IEnumerable<DeliveryDTO> Deliveries { get; set; }

        // Options for dropdowns
        public IEnumerable<DeveloperDTO> DeveloperOptions { get; set; }
        public IEnumerable<LeaderDTO> LeaderOptions { get; set; }
    }
}
