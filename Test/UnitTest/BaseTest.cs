using Alexandria.net.Core;

namespace UnitTest
{
    public class BaseTest
    {
        protected readonly SophiaClient
            _client = new SophiaClient("195.48.9.209", 9091, 9093); 
    }
}