using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Adify.Models
{
    public class Analytics
    {
        [Key]
        public string Id {  get; set; }
        public int Clicks {  get; set; }
        public int Views {  get; set; }
    }
}
