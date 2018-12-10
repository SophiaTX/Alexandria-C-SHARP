using System;
using System.Reflection;
using Alexandria.net.Logging;
using Alexandria.net.Settings;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Alexandria.net.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class JsonHelper
    {   
        /// <summary>
        /// Checks if the input is valid json 
        /// </summary>
        /// <param name="input">the value to be checked</param>
        /// <returns>true if the input is valid json</returns>
        public static bool IsValidJson(string input)
        {
            try
            {
                JToken.Parse(input.Trim());
                return true;
            }
            catch (JsonReaderException)
            {
                return false;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}