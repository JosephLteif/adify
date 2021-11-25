using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Adify.Models
{
    public class Campaign
    {
        [Key]
        public int Id {  get; set; }

        public string DurationInDays {  get; set; }

        public int Budget {  get; set; }

        public Analytics Analytics {  get; set; }

        public ICollection<Ad> Ads {  get; set; }
    }
}
