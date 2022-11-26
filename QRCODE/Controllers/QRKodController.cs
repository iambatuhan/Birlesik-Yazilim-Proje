﻿using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QRCODE.Controllers
{
    public class QRKodController : Controller
    {
        // GET: QRKod
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult QrCode()
        {
            return View();
        }
        [HttpPost]
        public ActionResult QrCode(string kod)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator koduret = new QRCodeGenerator();
                QRCodeGenerator.QRCode karekod = koduret.CreateQrCode(kod, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap resim = karekod.GetGraphic(15))
                {
                    resim.Save(ms, ImageFormat.Png);
                    ViewBag.karekodimage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }

            return View();
        }
    }
}
  