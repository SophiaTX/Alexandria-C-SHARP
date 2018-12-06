namespace Alexandria.net.Mapping
{
    /// <summary>
    /// C-Sharp to cpp converter class
    /// </summary>
    public class CSharpToCpp
    {
        private const string  Vote = "vote";
        private const string AccountExists = "account_exist";
        private const string HasPrivateKeys = "hasPrivateKeys";
        private const string GetActiveAuthority = "get_active_authority";
        private const string GetOwnerAuthority = "get_owner_authority";
        private const string GetMemoKey = "get_memo_key";
        private const string GetAccountBalance = "get_account_balance";
        private const string GetVestingBalance = "get_vesting_balance";
        private const string CreateSimpleAuthority = "create_simple_authority";
        private const string CreateSimpleMultisigAuthority = "create_simple_multisig_authority";
        private const string CreateSimpleManagedAuthority = "create_simple_managed_authority";
        private const string CreateSimpleMultiManagedAuthority = "create_simple_multisig_managed_authority";
        private const string UpdateAccount = "update_account";
        private const string DepositVesting = "depositVesting";
        private const string WithdrawVestings = "withdrawVestings";
        private const string VoteForWitness = "vote_for_witness";
        private const string UpdateToWitness = "updateToWitness";
        private const string GetAccount = "get_account";
        private const string CreateAccount = "create_account";
        private const string Transfer = "transfer";
        private const string GetAccountUiaBalance = "getAccountUiaBalance";
        private const string CreateUia = "createUia";
        private const string IssueUia = "issueUia";
        private const string BurnUia = "burnUia";
        private const string GetUiaAuthority = "getUiaAuthority";
        private const string HasUiaPrivateKey = "hasUiaPrivateKey";
        private const string DeleteAccount = "delete_account";
        private const string SuggestBrainKey = "suggest_brain_key";
        private const string NormalizeBrainKey = "normalize_brain_key";
        private const string About = "about";
        private const string Challenge = "challenge";
        private const string GetBlock = "get_block";
        private const string GetFeedHistory = "get_feed_history";
        private const string GetTransaction = "get_transaction";
        private const string BroadcastTransaction = "broadcast_transaction";
        private const string CreateSimpleTransaction = "create_simple_transaction";
        private const string CreateTransaction = "create_transaction";
        private const string PublishFeed = "publish_feed";
        private const string SetTransactionExpiration = "set_transaction_expiration";
        private const string SetVotingProxy = "set_voting_proxy";
        private const string WithdrawVesting = "withdraw_vesting";
        private const string TransferToVesting = "transfer_to_vesting";
        private const string GetOpsInBlock = "get_ops_in_block";
        private const string GetActiveWitnesses = "get_active_witnesses";
        private const string GetMinerQueue  = "get_miner_queue";
        private const string GetWitness  = "get_witness";
        private const string ListWitnesses  = "list_witnesses";
        private const string UpdateWitness  = "update_witness";
        private const string Help  = "help";
        private const string Info  = "info";
        private const string SerializeTransaction = "serialize_transaction";
        private const string MakeCustomJsonOperation = "make_custom_json_operation";
        private const string MakeCustomJsonOperationAsync = "make_custom_json_operation";
        private const string GetReceivedDocuments = "get_received_documents";
        private const string MakeCustomBinaryOperation = "make_custom_binary_operation";
        private const string CreateApplication = "create_application";
        private const string UpdateApplication = "update_application";
        private const string BuyApplication = "buy_application";
        private const string DeleteApplication = "delete_application";
        private const string CancelApplicationBuying = "cancel_application_buying";
        private const string GetApplicationBuyings = "get_application_buyings";
        private const string GetApplications = "get_applications";
        private const string GetConfig = "get_config";
        private const string GetDynamicGlobalProperties = "get_dynamic_global_properties";
        private const string GetChainProperties = "get_chain_properties";
        private const string GetCurrentMedianHistoryPrice = "get_current_median_history_price";
        private const string GetWitnessSchedule = "get_witness_schedule";
        private const string GetHardForkVersion = "get_hardfork_version";
        private const string GetNextScheduledHardfork = "get_next_scheduled_hardfork";
        private const string GetAccounts = "get_accounts";
        private const string LookupAccountNames = "lookup_account_names";
        private const string LookupAccounts = "lookup_accounts";
        private const string GetAccountCount = "get_account_count";
        private const string GetOwnerHistory = "get_owner_history";
        private const string GetRecoveryRequest = "get_recovery_request";
        private const string GetBlockHeader = "get_block_header";
        private const string GetWitnesses = "get_witnesses";
        private const string GetConversionRequests = "get_conversion_requests";
        private const string GetWitnessByAccount = "get_witness_by_account";
        private const string GetWitnessesByVote = "get_witnesses_by_vote";
        private const string GetWitnessCount = "get_witness_count";
        private const string GetActiveVotes = "get_active_votes";
        private const string GetContent = "get_content";
        private const string GetContentReplies = "get_content_replies";
        private const string GetRepliesByLastUpdate = "get_replies_by_last_update";
        private const string GetDiscussionsByAuthorBeforeDate = "get_discussions_by_author_before_date";
        private const string GetAccountHistory = "get_account_history";
        private const string GetAccountNameFromSeed = "get_account_name_from_seed";
        private const string CalculateFee = "calculate_fee";
        private const string AddFee = "add_fee";
        private const string GetTransactionDigestServer = "get_transaction_digest";
        private const string AddSignatureServer = "add_signature";


        /// <summary>
        /// Switch case to choose cpp calls depending on the c-sharp function names supplied
        /// </summary>
        /// <param name="value">C-Sharp function name</param>
        /// <param name="api"></param>
        /// <returns>CPP function name</returns>
        public string GetValue(string value, string api = "alexandria_api")
        {
            switch (value)
            {
                case "Vote":
                    return $"{api}.Vote";
                case "AccountExists":
                    return $"{api}.account_exist";
                case "HasPrivateKeys":
                    return $"{api}.HasPrivateKeys";               
                case "GetActiveAuthority":
                    return $"{api}.GetActiveAuthority";
                case "GetOwnerAuthority":
                    return $"{api}.GetOwnerAuthority";
                case "GetMemoKey":
                    return $"{api}.GetMemoKey";
                case "GetAccountBalance":
                    return $"{api}.GetAccountBalance";
                case "GetVestingBalance":
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
                    return $"{api}.HasUiaPrivateKey";
                case "DeleteAccount":
                    return $"{api}.DeleteAccount";
                case "SuggestBrainKey":
                    return $"{api}.SuggestBrainKey";
                case "NormalizeBrainKey":
                    return $"{api}.NormalizeBrainKey";
                case "About":
                    return $"{api}.about";
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
                    return $"{api}.GetMinerQueue";
                case "GetWitness":
                    return $"{api}.GetWitness";
                case "ListWitnesses":
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
                    return $"{api}.About";
                    
            }
            return string.Empty;
        }
    }
}