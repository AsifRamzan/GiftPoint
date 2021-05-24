using GiftPoint.Common;
using GiftPoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GiftPoint.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(int? operationType)
        {
            if (operationType != null && operationType > 0)
            {
                if (operationType == Convert.ToInt32(OperationMessageType.Success))
                {
                    ViewData[Constants.OPERATIONALMESSAGE] = Utils.getSuccessMessage("Success", Constants.OPERATION_DONE);
                }
                else if (operationType == Convert.ToInt32(OperationMessageType.Error))
                {
                    ViewData[Constants.OPERATIONALMESSAGE] = Utils.getErrorMessage("Error", Constants.OPERATION_FAILED);
                }
            }

            ViewData.Model = new Product().GetAll();
            return View();
        }

        // GET: /Product/Create  
        [AllowAnonymous]
        public ActionResult Create(string Id, string IsView)
        {
            ViewBag.ParentCategories1 = this.GetParentCategories();
            ViewBag.ParentCategories2 = this.GetParentCategories();
            ViewBag.ParentCategories3 = this.GetParentCategories();
            ViewBag.Companies = this.GetCompanies();
            ViewBag.Brands = this.GetBrands();

            if (!string.IsNullOrEmpty(Id))
            {
                int ID = Convert.ToInt32(new SecurityManager().DecodeString(Id));
                var model = new Product() { ProductId = ID }.GetById();
                if (model != null)
                {
                    ViewData["IsView"] = IsView;
                    return View(model);
                }
            }

            return View(new Product());
        }

        // POST: /Product/Create
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                var ret = false;
                if (model.ProductId > 0)
                {
                    //update
                    model.LastUpdatedBy = 1;
                    model.LastUpdatedOn = DateTime.Now;

                    ret = model.Update();
                }
                else
                {
                    //save
                    model.CreatedBy = 1;
                    model.CreatedOn = DateTime.Now;

                    ret = model.Add();
                }

                if (ret)
                {
                    return RedirectToRoute(new RouteValueDictionary(new { controller = "Product", action = "Index", operationType = Convert.ToInt32(OperationMessageType.Success) }));
                }
                else
                {
                    ViewData[Constants.OPERATIONALMESSAGE] = Utils.getErrorMessage("Error", Constants.OPERATION_FAILED);
                }
            }

            ViewBag.ParentCategories1 = this.GetParentCategories();
            ViewBag.ParentCategories2 = this.GetParentCategories();
            ViewBag.ParentCategories3 = this.GetParentCategories();
            ViewBag.Companies = this.GetCompanies();
            ViewBag.Brands = this.GetBrands();

            return View(model);
        }

        public ActionResult Delete(string Id)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Id))
                {
                    int ID = Convert.ToInt32(new SecurityManager().DecodeString(Id));
                    if (ID > 0)
                    {
                        if (new Product() { ProductId = ID }.Delete() == true)
                        {
                            return RedirectToRoute(new RouteValueDictionary(new { controller = "Product", action = "Index", operationType = Convert.ToInt64(OperationMessageType.Success) }));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new Logger().LogError(ex);
            }

            return RedirectToRoute(new RouteValueDictionary(new { controller = "Product", action = "Index", operationType = Convert.ToInt32(OperationMessageType.Error) }));
        }

        [HttpGet]
        public PartialViewResult _UploadImages(string Id)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                var PId = Convert.ToInt32(new SecurityManager().DecodeString(Id));
                return PartialView(new Product() { ProductId = PId }.GetById());
            }

            return PartialView(new Product());
        }

        [HttpPost]
        public ActionResult UploadImages()
        {
            return View("_UploadImages");
        }

        #region Other Methods
        public SelectList GetParentCategories()
        {
            var Categories = new Product().GetParentCategories();

            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Value = "0", Text = "--Select Category--"});

            foreach (var item in Categories)
            {
                list.Add(new SelectListItem()
                {
                    Value = item.CategoryId.ToString(),
                    Text = item.CategoryTitle
                });
            }

            return new SelectList(list, "Value", "Text");
        }

        public SelectList GetCompanies()
        {
            var Companies = new Product().GetCompanies();

            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Value = "0", Text = "--Select Company--" });

            foreach (var item in Companies)
            {
                list.Add(new SelectListItem()
                {
                    Value = item.CompanyId.ToString(),
                    Text = item.CompanyName
                });
            }

            return new SelectList(list, "Value", "Text");
        }

        public SelectList GetBrands()
        {
            var Brands = new Product().GetBrands();

            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Value = "0", Text = "--Select Brand--" });

            foreach (var item in Brands)
            {
                list.Add(new SelectListItem()
                {
                    Value = item.BrandId.ToString(),
                    Text = item.BrandTitle
                });
            }

            return new SelectList(list, "Value", "Text");
        }
        #endregion
    }
}