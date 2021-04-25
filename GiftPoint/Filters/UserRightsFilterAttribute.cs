using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Mvc;
using GiftPoint.Models;

namespace GiftPoint.Filters
{
    public class UserRightsFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            if (ctx.Session != null)
            {


                // check if a new session id was generated
                if (ctx.Session.IsNewSession)
                {


                    // If it says it is a new session, but an existing cookie exists, then it must
                    // have timed out
                    string sessionCookie = ctx.Request.Headers["Cookie"];
                    if ((null != sessionCookie))
                    {
                        ctx.Response.Redirect("~/");
                    }
                }
            }

            //var userRoleObj = new UserSession().getUserSession();
            //if (userRoleObj != null)
            //{
            //    if (!new MenusRight().HasRight(userRoleObj.UserRoleId, filterContext.ActionDescriptor.ActionName, filterContext.ActionDescriptor.ControllerDescriptor.ControllerName))
            //    {
            //        filterContext.Result = new RedirectResult("~/Home/PageNotFound", true);
            //        return;
            //    }
            //    return;
            //}
            //else
            //{
            //    return;
            //}
            
           
            base.OnActionExecuting(filterContext);
        }
    }  
}
