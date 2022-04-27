using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NimblySDK
{
    public static class Utils
    {
        public static string ToQueryString(this List<KeyValuePair<string, string>> collection)
        {
            List<string> itens = new List<string>();
            foreach (KeyValuePair<string, string> par in collection)
                itens.Add(String.Format("{0}={1}", par.Key, HttpUtility.UrlEncode(par.Value)));

            return String.Join("&", itens);
        }
    }
}
