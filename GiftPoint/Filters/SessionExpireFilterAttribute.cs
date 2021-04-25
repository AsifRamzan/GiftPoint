using System.Web;
using System.Web.Mvc;

namespace GiftPoint.Filters
{
    public class SessionExpireFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
       
            if (new UserSession().isUserLogin() == false)
            {
                //if (new CookieHandler().GetUser() != null && new CookieHandler().GetDistributor() != null)
                //{
                //    new UserSession().SetUserSession(new CookieHandler().GetUser());
                //}
                //else
                //{
                //    filterContext.Result = new RedirectResult("~/Home/Login");
                //    return;
                //}
            }

            base.OnActionExecuting(filterContext);
        }
    }  
}
