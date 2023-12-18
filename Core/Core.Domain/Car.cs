﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string? Model { get; set; }
        public string? Image { get; set; }
        public int LocationId { get; set; }
        public bool Available { get; set; }
        public Location? Location { get; set; }
        public ICollection<Trip> Trips { get; set; } = new List<Trip>();

    }
}
