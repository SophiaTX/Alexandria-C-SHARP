namespace Alexandria.net.Mapping
{
    /// <summary>
    /// C-Sharp to cpp converter class
    /// </summary>
    public class CSharpToCpp
    {
        private const string Vote = "vote";
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
        /// <returns>CPP function name</returns>
        public string GetValue(string value)
        {
            switch (value)
            {
                case "Vote":
                    return Vote;
                case "AccountExists":
                    return AccountExists;
                case "HasPrivateKeys":
                    return HasPrivateKeys;               
                case "GetActiveAuthority":
                    return GetActiveAuthority;
                case "GetOwnerAuthority":
                    return GetOwnerAuthority;
                case "GetMemoKey":
                    return GetMemoKey;
                case "GetAccountBalance":
                    return GetAccountBalance;
                case "GetVestingBalance":
                    return GetVestingBalance;
                case "CreateSimpleAuthority":
                    return CreateSimpleAuthority;
                case "CreateSimpleMultisigAuthority":
                    return CreateSimpleMultisigAuthority;
                case "CreateSimpleManagedAuthority":
                    return CreateSimpleManagedAuthority;
                case "CreateSimpleMultiManagedAuthority":
                    return CreateSimpleMultiManagedAuthority;
                case "UpdateAccount":
                    return UpdateAccount;
                case "DepositVesting":
                    return DepositVesting;
                case "WithdrawVestings":
                    return WithdrawVestings;
                case "VoteForWitness":
                    return VoteForWitness;
                case "UpdateToWitness":
                    return UpdateToWitness;
                case "GetAccount":
                    return GetAccount;
                case "CreateAccount":
                    return CreateAccount;
                case "Transfer":
                    return Transfer;
                case "GetAccountUiaBalance":
                    return GetAccountUiaBalance;
                case "CreateUia":
                    return CreateUia;
                case "IssueUia":
                    return IssueUia;
                case "BurnUia":
                    return BurnUia;
                case "GetUiaAuthority":
                    return GetUiaAuthority;
                case "HasUiaPrivateKey":
                    return HasUiaPrivateKey;
                case "DeleteAccount":
                    return DeleteAccount;
                case "SuggestBrainKey":
                    return SuggestBrainKey;
                case "NormalizeBrainKey":
                    return NormalizeBrainKey;
                case "About":
                    return About;
                case "Challenge":
                    return Challenge;
                case "GetBlock":
                    return GetBlock;
                case "GetFeedHistory":
                    return GetFeedHistory;
                case "GetTransaction":
                    return GetTransaction;
                case "BroadcastTransaction":
                    return BroadcastTransaction;
                case "CreateSimpleTransactionTest":
                case "CreateSimpleTransaction":
                    return CreateSimpleTransaction;
                case "CreateTransaction":
                    return CreateTransaction;
                case "PublishFeed":
                    return PublishFeed;
                case "SetTransactionExpiration":
                    return SetTransactionExpiration;
                case "SetVotingProxy":
                    return SetVotingProxy;
                case "WithdrawVesting":
                    return WithdrawVesting;
                case "TransferToVesting":
                    return TransferToVesting;
                case "GetOpsInBlock":
                    return GetOpsInBlock;
                case "GetActiveWitnesses":
                    return GetActiveWitnesses;
                case "GetMinerQueue":
                    return GetMinerQueue;
                case "GetWitness":
                    return GetWitness;
                case "ListWitnesses":
                    return ListWitnesses;
                case "UpdateWitness":
                    return UpdateWitness;
                case "Help":
                    return Help;
                case "Info":
                    return Info;
                case "SerializeTransaction":
                    return SerializeTransaction;
                case "MakeCustomJsonOperation":
                    return MakeCustomJsonOperation;
                case "GetReceivedDocuments":
                    return GetReceivedDocuments;
                case "MakeCustomBinaryOperation":
                    return MakeCustomBinaryOperation;
                case "CreateApplication":
                    return CreateApplication ;
                case "DeleteApplication":
                    return DeleteApplication;
                case "UpdateApplication":
                    return UpdateApplication;
                case "BuyApplication":
                    return BuyApplication;
                case "CancelApplicationBuying":
                    return CancelApplicationBuying;
                case "GetApplicationBuyings":
                    return GetApplicationBuyings; 
                case "GetApplications":
                    return GetApplications;
                case "GetConfig":
                    return GetConfig;
                case "GetDynamicGlobalProperties":
                    return GetDynamicGlobalProperties;
                case "GetChainProperties":
                    return GetChainProperties;
                case "GetCurrentMedianHistoryPrice":
                    return GetCurrentMedianHistoryPrice;
                case "GetWitnessSchedule":
                    return GetWitnessSchedule;
                case "GetHardforkVersion":
                    return GetHardForkVersion;
                case "GetNextScheduledHardfork":
                    return GetNextScheduledHardfork;
                case "GetAccounts":
                    return GetAccounts; 
                case "LookupAccountNames":
                    return LookupAccountNames; 
                case "LookupAccounts":
                    return LookupAccounts;
                case "GetAccountCount":
                    return GetAccountCount; 
                case "GetOwnerHistory":
                    return GetOwnerHistory;
                case "GetRecoveryRequest":
                    return GetRecoveryRequest; 
                case "GetBlockHeader":
                    return GetBlockHeader; 
                case "GetWitnesses":
                    return GetWitnesses;
                case "GetConversionRequests":
                    return GetConversionRequests; 
                case "GetWitnessByAccount":
                    return GetWitnessByAccount;
                case "GetWitnessesByVote":
                    return GetWitnessesByVote;
                case "GetWitnessCount":
                    return GetWitnessCount;
                case "GetActiveVotes":
                    return GetActiveVotes;
                case "GetContent":
                    return GetContent;
                case "GetContentReplies":
                    return GetContentReplies;
                case "GetRepliesByLastUpdate":
                    return GetRepliesByLastUpdate;
                case "GetDiscussionsByAuthorBeforeDate":
                    return GetDiscussionsByAuthorBeforeDate;
                case "GetAccountHistory":
                    return GetAccountHistory;
                case "GetAccountNameFromSeed":
                    return GetAccountNameFromSeed;
                case "CalculateFee":
                    return CalculateFee;
                case "AddFee":
                    return AddFee;
                case "GetTransactionDigestServer":
                    return GetTransactionDigestServer;
                case "AddSignatureServer":
                    return AddSignatureServer;
                
            }
            return string.Empty;
        }
    }
}