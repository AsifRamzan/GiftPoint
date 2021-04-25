using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Web.SessionState;
using GiftPoint.Models;
using GiftPoint.Common;
using System.Web;

namespace GiftPoint.Models 
{
    public partial class Object_History
    {
        //private static User getUserSession()
        //{
        //    try
        //    {
        //        if (System.Web.HttpContext.Current.Session["user"] != null)
        //        {
        //            return (User) System.Web.HttpContext.Current.Session["user"];
        //        }
        //        return null;
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //}
        private static string GetMACAddress()
        {
            try
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                String sMacAddress = string.Empty;
                foreach (NetworkInterface adapter in nics)
                {
                    if (sMacAddress == String.Empty) // only return MAC Address from first card
                    {
                        IPInterfaceProperties properties = adapter.GetIPProperties();
                        sMacAddress = adapter.GetPhysicalAddress().ToString();
                    }
                }
                return sMacAddress;
            }
            catch (Exception ex)
            {
                return "N/A | MAC";
            }
        }

        private static string GetIPAddress()
        {
            try
            {
                string ipAddress = HttpContext.Current.Request.UserHostAddress;
                //IPHostEntry Host = default(IPHostEntry);
                //var hostname = System.Environment.MachineName;
                //Host = Dns.GetHostEntry(hostname);
                //foreach (IPAddress IP in Host.AddressList)
                //{
                //    if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                //    {
                //        ipAddress = Convert.ToString(IP);
                //    }
                //}

                return ipAddress;
            }
            catch (Exception e)
            {
                return "N/A | IP";
            }
        }

        private static string GetMachineName()
        {
            try
            {
                var ip = HttpContext.Current.Request.UserHostAddress;
                IPAddress myIP = IPAddress.Parse(ip.ToString());
                IPHostEntry GetIPHost = Dns.GetHostEntry(myIP);
                List<string> compName = GetIPHost.HostName.ToString().Split('.').ToList();
                return compName.First();
            }
            catch (Exception ex)
            {
                return "N/A | Name";
            }
        }
       

        private static string GetOperationType(OperationType operationType)
        {
            var result = "";
            if (operationType == OperationType.Update)
                result = "UPDATE";
            else if (operationType == OperationType.Delete)
                result = "DELETE";
            return result;
                    
        }
        /// <summary>
        /// Function used to maintain history when an entry is Updated or Deleted.
        /// Only to be used in case of Update or Delete.
        /// </summary>
        /// <typeparam name="T">DB Entity Type to pass. e.g. User or City etc.</typeparam>
        /// <param name="operationType">Enumeration of OperationType i.e Update/Delete</param>
        /// <param name="primaryKeyValue">Primary Key Value of the record that is being Edited or Removed like 'obj.UserId'</param>
        //public static void SetHistory<T>(OperationType operationType, long primaryKeyValue)
        //{
        //    try
        //    {
        //        var dbContext = new SalesOperationsEntities();
        //        var context = ((IObjectContextAdapter) dbContext).ObjectContext;
        //        string className = typeof(T).Name;

        //        var container = context.MetadataWorkspace.GetEntityContainer(context.DefaultContainerName,
        //            DataSpace.CSpace);
        //        var tableName = (from meta in container.BaseEntitySets
        //            where meta.ElementType.Name == className
        //            select meta.Name).First();               

        //        var primaryKey = (from meta in container.BaseEntitySets
        //            where meta.ElementType.Name == className
        //            select meta.ElementType.KeyProperties.First().Name).First();
        //        using (dbContext)
        //        {
        //            var xmlString =
        //                dbContext.Database.SqlQuery<string>(
        //                        $"SELECT TOP 1 * FROM dbo.{tableName} WHERE {primaryKey} = {primaryKeyValue} FOR XML AUTO")
        //                    .ToArray();
        //            var userObj = getUserSession();
        //            long userId = 0;
        //            if (userObj != null)
        //            {
        //                userId = userObj.UserId;
        //            }
        //            dbContext.Object_History.Add(new Object_History
        //            {
        //                OperationType = GetOperationType(operationType),
        //                LAN_IP_Address = GetIPAddress(),
        //                MAC_Address = GetMACAddress(),
        //                Table_Name = tableName,
        //                Record_Id = primaryKeyValue,
        //                History_XML = xmlString[0],
        //                Row_created = DateTime.Now,
        //                Machine_Name = GetMachineName(),
        //                RowCreatedByUserId = userId
        //            });
                    
        //            context.SaveChanges();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        new Logger().LogError(ex);
        //    }
        //}
    }
}
