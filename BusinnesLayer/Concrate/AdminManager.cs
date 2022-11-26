using DataAccessLayer.Concrate;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Concrate
{
    public class AdminManager
    {
 
            Repository<Admin> repoadmin = new Repository<Admin>();
            public List<Admin> GetAll()
            {
                return repoadmin.List();
            }
        
        public int AdminAddL(Admin p)
        {
            return repoadmin.Insert(p);

        }
        public int DeleteAdmin(int p)
        {
            Admin ekleme = repoadmin.Find(x=>x.AdminID==p);
            return repoadmin.Delete(ekleme);
        }

    }
    }
