using Alexandria.net.Core;

namespace UnitTest
{
    public class BaseTest
    {
        //protected readonly SophiaClient _client = new SophiaClient("localhost",8095,8096);

        protected readonly SophiaClient
            _client = new SophiaClient("195.48.9.208", 8095, 8096); // SophiaClient("195.48.9.209",9095,9091);

    }
}