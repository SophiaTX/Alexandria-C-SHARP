using System.Runtime.InteropServices;

namespace Alexandria.net.Core
{
	public class Wallet : Alexandria.net.API.Wallet
	{
		private const string libAddress = "libalexandria.dylib";
		#region Constructors

		public Wallet(string hostname = "127.0.0.1", ushort port = 8091) : base(hostname, port)
		{
		}

		#endregion
		[DllImport(libAddress)]
        public static extern bool generate_private_key(byte[] private_key);
        [DllImport(libAddress)]
        public static extern bool get_transaction_digest(string transaction, byte[] digest);
        [DllImport(libAddress)]
        public static extern bool sign_digest(string digest, string private_key, byte[] signed_digest);
        [DllImport(libAddress)]
        public static extern bool add_signature(string transaction, string signature, byte[] signed_tx);
    }
}