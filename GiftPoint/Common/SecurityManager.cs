using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Web;

namespace GiftPoint.Common
{
    public class SecurityManager
    {

        private static readonly string SecurityKey = "b1s13r3zy2in2lho9lr5dt6jfe8rtl9ks7rmzff";
        //Function to encode the string
        private string SecurityStringEncode(string value, string key)
        {
            var mac3des = new MACTripleDES();
            var md5 = new MD5CryptoServiceProvider();
            mac3des.Key = md5.ComputeHash(Encoding.UTF8.GetBytes(key));
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(value)) + '-' +
                   Convert.ToBase64String(mac3des.ComputeHash(Encoding.UTF8.GetBytes(value)));
        }

        //Function to decode the string
        //Throws an exception if the data is corrupt
        private string SecurityStringDecode(string value, string key)
        {
            string dataValue = "";
            var mac3des = new MACTripleDES();
            var md5 = new MD5CryptoServiceProvider();
            mac3des.Key = md5.ComputeHash(Encoding.UTF8.GetBytes(key));

            try
            {
                value = value.Replace("%3d", "=");
                value = value.Replace("%2f", "?");
                string[] strs = value.Split('-');

                dataValue = Encoding.UTF8.GetString(Convert.FromBase64String(strs[0]));
                
            }
            catch (Exception ex)
            {
                new Logger().LogError(ex);
            }

            return dataValue;
        }

        //Two helper functions to make things easier.
        public string EncodeString(string value)
        {
            //var str = HttpUtility.UrlEncode(SecurityStringEncode(value, SecurityKey));
            //return str;

            return Utils.setEncyption(SecurityStringEncode(value, SecurityKey));
        }

        public string DecodeString(string value)
        {
            return SecurityStringDecode(Utils.getDecription(value), SecurityKey);
        }

        public object DecodeString(long outletId)
        {
            throw new NotImplementedException();
        }
    }
}
