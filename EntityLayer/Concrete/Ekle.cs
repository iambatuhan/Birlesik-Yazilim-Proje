using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
     public  class Ekle
    {
        [Key]
        
        public int QRKodID { get; set; }
      
        public string OgrendigiYetenekler1 { get; set; }
        
        public string OgrendiğiYetenekeler2 { get; set; }
        
        public string OgrendiğiYetenekeler3 { get; set; }
      
        public DateTime OlusturmaDate { get; set; }
       
        public DateTime BaslamaDate { get; set; }
        
        public int SertifikaKodu { get; set; }

        public DateTime BitisDate { get; set; }
        public string BelgeTur { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public int AdminID { get; set; }
        public virtual Admin Admin { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public int Rating { get; set; }
    }
}
