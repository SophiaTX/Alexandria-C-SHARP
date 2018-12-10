namespace Alexandria.net.Messaging.Params
{
    /// <summary>
    /// 
    /// </summary>
    public interface IParams
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        object GetDetails(params object[] list);    
    }
}