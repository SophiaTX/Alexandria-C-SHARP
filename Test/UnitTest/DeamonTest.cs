using Xunit;

namespace UnitTest
{
    public class DeamonTest : BaseTest
    {
        [Fact]
        public void test()
        {
            _client.Daemon.get_account_count();
        }
    }
}