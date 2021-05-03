using GiftPoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GiftPoint.Controllers
{
    public class BrandController : Controller
    {
        // GET: Brand
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Brand/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Brand/Create
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Brand model)
        {
            return View();
        }
    }
}