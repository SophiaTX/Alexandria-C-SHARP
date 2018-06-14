using System;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting.Compact;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Alexandria.net.Logging
{
    public class Logger :ILogger
    {
        public Logger(loggingType loggingtype, string appname)
        {
            switch (loggingtype)
            {
                case loggingType.file:
                    CreateLoggerCJson(appname);
                    break;
                case loggingType.server:
                    CreateLoggerToServer(appname);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(loggingtype), loggingtype, null);
            }
        }


        private void CreateLoggerCJson(string appname)
        {
            try
            {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .Enrich.WithProperty("Application", appname)
                    .WriteTo.File(new CompactJsonFormatter(), $"{appname}.clef")
                    .CreateLogger();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void CreateLoggerToServer(string appname)
        {
            try
            {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .Enrich.WithProperty("Application", appname)
                    .WriteTo.Seq("http://195.48.9.127:5341")
                    .CreateLogger();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Close()
        {
            Log.CloseAndFlush();
        }

        public void WriteError(string data)
        {
            Write(data, ErrorType.Error);
        }

        public void WriteWarning(string data)
        {
            Write(data, ErrorType.Warning);
        }

        public void WriteInfo(string data)
        {
            Write(data, ErrorType.Debug);
        }

        public void WriteTestData(string data)
        {
            throw new NotImplementedException();
        }

        private void Write(string info, ErrorType errortype)
        {
            switch (errortype)
            {
                case ErrorType.Debug:
                    Log.Debug(info);
                    break;
                case ErrorType.Error:
                    Log.Error(info);
                    break;
                case ErrorType.Warning:
                    Log.Warning(info);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(errortype), errortype, null);
            }
        }
    }
}