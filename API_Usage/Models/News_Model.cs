using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Usage.Models
{

    public class News_Model
    {
        [Key]
        public DateTime datetime { get; set; }
        public string headline { get; set; }
        public string source { get; set; }
        public string url { get; set; }
        public string summary { get; set; }
        public string related { get; set; }
        public string image { get; set; }
    }

}
