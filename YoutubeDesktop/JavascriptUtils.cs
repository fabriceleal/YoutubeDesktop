using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Noesis.Javascript;

namespace YoutubeDesktop
{
    public class JavascriptUtils
    {

        public static string SerializeObject(object o)
        {
            JavascriptContext context = null;
            try
            {
                if (o == null)
                    return "";

                GC.Collect();
                GC.WaitForPendingFinalizers();

                context = new JavascriptContext();

                context.SetParameter("arg1", o);
                context.SetParameter("obj", null);
                context.Run(@" obj = JSON.stringify(arg1, null); ");

                return (string)context.GetParameter("obj");
            }
            catch (Exception ex)
            {
                throw new Exception("Error in SerializeObject.", ex);
            }
            finally
            {
                if (context != null)
                {
                    context.Dispose();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }
        }

        public static object DeserializeJson(string jsonString)
        {
            JavascriptContext context = null;
            try
            {
                if (string.IsNullOrEmpty(jsonString))
                    return null;

                GC.Collect();
                GC.WaitForPendingFinalizers();

                context = new JavascriptContext();

                context.SetParameter("arg1", jsonString);
                context.SetParameter("obj", null);
                context.Run(@" obj = JSON.parse(arg1, null); ");

                return context.GetParameter("obj");
            }
            catch (AccessViolationException ave)
            {
                throw new Exception("Access Violation Exception. Probabily you should restart the app ...");
            }
            catch (Exception ex)
            {
                throw new Exception("Error in DeserializeJson.", ex);
            }
            finally
            {
                if (context != null)
                {
                    context.Dispose();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }                    
            }            
        }

    }
}
