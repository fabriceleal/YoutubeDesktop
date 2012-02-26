using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Noesis.Javascript;

namespace YoutubeDesktop
{

    /// <summary>
    /// Helper class to serialize and deserialize CLR structures to JSON.
    /// Uses the Noesis.Javascript dll.
    /// </summary>
    public class JavascriptUtils
    {

        /// <summary>
        /// Retrieves the JSON representation of a CLR object, 
        /// consisting of a dictionary of strings to objects.
        /// </summary>
        /// <param name="o">CLR object, 
        /// consisting of a dictionary of strings (attributes) to objects (values).</param>
        /// <returns>JSON representation, as string</returns>
        public static string SerializeObject(object o)
        {
            JavascriptContext context = null;
            try
            {
                if (o == null)
                    return "";

                context = new JavascriptContext();

                context.SetParameter("arg1", o);
                context.SetParameter("obj", null);
                context.Run(@" obj = JSON.stringify(arg1, null); ");

                return (string)context.GetParameter("obj");
            }
            catch (AccessViolationException)
            {
                throw new Exception("Access Violation Exception. Probably you should restart the app ...");
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

        /// <summary>
        /// Retrieves the CLR representation, consisting of a dictionary of strings to objects, 
        /// of a JSON string.
        /// </summary>
        /// <param name="o">JSON representation, as string</param>
        /// <returns>CLR object, consisting of a dictionary 
        /// of strings (attributes) to objects (values).</returns>
        public static object DeserializeJson(string jsonString)
        {
            JavascriptContext context = null;
            try
            {
                if (string.IsNullOrEmpty(jsonString))
                    return null;

                context = new JavascriptContext();

                context.SetParameter("arg1", jsonString);
                context.SetParameter("obj", null);
                context.Run(@" obj = JSON.parse(arg1, null); ");

                return context.GetParameter("obj");
            }
            catch (AccessViolationException)
            {
                throw new Exception("Access Violation Exception. Probably you should restart the app ...");
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
