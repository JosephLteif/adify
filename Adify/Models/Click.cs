using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Adify.Models
{
    public class Click
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id {  get; set; }
        [Required]
        public DateTime ClickedTime {  get; set; }

        [Required]
        public string IP { get; set; }
    }
}
