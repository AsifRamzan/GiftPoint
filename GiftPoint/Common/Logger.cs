using GiftPoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftPoint.Common
{
    public class Logger
    {

        public void LogError(Exception ex)
        {
            try
            {
                string exceptionMessage = "";
                string innerExceptionMessage = "";
                string stackTraceMessage = "";

                try
                {
                    exceptionMessage = ex.Message;
                }
                catch (Exception)
                { }

                try
                {
                    if (ex.InnerException != null)
                    {
                        innerExceptionMessage = ex.InnerException.Message;
                    }
                }
                catch (Exception)
                { }

                try
                {
                    stackTraceMessage = ex.StackTrace;
                }
                catch (Exception)
                { }

                //using (var context = new SalesOperationsEntities())
                //{

                //    DMS_Logger log = new DMS_Logger();
                //    log.ExceptionMessage = exceptionMessage;
                //    log.InnerExceptionMessage = innerExceptionMessage;
                //    log.StackTraceMessage = stackTraceMessage;
                //    log.ExceptionDate = DateTime.Now;
                //    context.DMS_Logger.Add(log);
                //    context.SaveChanges();                    
                //}
            }
            catch (Exception)
            { }

        }


        public void LogError(string exceptionMessage, string innerExceptionMessage)
        {
            try
            {

                string stackTraceMessage = "";
                

                //using (var context = new SalesOperationsEntities())
                //{

                //    DMS_Logger log = new DMS_Logger();
                //    log.ExceptionMessage = exceptionMessage;
                //    log.InnerExceptionMessage = innerExceptionMessage;
                //    log.StackTraceMessage = stackTraceMessage;
                //    log.ExceptionDate = DateTime.Now;
                //    context.DMS_Logger.Add(log);
                //    context.SaveChanges();
                //    ///   context.DMS
                //}
                /////// Save this function to table DMS_Logger

            }
            catch (Exception)
            { }

        }

    }
}
