using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public Int64 UserTc { get; set; }
        public string UserName { get; set; }
        public string UserImage { get; set; }
        public string Mail { get; set; }
       
        public string Meslek { get; set; }
        public ICollection<Ekle> Ekles { get; set; }
 

    }
}
