using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoodUp.Models
{
    public class Moods
    {
        public int Id { get; set; }
        public double mood { get; set; }
        public DateTime timestamp { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}