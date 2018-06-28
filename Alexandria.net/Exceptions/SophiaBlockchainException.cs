using System;

namespace Alexandria.net.Exceptions
{
    public class SophiaBlockchainException : Exception
    {
        public string ErrMsg { get; set; }
        
        public SophiaBlockchainException(string errorresponse)
        {
            ErrMsg = errorresponse;
        }

    }
}