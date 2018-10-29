using System;
using Alexandria.net.Enums;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Graylog;
using Serilog.Sinks.Graylog.Core;
using Serilog.Sinks.Graylog.Core.Transport;


namespace Alexandria.net.Exceptions
{
    /// <summary>
    /// blockchain exception object
    /// </summary>
    public class SophiaBlockchainException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public string ErrMsg { get; }
        
        /// <summary>
        /// Exception constructor
        /// </summary>
        /// <param name="errorresponse"></param>
        public SophiaBlockchainException(string errorresponse)
        {
            var loggerConfig = new LoggerConfiguration().WriteTo.Graylog(new GraylogSinkOptions
            {
                HostnameOrAddress = "logging.sophiatx.com",
                Port = 12405
                                     
            }).CreateLogger();
           
            
            loggerConfig.Write(LogEventLevel.Error,errorresponse);
            
            ErrMsg = errorresponse;
            
            throw new System.ArgumentException(ErrMsg);
            
        }
    }
}