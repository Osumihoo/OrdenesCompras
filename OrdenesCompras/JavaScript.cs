using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesCompras
{
    internal class JavaScript
    {
        static string scriptTag = "<script type=\"\" language=\"\">{0} </script>";

        public static void ConsoleLog(string message)
        {
            string function = "Console.log('{0}');";
            string log = string.Format(GenerateCodeFromFunction(function), message);
            //string log = string.Format(function, message);
            //HttpContext.Current.Response.Write(log);

        }

        public static void Alert(string message)
        {
            string function = "alert('{0}');";
            string log = string.Format(GenerateCodeFromFunction(function), message);
            //string log = string.Format(function, message);
            //HttpContext.Current.Response.Write(log);
        }

        public static void AlertAddSolicitud(string message)
        {
            string function = "alert('{0}');";
            string log = string.Format(GenerateCodeFromFunction(function), message);
            //string log = string.Format(function, message);
            //HttpContext.Current.Response.Write(log);
        }

        static string GenerateCodeFromFunction(string function)
        {
            return string.Format(scriptTag, function);
        }
    }
}
