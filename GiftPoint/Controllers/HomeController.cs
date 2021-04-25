using GiftPoint.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GiftPoint.Common;

namespace GiftPoint.Controllers
{
    public class HomeController : Controller
    {       
        //[UserRightsFilter]
        public ActionResult Index()
        {
            //UserLoginLogOutHistory obj = new UserLoginLogOutHistory();
            //obj.User_Id = Convert.ToInt32(new UserSession().getUserSession().UserId);
            //obj.is_Login = true;
            //obj.Date = DateTime.Now;
            //obj.CreatedBy = Convert.ToInt32(new UserSession().getUserSession().UserId);
            //obj.CreatedOn = DateTime.Now;

            //new User().UserLoginLogOuthistory(obj);

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(string txtLoginId, string txtPassword)
        {
            try
            {
                ViewData["txtLoginId"] = txtLoginId;
                if (!string.IsNullOrWhiteSpace(txtLoginId) && !string.IsNullOrEmpty(txtPassword))
                {
                    //User userObj = new User();
                    //userObj.LoginName = txtLoginId;
                    //userObj.LoginPassword = txtPassword.Trim();
                    //User retUser = new User().AuthnticateUser(userObj);
                    //if (retUser != null)
                    if(true)
                    {
                        //new UserSession().SetUserSession(retUser);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewData["RetMessage"] = "Please enter correct login Id and password";
                    }
                }
                else
                {
                    ViewData["RetMessage"] = "Please enter login Id and password";
                }
            }
            catch (Exception ex)
            {
                new Logger().LogError(ex);
            }
            return View("Login");
        }

        public ActionResult Logout()
        {
            try
            {
                new UserSession().expireSession();
            }
            catch (Exception)
            {
            }

            return RedirectToAction("Login", "Home");
        }

        public ActionResult NotAuthorized()
        {
            ViewData[Constants.OPERATIONALMESSAGE] = Utils.getNoticeMessage("Authorization Failure", "You are not authorized to this page. Please contact Support Team.");
            return View("Login");
        }

        public ActionResult PageNotFound()
        {
            return View();
        }
    }
}