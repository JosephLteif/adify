using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdifyCMS.Models
{
    public class Ad
    {
        [Key]
        public int Id {  get; set; }
        public string Title {  get; set; }
        public string Description {  get; set; }
        public string ImageUrl {  get; set; }
        public string AdUrl {  get; set; }
        public bool DidPass { get; set; }
        public Category Category {  get; set; }
        public Analytics Analytics {  get; set; }
    }
}
