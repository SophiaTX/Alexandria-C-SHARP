using Alexandria.net.Enums;

namespace Alexandria.net.Logging
{
    public interface ILogger
    {
        void Close();
        void Write(string data, ErrorType errortype);
        void WriteError(string data);
        void WriteWarning(string data);
        void WriteInfo(string data);
        void WriteTestData(string data);
        BuildMode BuildMode { get; set; }
        
    }
}