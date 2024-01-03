﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Position
    {
        private static int UltimoId { get; set; }
        public int Id { get; set; }
        public Recurrence Recurrence {  get; set; }
        public string Description { get; set; }
        public Developer Developer { get; set; }    

        public Position() {
            Id = UltimoId++;
        }

        public Position(Recurrence recurrence, string description,Developer developer) {
            Id = UltimoId++;
            Recurrence = recurrence;
            Description = description;
            Developer = developer;
        }
    }
}
