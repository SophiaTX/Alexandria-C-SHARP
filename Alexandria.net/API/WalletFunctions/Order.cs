using System.Collections;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace Alexandria.net.API.WalletFunctions
{
    public partial class Wallet // Order
    {
        /// <summary>
        /// Cancel an order created With create_order
        /// </summary>
        /// <param name="owner">The name Of the account owning the order To cancel_order </param>
        /// <param name="orderid">The unique identifier assigned To the order by its creator</param>
        /// <param name="broadcast">true if you wish to broadcast the transaction.</param>
        /// <returns></returns>
        public string cancel_order(string owner, uint orderid, bool broadcast = true)
        {
            var @params = new ArrayList {owner, orderid, broadcast};
            return call_api(MethodBase.GetCurrentMethod().Name, @params);
        }
        
        /// <summary>
        /// Creates a limit order at the price amount_to_sell / min_to_receive And will deduct amount_to_sell from account
        /// </summary>
        /// <param name="owner">The name Of the account creating the order </param>
        /// <param name="orderId">Is a unique identifier assigned by the creator of the order, it can be reused after the order has been filled </param>
        /// <param name="amountToSell">The amount Of either SBD Or STEEM you wish To sell </param>
        /// <param name="minToReceive">The amount Of the other asset you will receive at a minimum</param>
        /// <param name="fillOrKill">true if you want the order to be killed if it cannot immediately be filled</param>
        /// <param name="expiration">the time the order should expire If it has Not been filled</param>
        /// <param name="broadcast">true if you wish to broadcast the transaction.</param>
        /// <returns></returns>
        public string create_order(string owner, uint orderId, decimal amountToSell, decimal minToReceive,
            bool fillOrKill, uint expiration, bool broadcast = true)
        {
            var @params =
                new ArrayList {owner, orderId, amountToSell, minToReceive, fillOrKill, expiration, broadcast};
            return call_api(MethodBase.GetCurrentMethod().Name, @params);
        }
        
        /// <summary>
        /// Gets the current order book For STEEM:SBD
        /// </summary>
        /// <param name="limit">Maximum number Of orders To return For bids And asks. Max Is 1000.</param>
        /// <returns></returns>
        public string get_order_book(uint limit)
        {
            var @params = new ArrayList {limit};
            return call_api(MethodBase.GetCurrentMethod().Name, @params);
        }
    }
}