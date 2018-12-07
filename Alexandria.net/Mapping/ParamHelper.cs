using System;
using Alexandria.net.Messaging.Params;
using Newtonsoft.Json;

namespace Alexandria.net.Mapping
{
    public class ParamHelper
    {
        public string GetValue(string value, params object[] list )
        {
            var result = string.Empty;
            object obj = null;
            switch (value)
            {
//                case "Vote":
//                    return $"{api}.Vote";
                
                case "GetVestingBalance":
                case "GetOwnerAuthority":
                case "DeleteAccount":
                case "GetActiveAuthority":
                case "GetMemoKey":
                case "GetAccountBalance":
                case "GetReceivedDocuments":
                case "AccountExists":
                case "About":
                    obj = CreateInstance<IParams>(typeof(AccountParams)).GetDetails(list);
                    break;
                /*case "HasPrivateKeys":
                    return $"{api}.HasPrivateKeys";               
                    return $"{api}.GetVestingBalance";
                case "CreateSimpleAuthority":
                    return $"{api}.CreateSimpleAuthority";
                case "CreateSimpleMultisigAuthority":
                    return $"{api}.CreateSimpleMultisigAuthority";
                case "CreateSimpleManagedAuthority":
                    return $"{api}.CreateSimpleManagedAuthority";
                case "CreateSimpleMultiManagedAuthority":
                    return $"{api}.CreateSimpleMultiManagedAuthority";
                case "UpdateAccount":
                    return $"{api}.UpdateAccount";
                case "DepositVesting":
                    return $"{api}.DepositVesting";
                case "WithdrawVestings":
                    return $"{api}.WithdrawVestings";
                case "VoteForWitness":
                    return $"{api}.VoteForWitness";
                case "UpdateToWitness":
                    return $"{api}.UpdateToWitness";
                case "GetAccount":
                    return $"{api}.GetAccount";
                case "CreateAccount":
                    return $"{api}.CreateAccount";
                case "Transfer":
                    return $"{api}.Transfer";
                case "GetAccountUiaBalance":
                    return $"{api}.GetAccountUiaBalance";
                case "CreateUia":
                    return $"{api}.CreateUia";
                case "IssueUia":
                    return $"{api}.IssueUia";
                case "BurnUia":
                    return $"{api}.BurnUia";
                case "GetUiaAuthority":
                    return $"{api}.GetUiaAuthority";
                case "HasUiaPrivateKey":
                    return $"{api}.HasUiaPrivateKey";*/

                /*case "SuggestBrainKey":
                    return $"{api}.SuggestBrainKey";
                case "NormalizeBrainKey":
                    return $"{api}.NormalizeBrainKey";
                case "About":
                    return $"{api}.About";
                case "Challenge":
                    return $"{api}.Challenge";
                case "GetBlock":
                    return $"{api}.GetBlock";
                case "GetFeedHistory":
                    return $"{api}.GetFeedHistory";
                case "GetTransaction":
                    return $"{api}.GetTransaction";
                case "BroadcastTransaction":
                    return $"{api}.BroadcastTransaction";
                case "CreateSimpleTransactionTest":
                case "CreateSimpleTransaction":
                    return $"{api}.CreateSimpleTransaction";
                case "CreateTransaction":
                    return $"{api}.CreateTransaction";
                case "PublishFeed":
                    return $"{api}.PublishFeed";
                case "SetTransactionExpiration":
                    return $"{api}.SetTransactionExpiration";
                case "SetVotingProxy":
                    return $"{api}.SetVotingProxy";
                case "WithdrawVesting":
                    return $"{api}.WithdrawVesting";
                case "TransferToVesting":
                    return $"{api}.TransferToVesting";
                case "GetOpsInBlock":
                    return $"{api}.GetOpsInBlock";
                case "GetActiveWitnesses":
                    return $"{api}.GetActiveWitnesses";
                case "GetMinerQueue":
                    return $"{api}.GetMinerQueue";*/
                case "GetWitness":
                    obj = CreateInstance<IParams>(typeof(OwnerParams)).GetDetails(list);
                    break;
                /*case "ListWitnesses":
                    return $"{api}.ListWitnesses";
                case "UpdateWitness":
                    return $"{api}.UpdateWitness";
                case "Help":
                    return $"{api}.Help";
                case "Info":
                    return $"{api}.Info";
                case "SerializeTransaction":
                    return $"{api}.SerializeTransaction";
                case "MakeCustomJsonOperation":
                    return $"{api}.MakeCustomJsonOperation";
                case "GetReceivedDocuments":
                    return $"{api}.GetReceivedDocuments";
                case "MakeCustomBinaryOperation":
                    return $"{api}.MakeCustomBinaryOperation";
                case "CreateApplication":
                    return $"{api}.CreateApplication";
                case "DeleteApplication":
                    return $"{api}.DeleteApplication";
                case "UpdateApplication":
                    return $"{api}.UpdateApplication";
                case "BuyApplication":
                    return $"{api}.BuyApplication";
                case "CancelApplicationBuying":
                    return $"{api}.CancelApplicationBuying";
                case "GetApplicationBuyings":
                    return $"{api}.GetApplicationBuyings"; 
                case "GetApplications":
                    return $"{api}.GetApplications";
                case "GetConfig":
                    return $"{api}.GetConfig";
                case "GetDynamicGlobalProperties":
                    return $"{api}.GetDynamicGlobalProperties";
                case "GetChainProperties":
                    return $"{api}.GetChainProperties";
                case "GetCurrentMedianHistoryPrice":
                    return $"{api}.GetCurrentMedianHistoryPrice";
                case "GetWitnessSchedule":
                    return $"{api}.GetWitnessSchedule";
                case "GetHardforkVersion":
                    return $"{api}.GetHardForkVersion";
                case "GetNextScheduledHardfork":
                    return $"{api}.GetNextScheduledHardfork";
                case "GetAccounts":
                    return $"{api}.GetAccounts"; 
                case "LookupAccountNames":
                    return $"{api}.LookupAccountNames"; 
                case "LookupAccounts":
                    return $"{api}.LookupAccounts";
                case "GetAccountCount":
                    return $"{api}.GetAccountCount"; 
                case "GetOwnerHistory":
                    return $"{api}.GetOwnerHistory";
                case "GetRecoveryRequest":
                    return $"{api}.GetRecoveryRequest"; 
                case "GetBlockHeader":
                    return $"{api}.GetBlockHeader"; 
                case "GetWitnesses":
                    return $"{api}.GetWitnesses";
                case "GetConversionRequests":
                    return $"{api}.GetConversionRequests"; 
                case "GetWitnessByAccount":
                    return $"{api}.GetWitnessByAccount";
                case "GetWitnessesByVote":
                    return $"{api}.GetWitnessesByVote";
                case "GetWitnessCount":
                    return $"{api}.GetWitnessCount";
                case "GetActiveVotes":
                    return $"{api}.GetActiveVotes";
                case "GetContent":
                    return $"{api}.GetContent";
                case "GetContentReplies":
                    return $"{api}.GetContentReplies";
                case "GetRepliesByLastUpdate":
                    return $"{api}.GetRepliesByLastUpdate";
                case "GetDiscussionsByAuthorBeforeDate":
                    return $"{api}.GetDiscussionsByAuthorBeforeDate";
                case "GetAccountHistory":
                    return $"{api}.GetAccountHistory";
                case "GetAccountNameFromSeed":
                    return $"{api}.GetAccountNameFromSeed";
                case "CalculateFee":
                    return $"{api}.CalculateFee";
                case "AddFee":
                    return $"{api}.AddFee";
                case "GetTransactionDigestServer":
                    return $"{api}.GetTransactionDigestServer";
                case "AddSignatureServer":
                    return $"{api}.AddSignatureServer";
                case "MakeCustomJsonOperationAsync":
                    return $"{api}.MakeCustomJsonOperationAsync";
                case "MakeCustomBinaryOperationAsync":
                    return $"{api}.MakeCustomBinaryOperation";
                case "BroadcastTransactionAsync":
                    return $"{api}.BroadcastTransaction";
                case "CreateSimpleTransactionAsync":
                    return $"{api}.CreateSimpleTransaction";
                case "AboutAsync":
                    return $"{api}.About";*/
                    
            }
            if(obj != null)
                result = JsonConvert.SerializeObject(obj);
            return result;
        }
        
        
        
        private static I CreateInstance<I>(Type objType) where I : class  
        {  
            return Activator.CreateInstance(objType) as I;  
        }  
    }
}