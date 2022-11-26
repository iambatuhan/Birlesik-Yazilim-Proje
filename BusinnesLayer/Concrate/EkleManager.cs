using DataAccessLayer.Concrate;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Concrate
{
    public class EkleManager
    {
        Repository<Ekle> repoekle = new Repository<Ekle>();
        public List<Ekle> GetAll()
        {
            return repoekle.List();
        }
        public List<Ekle> EkleByID(int id)
        {
            return repoekle.List().Where(x => x.QRKodID == id).ToList();

        }
        public List<Ekle> GetEkleByID(int id)
        {
            return repoekle.List(x => x.QRKodID == id);

        }
        public List<Ekle> GetEkleByAdminID(int id)
        {
            return repoekle.List(x => x.AdminID == id);
        }
        public List<Ekle> GetEkleByCategory(int id)
        {
            return repoekle.List(x => x.CategoryID == id);
        }
        public int EkleAddL(Ekle p)
        {
            Random r = new Random();
            p.SertifikaKodu = r.Next(1000000000,2000000000);
            return repoekle.Insert(p);
        }
            public int DeleteEkle(int p)
        {
            Ekle ekleme = repoekle.Find(x => x.QRKodID == p);
            return repoekle.Delete(ekleme);
        }
        public Ekle FindEkle(int getid)
        {
            return repoekle.Find(x => x.QRKodID == getid);
        }
        public Ekle FindBul(string getid)
        {
            return repoekle.Find(x => x.User.UserName == getid);
        }
        public int UpdateEkle(Ekle p) {

            Ekle ekle = repoekle.Find(x => x.QRKodID == p.QRKodID);
            ekle.OlusturmaDate = p.OlusturmaDate;
            ekle.AdminID = p.AdminID;
            ekle.CategoryID = p.CategoryID;
            ekle.Rating = p.Rating;
            ekle.BelgeTur = p.BelgeTur;
            ekle.OgrendigiYetenekler1 = p.OgrendigiYetenekler1;
            ekle.OgrendiğiYetenekeler2 = p.OgrendiğiYetenekeler2;
            ekle.OgrendiğiYetenekeler3 = p.OgrendiğiYetenekeler3;
            ekle.UserID = p.UserID;
            ekle.BaslamaDate = p.BaslamaDate;
            ekle.BitisDate = p.BitisDate;
            return repoekle.Update(ekle);
        }
    }
    }
