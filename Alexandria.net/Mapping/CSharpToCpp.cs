namespace Alexandria.net.Mapping
{
    /// <summary>
    /// 
    /// </summary>
    public class CSharpToCpp
    {
        private const string Vote = "vote_for_witness";
        private const string AccountExists = "accountExists";
        private const string HasPrivateKeys = "hasPrivateKeys";
        private const string HasAccountOwnerPrivateKey = "hasAccountOwnerPrivateKey";
        private const string HasAccountActivePrivateKey = "hasAccountActivePrivateKey";
        private const string HasAccountMemoPrivateKey = "hasAccountMemoPrivateKey";
        private const string GetActiveAuthority = "getActiveAuthority";
        private const string GetOwnerAuthority = "getOwnerAuthority";
        private const string GetMemoKey = "getMemoKey";
        private const string GetAccountBalance = "getAccountBalance";
        private const string GetVestingBalance = "getVestingBalance";
        private const string CreateSimpleAuthority = "createSimpleAuthority";
        private const string CreateSimpleMultisigAuthority = "createSimpleMultisigAuthority";
        private const string CreateSimpleManagedAuthority = "createSimpleManagedAuthority";
        private const string CreateSimpleMultiManagedAuthority = "createSimpleMultiManagedAuthority";
        private const string UpdateAccount = "updateAccount";
        private const string DepositVesting = "depositVesting";
        private const string WithdrawVestings = "withdrawVestings";
        private const string VoteForWitness = "voteForWitness";
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






        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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
                case "HasAccountOwnerPrivateKey":
                    return HasAccountActivePrivateKey;
                case "HasAccountMemoPrivateKey":
                    return HasAccountMemoPrivateKey;
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
            }

            return string.Empty;
        }
    }
}