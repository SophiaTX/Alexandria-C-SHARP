using System;

namespace Alexandria.abapwrapper.Exceptions
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