using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Threading.Tasks;

namespace Adify.Models
{
    public class Category
    {
        [Key]
        public int Id {  get; set; }
        public string Name {  get; set; }
        public string Description {  get; set; }

        public ICollection<Ad> ads {  get; set; }
    }
}
