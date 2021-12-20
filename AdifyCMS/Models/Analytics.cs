using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace AdifyCMS.Models
{
    public class Analytics
    {
        [Key]
        public string Id {  get; set; }
        public ICollection<Click> Clicks {  get; set; }
        public ICollection<View> Views {  get; set; }
    }
}
