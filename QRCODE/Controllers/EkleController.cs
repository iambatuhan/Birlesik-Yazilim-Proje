using BusinnesLayer.Concrate;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrate;
using EntityLayer.Concrete;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace QRCODE.Controllers
{
    public class EkleController : Controller
    {
        // GET: Ekle
        EkleManager ek = new EkleManager();
        Context c = new Context();

        public ActionResult Index()
        {
            return View();
        }
        Repository<Ekle> repository = new Repository<Ekle> { };
        public ActionResult AdminList(string p, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(repository.List(x => x.SertifikaKodu.ToString() == p).ToPagedList(page, 5));
            }


            var AdminList = ek.GetAll().ToPagedList(page, 30);
            return View(AdminList);
        }

        [HttpGet]
       
        public ActionResult AddNew()
        {

        

            List<SelectListItem> values = (from x in c.Categories.ToList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.values = values;
            List<SelectListItem> values1 = (from x in c.Admins.ToList() select new SelectListItem { Text = x.UserName, Value = x.AdminID.ToString() }).ToList();
            ViewBag.values1 = values1;
            List<SelectListItem> values2 = (from x in c.Users.ToList() select new SelectListItem { Text = x.UserName, Value = x.UserID.ToString() }).ToList();
            ViewBag.values2 = values2;


            return View();

        }
        [HttpPost]
        public ActionResult AddNew(Ekle b)
        {
            
            ek.EkleAddL(b);
            return RedirectToAction("AdminList");
        }
        public ActionResult BelgeOlustur(int id)
        {
            var EkleDetails = ek.EkleByID(id);
            return View(EkleDetails);

        }
        public ActionResult DeleteEkle(int id)
        {
            ek.DeleteEkle(id);
            return RedirectToAction("AdminList");
        }
        [HttpGet]
        public ActionResult UpdateEkle(int id)

        {
            Ekle ekle = ek.FindEkle(id);





            return View(ekle);
        }
        [HttpPost]
        public ActionResult UpdateEkle(Ekle p)
        {
            ek.UpdateEkle(p);
            return RedirectToAction("AdminList");

        }

        public ActionResult List(string p, int page = 1)
        {
            if (!string.IsNullOrWhiteSpace(p))
            {
                return View(repository.List(x => x.SertifikaKodu.ToString() == p).ToPagedList(page, 30));
            }

            var AdminList = repository.List(x=>x.SertifikaKodu.ToString()==p).ToPagedList(page, 30);
            return View(AdminList);
        }
        public ActionResult BelgeOlustur1(int id)
        {
            var EkleDetails = ek.EkleByID(id);
            return View(EkleDetails);

        }
    }



    }
