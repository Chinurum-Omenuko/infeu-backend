using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace infeubackend.Models
{
    public class FireModel
    {
        [Required]
        public string Location { get; set; }

        [Required]
        public string Coordinates { get; set; }
    }
}