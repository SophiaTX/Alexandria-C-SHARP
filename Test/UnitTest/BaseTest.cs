using Alexandria.net.Core;

namespace UnitTest
{
    public class BaseTest
    {
        protected readonly SophiaClient
            Client = new SophiaClient("stagenet.sophiatx.com", 9091, 9195); 
    }
}