using System;

namespace Alexandria.net.Exceptions
{
    /// <summary>
    /// blockchain exception object
    /// </summary>
    public class SophiaBlockchainException : Exception
    {
        public string ErrMsg { get; }
        
        /// <summary>
        /// Exception constructor
        /// </summary>
        /// <param name="errorresponse"></param>
        public SophiaBlockchainException(string errorresponse)
        {          
            ErrMsg = errorresponse;
            throw new System.ArgumentException(ErrMsg);
            
        }
    }
}