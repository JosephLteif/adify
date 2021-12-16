using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Adify.Models
{
    public class View
    {
        [Key]
        public string Id {  get; set; }

        [Required]
        public DateTime ViewedTime { get; set; }

        [Required]
        public string IP {  get; set; }
    }
}
