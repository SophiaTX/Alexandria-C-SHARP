namespace Alexandria.net.Logging
{
    public interface ILogger
    {
        //void CreateLoggerCJson(string appname);
        //void CreateLoggerToServer(string appname);
        void Close();
        //void Write(string data, ErrorType errortype);
        void WriteError(string data);
        void WriteWarning(string data);
        void WriteInfo(string data);
        void WriteTestData(string data);
        BuildMode BuildMode { get; set; }
        
    }
}