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
using System.Collections.Generic;
using System.Web.SessionState;

namespace GiftPoint.Filters
{
    public class UserSession : System.Web.UI.Page
    {
        //public void SetUserSession(User user)
        //{
        //    Session["user"] = user;
        //    new CookieHandler().SetUser(user);
        //}
        //public User getUserSession()
        //{
        //    if (Session["user"] != null)
        //    {
        //        return (User)Session["user"];
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        public void SetInternSession(string InternId)
        {
            Session["InternId"] = InternId;
        }
        public string getInternSession()
        {
            if (Session["InternId"] != null)
            {
                return (string)Session["InternId"];
            }
            else
            {
                return null;
            }
        }
        public Boolean isUserLogin()
        {
            if (Session["user"] != null && Session["Distributor"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void expireSession()
        {
            //UserLoginLogOutHistory obj = new UserLoginLogOutHistory();
            //obj.User_Id = Convert.ToInt32(new UserSession().getUserSession().UserId);
            //obj.is_Login = false;
            //obj.Date = DateTime.Now;
            //obj.CreatedBy = Convert.ToInt32(new UserSession().getUserSession().UserId);
            //obj.CreatedOn = DateTime.Now;

            //new User().UserLoginLogOuthistory(obj);

            Session["user"] = null;
            new CookieHandler().ExpireUserCookiee();
        }

    }
}
