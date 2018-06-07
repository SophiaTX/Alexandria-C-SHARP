using Alexandria.net.Core;

namespace UnitTest
{
    public class BaseTest
    {
        protected readonly SophiaClient _client = new SophiaClient("localhost",8095,8096);

    }
}