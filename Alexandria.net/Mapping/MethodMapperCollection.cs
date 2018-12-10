using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Alexandria.net.Mapping
{
    /// <summary>
    /// 
    /// </summary>
    public class MethodMapperCollection
    {
        /// <summary>
        /// 
        /// </summary>
        public List<MethodMapper> MethodMapperList { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsonFile"></param>
        public void DeSerialise(string jsonFile)
        {
            MethodMapperList = JsonConvert.DeserializeObject<List<MethodMapper>>(File.ReadAllText(jsonFile));
        }

        /// <summary>
        /// 
        /// </summary>
        public List<MethodMapper> BuildMethodMapperJson(string fullFilename)
        {

            var coll = new List<MethodMapper>
            {
                new MethodMapper
                    {MethodName = "Vote", BlockChainMethodName = "vote", ObjectTypeName = "VoteParams"},


                new MethodMapper
                {
                    MethodName = "AccountExists", BlockChainMethodName = "account_exist", ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "HasPrivateKeys", BlockChainMethodName = "hasPrivateKeys",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "GetActiveAuthority", BlockChainMethodName = "get_active_authority",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "GetOwnerAuthority", BlockChainMethodName = "get_owner_authority",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                    {MethodName = "GetMemoKey", BlockChainMethodName = "get_memo_key", ObjectTypeName = "VoteParams"},
                new MethodMapper
                {
                    MethodName = "GetAccountBalance", BlockChainMethodName = "get_account_balance",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "GetVestingBalance", BlockChainMethodName = "get_vesting_balance",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "CreateSimpleAuthority", BlockChainMethodName = "create_simple_authority",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "CreateSimpleMultisigAuthority",
                    BlockChainMethodName = "create_simple_multisig_authority",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "CreateSimpleManagedAuthority",
                    BlockChainMethodName = "create_simple_managed_authority",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "CreateSimpleMultiManagedAuthority",
                    BlockChainMethodName = "create_simple_multisig_managed_authority", ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "UpdateAccount", BlockChainMethodName = "update_account", ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "DepositVesting", BlockChainMethodName = "depositVesting",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "WithdrawVestings", BlockChainMethodName = "withdrawVestings",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "VoteForWitness", BlockChainMethodName = "vote_for_witness",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "UpdateToWitness", BlockChainMethodName = "updateToWitness",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                    {MethodName = "GetAccount", BlockChainMethodName = "get_account", ObjectTypeName = "VoteParams"},
                new MethodMapper
                {
                    MethodName = "CreateAccount", BlockChainMethodName = "create_account", ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                    {MethodName = "Transfer", BlockChainMethodName = "transfer", ObjectTypeName = "VoteParams"},
                new MethodMapper
                {
                    MethodName = "GetAccountUiaBalance", BlockChainMethodName = "getAccountUiaBalance",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                    {MethodName = "CreateUia", BlockChainMethodName = "createUia", ObjectTypeName = "VoteParams"},
                new MethodMapper
                    {MethodName = "IssueUia", BlockChainMethodName = "issueUia", ObjectTypeName = "VoteParams"},
                new MethodMapper
                    {MethodName = "BurnUia", BlockChainMethodName = "burnUia", ObjectTypeName = "VoteParams"},
                new MethodMapper
                {
                    MethodName = "GetUiaAuthority", BlockChainMethodName = "getUiaAuthority",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "HasUiaPrivateKey", BlockChainMethodName = "hasUiaPrivateKey",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "DeleteAccount", BlockChainMethodName = "delete_account", ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "SuggestBrainKey", BlockChainMethodName = "suggest_brain_key",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "NormalizeBrainKey", BlockChainMethodName = "normalize_brain_key",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper {MethodName = "About", BlockChainMethodName = "about", ObjectTypeName = "VoteParams"},
                new MethodMapper
                    {MethodName = "Challenge", BlockChainMethodName = "challenge", ObjectTypeName = "VoteParams"},
                new MethodMapper
                    {MethodName = "GetBlock", BlockChainMethodName = "get_block", ObjectTypeName = "VoteParams"},
                new MethodMapper
                {
                    MethodName = "GetFeedHistory", BlockChainMethodName = "get_feed_history",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "GetTransaction", BlockChainMethodName = "get_transaction",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "BroadcastTransaction", BlockChainMethodName = "broadcast_transaction",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "CreateSimpleTransaction", BlockChainMethodName = "create_simple_transaction",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "CreateTransaction", BlockChainMethodName = "create_transaction",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                    {MethodName = "PublishFeed", BlockChainMethodName = "publish_feed", ObjectTypeName = "VoteParams"},
                new MethodMapper
                {
                    MethodName = "SetTransactionExpiration", BlockChainMethodName = "set_transaction_expiration",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "SetVotingProxy", BlockChainMethodName = "set_voting_proxy",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "WithdrawVesting", BlockChainMethodName = "withdraw_vesting",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "TransferToVesting", BlockChainMethodName = "transfer_to_vesting",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "GetOpsInBlock", BlockChainMethodName = "get_ops_in_block",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "GetActiveWitnesses", BlockChainMethodName = "get_active_witnesses",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "GetMinerQueue ", BlockChainMethodName = "get_miner_queue",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                    {MethodName = "GetWitness ", BlockChainMethodName = "get_witness", ObjectTypeName = "VoteParams"},
                new MethodMapper
                {
                    MethodName = "ListWitnesses ", BlockChainMethodName = "list_witnesses",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "UpdateWitness ", BlockChainMethodName = "update_witness",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper {MethodName = "Help ", BlockChainMethodName = "help", ObjectTypeName = "VoteParams"},
                new MethodMapper {MethodName = "Info ", BlockChainMethodName = "info", ObjectTypeName = "VoteParams"},
                new MethodMapper
                {
                    MethodName = "SerializeTransaction", BlockChainMethodName = "serialize_transaction",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "MakeCustomJsonOperation", BlockChainMethodName = "make_custom_json_operation",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "MakeCustomJsonOperationAsync", BlockChainMethodName = "make_custom_json_operation",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "GetReceivedDocuments", BlockChainMethodName = "get_received_documents",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "MakeCustomBinaryOperation", BlockChainMethodName = "make_custom_binary_operation",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "CreateApplication", BlockChainMethodName = "create_application",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "UpdateApplication", BlockChainMethodName = "update_application",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "BuyApplication", BlockChainMethodName = "buy_application",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "DeleteApplication", BlockChainMethodName = "delete_application",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "CancelApplicationBuying", BlockChainMethodName = "cancel_application_buying",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "GetApplicationBuyings", BlockChainMethodName = "get_application_buyings",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "GetApplications", BlockChainMethodName = "get_applications",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                    {MethodName = "GetConfig", BlockChainMethodName = "get_config", ObjectTypeName = "VoteParams"},
                new MethodMapper
                {
                    MethodName = "GetDynamicGlobalProperties", BlockChainMethodName = "get_dynamic_global_properties",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "GetChainProperties", BlockChainMethodName = "get_chain_properties",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "GetCurrentMedianHistoryPrice",
                    BlockChainMethodName = "get_current_median_history_price",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "GetWitnessSchedule", BlockChainMethodName = "get_witness_schedule",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "GetHardForkVersion", BlockChainMethodName = "get_hardfork_version",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "GetNextScheduledHardfork", BlockChainMethodName = "get_next_scheduled_hardfork",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                    {MethodName = "GetAccounts", BlockChainMethodName = "get_accounts", ObjectTypeName = "VoteParams"},
                new MethodMapper
                {
                    MethodName = "LookupAccountNames", BlockChainMethodName = "lookup_account_names",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "LookupAccounts", BlockChainMethodName = "lookup_accounts",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "GetAccountCount", BlockChainMethodName = "get_account_count",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "GetOwnerHistory", BlockChainMethodName = "get_owner_history",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "GetRecoveryRequest", BlockChainMethodName = "get_recovery_request",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "GetBlockHeader", BlockChainMethodName = "get_block_header",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "GetWitnesses", BlockChainMethodName = "get_witnesses", ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "GetConversionRequests ", BlockChainMethodName = "get_conversion_requests",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "GetWitnessByAccount", BlockChainMethodName = "get_witness_by_account",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "GetWitnessesByVote", BlockChainMethodName = "get_witnesses_by_vote",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "GetWitnessCount", BlockChainMethodName = "get_witness_count",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "GetActiveVotes", BlockChainMethodName = "get_active_votes",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                    {MethodName = "GetContent", BlockChainMethodName = "get_content", ObjectTypeName = "VoteParams"},
                new MethodMapper
                {
                    MethodName = "GetContentReplies", BlockChainMethodName = "get_content_replies",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "GetRepliesByLastUpdate", BlockChainMethodName = "get_replies_by_last_update",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "GetDiscussionsByAuthorBeforeDate",
                    BlockChainMethodName = "get_discussions_by_author_before_date", ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "GetAccountHistory", BlockChainMethodName = "get_account_history",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "GetAccountNameFromSeed", BlockChainMethodName = "get_account_name_from_seed",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "CalculateFee", BlockChainMethodName = "calculate_fee", ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                    {MethodName = "AddFee", BlockChainMethodName = "add_fee", ObjectTypeName = "VoteParams"},
                new MethodMapper
                {
                    MethodName = "GetTransactionDigestServer", BlockChainMethodName = "get_transaction_digest",
                    ObjectTypeName = "VoteParams"
                },
                new MethodMapper
                {
                    MethodName = "AddSignatureServer", BlockChainMethodName = "add_signature",
                    ObjectTypeName = "VoteParams"
                }
            };
            File.WriteAllText(fullFilename, JsonConvert.SerializeObject(coll));
            return coll;
        }
    }
}