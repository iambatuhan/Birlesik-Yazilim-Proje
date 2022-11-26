using DataAccessLayer.Concrate;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Concrate
{
    public class UserManager
    {
        Repository<User> repouser = new Repository<User>();
        
        public List<User> GetAll()
        {
            return repouser.List();
        }
        public List<User> EkleUserID(int id)
        {
            return repouser.List().Where(x => x.UserID == id).ToList();

        }
        public List<User> GetUserByID(int id)
        {
            return repouser.List(x => x.UserID == id);

        }
        public int UserAddL(User p)
        {
            return repouser.Insert(p);

        }
        public int DeleteUser(int p)
        {
            User ekleme = repouser.Find(x => x.UserID == p);
            return repouser.Delete(ekleme);
        }
        public User FindEkle(int getid)
        {
            return repouser.Find(x => x.UserID == getid);
        }
        public int UpdateEkle(User p)
        {

            User user = repouser.Find(x => x.UserID == p.UserID);
            user.UserTc=p.UserTc;
            user.UserName = p.UserName;
            user.Mail = user.Mail;

          
            user.Meslek = user.Meslek;
         
            return repouser.Update(user);
        }

    }
}
