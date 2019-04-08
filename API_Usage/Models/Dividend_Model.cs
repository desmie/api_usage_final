using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Usage.Models
{
    public class Dividend_Model
    {
        [Key]
        public string exdate { get; set; }
        public string paymentDate { get; set; }
        public string recordDate { get; set; }
        public string declaredDate { get; set; }
        public string type { get; set; }
        public string qualified { get; set; }
    }
}