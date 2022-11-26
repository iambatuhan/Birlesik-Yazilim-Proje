using BusinnesLayer.Concrate;
using DataAccessLayer.Concrate;
using EntityLayer.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QRCODE.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        AdminManager am = new AdminManager();
        public ActionResult Index()
        {
            return View();
        }
        Repository<Admin> repository = new Repository<Admin> { };
        public ActionResult AdminList(string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(repository.List(x => x.AdminID.ToString() == p));
            }


            var UserList = am.GetAll();
            return View(UserList);
        }
        [HttpGet]
        public ActionResult AddNew()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNew(Admin b)
        {
            am.AdminAddL(b);


            return RedirectToAction("AdminList");
        }
        public ActionResult DeleteAdmin(int id)
        {
            am.DeleteAdmin(id);
            return RedirectToAction("AdminList");
        }
    }
}