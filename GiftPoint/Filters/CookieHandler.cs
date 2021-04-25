using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiftPoint.Filters
{
    public class CookieHandler : System.Web.HttpApplication
    {
        //public void SetUser(User user)
        //{
        //    try
        //    {
        //        HttpCookie aCookie = new HttpCookie("UserCookie");
                
        //        aCookie.Values["UserId"] = SecurityManager().EncodeString(user.UserId.ToString());
        //        aCookie.Values["LoginName"] = user.LoginName;
        //        aCookie.Values["LoginPassword"] = user.LoginPassword;
        //        aCookie.Values["UserRoleId"] = user.UserRoleId.ToString();
        //        aCookie.Values["FirstName"] = user.FirstName;
        //        aCookie.Values["LastName"] = user.LastName;
        //        aCookie.Expires = DateTime.Now.AddDays(1);
        //        HttpContext.Current.Response.Cookies.Add(aCookie);
        //    }
        //    catch (Exception)
        //    { }
        //}        

        //public User GetUser()
        //{
        //    User user = null;
        //    HttpCookie authCookie = HttpContext.Current.Request.Cookies["UserCookie"];

        //    if (authCookie != null)
        //    {
        //        user = new User();
        //        user.UserId = Convert.ToInt32(SecurityManager().DecodeString(authCookie.Values["UserId"]));
        //        user.LoginName = Convert.ToString(authCookie.Values["LoginName"]);
        //        user.LoginPassword = Convert.ToString(authCookie.Values["LoginPassword"]);
        //        user.UserRoleId = Convert.ToInt32(authCookie.Values["UserRoleId"]);
        //        user.FirstName = Convert.ToString(authCookie.Values["FirstName"]);
        //        user.LastName = Convert.ToString(authCookie.Values["LastName"]);
        //    }
        //    return user;
        //}        

        public void ExpireUserCookiee()
        {
            HttpCookie authCookie = HttpContext.Current.Request.Cookies["UserCookie"];
            if (authCookie != null)
            {
                authCookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(authCookie);
            }
        }

        public void ExpireDistributorCookiee()
        {
            HttpCookie authCookie = HttpContext.Current.Request.Cookies["DistributorCookie"];
            if (authCookie != null)
            {
                authCookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(authCookie);
            }
        }
    }
}