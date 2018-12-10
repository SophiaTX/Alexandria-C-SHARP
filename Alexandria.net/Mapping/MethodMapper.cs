using System;
using Alexandria.net.Messaging.Params;
using Newtonsoft.Json;

namespace Alexandria.net.Mapping
{
    /// <summary>
    /// 
    /// </summary>
    public class MethodMapper
    {
        /// <summary>
        /// 
        /// </summary>
        public string MethodName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BlockChainMethodName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ObjectTypeName { private get; set; }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public string GetObjectAndJsonValue(params object[] list)
        {

            var type = Type.GetType(ObjectTypeName);
            var result = string.Empty;
            var obj = CreateInstance<IParams>(type).GetDetails(list);
            if(obj != null)
                result = JsonConvert.SerializeObject(obj);
            return result;
        }
        
        private static I CreateInstance<I>(Type objType) where I : class  
        {  
            return Activator.CreateInstance(objType) as I;  
        }  
    }
}