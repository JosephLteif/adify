using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdifyCMS.Models
{
    public class Campaign
    {
        [Key]
        public int Id {  get; set; }

        [Required]
        public string Name { get; set; }

        public string DurationInDays {  get; set; }

        public int Budget {  get; set; }

        public Analytics Analytics {  get; set; }

        public ICollection<Ad> Ads {  get; set; }
    }
}
