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
    public class BrandController : Controller
    {
        // GET: Brand
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
            ViewData.Model = new Brand().GetAll();
            return View();
        }

        // GET: /Brand/Create  
        [AllowAnonymous]              
        public ActionResult Create(string Id, string IsView)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                int ID = Convert.ToInt32(new SecurityManager().DecodeString(Id));
                var model = new Brand() { BrandId = ID }.GetById();
                if(model != null)
                {
                    ViewData["IsView"] = IsView;
                    return View(model);
                }
            }

            return View(new Brand());
        }

        // POST: /Brand/Create
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Brand model)
        {
            if (ModelState.IsValid)
            {
                var ret = false;
                if(model.BrandId > 0)
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

                if(ret)
                {
                    return RedirectToRoute(new RouteValueDictionary(new { controller = "Brand", action = "Index", operationType = Convert.ToInt32(OperationMessageType.Success) }));                 
                }
                else
                {
                    ViewData[Constants.OPERATIONALMESSAGE] = Utils.getErrorMessage("Error", Constants.OPERATION_FAILED);                    
                }
            }

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
                        if (new Brand() { BrandId = ID }.Delete() == true)
                        {
                            return RedirectToRoute(new RouteValueDictionary(new { controller = "Brand", action = "Index", operationType = Convert.ToInt64(OperationMessageType.Success) }));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new Logger().LogError(ex);
            }

            return RedirectToRoute(new RouteValueDictionary(new { controller = "Brand", action = "Index", operationType = Convert.ToInt32(OperationMessageType.Error) }));
        }
    }
}