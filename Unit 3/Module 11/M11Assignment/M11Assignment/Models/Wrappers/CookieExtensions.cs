using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace M11Assignment.Models.Wrappers
{
    public static class CookieExtensions
    {
        //Currently only has support for Lists. This could be simple to add objects that aren't lists by excluding the foreach
        public static List<T> DeserializeObject<T>(this IRequestCookieCollection cookies, string key, string delimiter)
        {
            List<T> result = new List<T>();
            string cookie = cookies[key];
            if (cookie != null)
            {
                string[] splitString = cookie.Split(delimiter);
                if (splitString.Length > 0)
                {
                    foreach (string hs in splitString)
                    {
                        result.Add(JsonConvert.DeserializeObject<T>(hs));
                    }
                }
            }
            return result;
        }
        public static void AppendAndSerialize<T>(this IResponseCookies cookies, string key, List<T> value, string delimiter, CookieOptions options)
        {
            string serializedValue = JsonConvert.SerializeObject(value[0]);
            for (int i = 1; i < value.Count; i++)
            {
                serializedValue += delimiter + JsonConvert.SerializeObject(value[i]);
            }
            cookies.Append(key, serializedValue, options);
        }
    }
}
