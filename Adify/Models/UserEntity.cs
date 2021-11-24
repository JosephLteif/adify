using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Adify.Models
{
    public class UserEntity
    {
        [Key]
        public int Id {  get; set; }
        public string UserName {  get; set; }
        public string Password {  get; set; }
        public string Email {  get; set; }
        public string Company {  get; set; }
        public DateTime Created {  get; set; }
        public ICollection<Ad> Ads {  get; set; }
    }
}
