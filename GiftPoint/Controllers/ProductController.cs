using GiftPoint.Common;
using GiftPoint.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
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
            ViewBag.ParentCategories2 = this.GetCategoriesByParent(-1, "--Select Sub Group (1)--");
            ViewBag.ParentCategories3 = this.GetCategoriesByParent(-1, "--Select Sub Group (2)--");
            ViewBag.Companies = this.GetCompanies();
            ViewBag.Brands = this.GetBrands();

            if (!string.IsNullOrEmpty(Id))
            {
                int ID = Convert.ToInt32(new SecurityManager().DecodeString(Id));
                var model = new Product() { ProductId = ID }.GetById();
                if (model != null)
                {
                    ViewBag.ParentCategories2 = this.GetCategoriesByParent((model.CategoryId1 > 0 ? model.CategoryId1 : -1), "--Select Sub Group (1)--");
                    ViewBag.ParentCategories3 = this.GetCategoriesByParent((model.CategoryId2 > 0 ? model.CategoryId2 : -1), "--Select Sub Group (2)--");
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
            ViewBag.ParentCategories2 = this.GetCategoriesByParent((model.CategoryId1 > 0 ? model.CategoryId1 : -1), "--Select Sub Group (1)--");
            ViewBag.ParentCategories3 = this.GetCategoriesByParent((model.CategoryId2 > 0 ? model.CategoryId2 : -1), "--Select Sub Group (2)--");
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
                var obj = new ProductPhoto() { ProductId = PId };
                obj.Detail = obj.GetById();

                return PartialView(obj);
            }

            return PartialView(new ProductPhoto());
        }

        [HttpPost]
        public ActionResult UploadImages()
        {
            NameValueCollection form = Request.Form;
            int ProductId = int.Parse(Convert.ToString(form["ProductId"]));

            ProductPhoto model = new ProductPhoto();
            model.ProductId = ProductId;
            model.CreatedOn = DateTime.Now;
            model.CreatedBy = 1;

            string error_msg = string.Empty;

            if (Request.Files != null && Request.Files.Count > 0)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    try
                    {
                        var file = Request.Files[i];
                        if (file != null)
                        {
                            var folder = Server.MapPath($"~/{Constants.PRODUCT_IMAGES_DIRECTORY_PATH}{ProductId}");
                            if (!Directory.Exists(folder))
                            {
                                Directory.CreateDirectory(folder);
                            }

                            string imagename = $"{ProductId}_Image_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                            var path = Path.Combine(Server.MapPath($"~/{Constants.PRODUCT_IMAGES_DIRECTORY_PATH}{ProductId}"), imagename);
                            file.SaveAs(path);

                            model.PhotoPath = imagename;

                            model.Add();
                        }
                    }
                    catch (Exception ex)
                    {
                        error_msg += $" {ex.Message}";
                    }
                }
            }
            else
            {
                return Json("No photos to upload");
            }

            if (string.IsNullOrEmpty(error_msg))
            {
                return Json("Photos Uploaded Successfully");
            }

            return Json(error_msg);
        }

        #region Other Methods
        public SelectList GetParentCategories()
        {
            var Categories = new Product().GetParentCategories();

            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Value = "0", Text = "--Select Group--"});

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

        public SelectList GetCategoriesByParent(int ParentId, string Title)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Value = "0", Text = $"{Title}" });

            if (ParentId != -1)
            {
                var Categories = new Category().GetCategoriesByParent(ParentId);
                foreach (var item in Categories)
                {
                    list.Add(new SelectListItem()
                    {
                        Value = item.CategoryId.ToString(),
                        Text = item.CategoryTitle
                    });
                } 
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