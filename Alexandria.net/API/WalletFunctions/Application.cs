using System.Reflection;
using Alexandria.net.Communication;
using Alexandria.net.Logging;
using Alexandria.net.Settings;

namespace Alexandria.net.API.WalletFunctions
{
    public class Application:RpcConnection
    {
        private readonly ILogger _logger;
        #region constructor
        public Application(IConfig config, bool wallet = true) : base(config, wallet)
        {
            var assemblyname = Assembly.GetExecutingAssembly().GetName().Name;
            _logger = new Logger(LoggingType.Server, assemblyname);
        }
        #endregion
    }

    #region Public Methods
    
    

    #endregion
}