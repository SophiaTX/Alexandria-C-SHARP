using System;
using Alexandria.net.Enums;
using Serilog;
using Serilog.Formatting.Compact;

namespace Alexandria.net.Logging
{
    public class Logger :ILogger
    {
        public BuildMode BuildMode { get; set; }
        
        public Logger(LoggingType loggingtype, string appname, BuildMode mode = BuildMode.Prod)
        {
            switch (loggingtype)
            {
                case LoggingType.File:
                    CreateLoggerCJson(appname);
                    break;
                case LoggingType.Server:
                    CreateLoggerToServer(appname);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(loggingtype), loggingtype, null);
            }

            BuildMode = mode;
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
            Write(data, ErrorType.Verbose);
        }


        public void Write(string info, ErrorType errortype)
        {
            switch (BuildMode)
            {
                case BuildMode.Test:
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
                        case ErrorType.Verbose:
                            Log.Verbose(info);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(errortype), errortype, null);
                    }
                    break;
                
                case BuildMode.Prod:
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
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}