using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Usage.Models
{
    public class SectorPerformance_Model
    {
        
        [Key]
        public string name { get; set; }
        public string type { get; set; }
        public float performance { get; set; }
        public double lastUpdated { get; set; }

    }
}
