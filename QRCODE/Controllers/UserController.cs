using BusinnesLayer.Concrate;
using DataAccessLayer.Concrate;
using EntityLayer.Concrete;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QRCODE.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        UserManager us = new UserManager();
        public ActionResult Index()
        {
            return View();
        }
        Context c = new Context();
        public ActionResult AddNewUser()
        {
            List<SelectListItem> values1 = (from x in c.Admins.ToList() select new SelectListItem { Text = x.UserName, Value = x.AdminID.ToString() }).ToList();
            ViewBag.values1 = values1;

            return View();

        }
        [HttpPost]
        public ActionResult AddNewUser(User b)
        {
            Context c = new Context();
            string dosyaadı = Path.GetFileName(Request.Files[0].FileName);
            string uzantı = Path.GetExtension(Request.Files[0].FileName);
            string yol = "~/Image/" + dosyaadı + uzantı;
            Request.Files[0].SaveAs(Server.MapPath(yol));
            b.UserImage = "/Image/" + dosyaadı + uzantı;
            c.Users.Add(b);
            c.SaveChanges();

            return RedirectToAction("UserList","User");
        }
        Repository<User> repository = new Repository<User> { };
        public ActionResult UserList(string p,int page=1)
        {
            if (!string.IsNullOrEmpty(p))
            {
               return View(repository.List(x => x.UserID.ToString() == p).ToPagedList(page,30));
            }


            var UserList = us.GetAll().ToPagedList(page,30);
            return View(UserList);
        }
        public ActionResult DeleteUser(int id)
        {
            us.DeleteUser(id);
            return RedirectToAction("UserList");
        }
        public ActionResult UpdateEkle(int id)

        {
            User ekle = us.FindEkle(id);





            return View(ekle);
        }
        [HttpPost]
        public ActionResult UpdateEkle(User p)
        {
            us.UpdateEkle(p);
            return RedirectToAction("UserList");

        }
    }
}