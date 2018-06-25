using System.Reflection;

using Alexandria.net.Messaging.Responses.DTO;

using Alexandria.net.Communication;
using Alexandria.net.Settings;
using Alexandria.net.Logging;
using Newtonsoft.Json;

namespace Alexandria.net.API.WalletFunctions
{
    public class BroadCastTransactionProcess: RpcConnection
    {
        private readonly ILogger _logger;

        public BroadCastTransactionProcess(IConfig config):base(config)
        {
            var assemblyname = Assembly.GetExecutingAssembly().GetName().Name;
            _logger = new Logger(LoggingType.Server, assemblyname);
        }

        public AccountResponse StartBroadcasting(AccountResponse contentdata)
        {
            var trans = new Transaction(Config);
            var key = new Key(Config);
            var pk = "5KGL7MNAfwCzQ8DAq7DXJsneXagka3KNcjgkRayJoeJUucSLkev";
            
            var transresponse = trans.CreateSimpleTransaction(contentdata);
            if (transresponse == null) return null;
                
            var aboutresponse = trans.About();
            if (aboutresponse == null) return null;
                
            var transaction = JsonConvert.SerializeObject(transresponse.result);
            var digest = key.GetTransactionDigest(transaction, aboutresponse.result.chain_id, new byte[64]);

            var signature = key.SignDigest(digest, pk, new byte[130]);
            var response = key.AddSignature(transaction, signature, new byte[transaction.Length + 200]);
            var finalResponse=trans.BroadcastTransaction(response);
            trans.SerializeTransaction(response);
                
            return finalResponse == null ? null : contentdata;
        }
        
        
    }
}