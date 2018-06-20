using Alexandria.net.Core;

namespace UnitTest
{
    public class BaseTest
    {
<<<<<<< HEAD
        //protected readonly SophiaClient _client = new SophiaClient("localhost",8095,8096);

        protected readonly SophiaClient
            _client = new SophiaClient("195.48.9.208", 8095, 8096); // SophiaClient("195.48.9.209",9095,9091);
=======
        //protected readonly SophiaClient _client = new SophiaClient("localhost",8095,8096);//localnode
        protected readonly SophiaClient _client = new SophiaClient("195.48.9.209",9095,9091);//9091 rpc connection, 9093 HTTP connection, 9095 daemon
>>>>>>> b31c49050a58a9c9562c49ba1cfee9e2830d6ebe

    }
}