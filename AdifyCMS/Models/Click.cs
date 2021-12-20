using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdifyCMS.Models
{
    public class Click
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        public DateTime ClickedTime {  get; set; }

        [Required]
        public string IP { get; set; }
    }
}
