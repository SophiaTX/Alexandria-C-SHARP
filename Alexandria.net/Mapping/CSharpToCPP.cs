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
        private const string  GetUiaAuthority = "getUiaAuthority";
        private const string HasUiaPrivateKey = "hasUiaPrivateKey";
        private const string DeleteAccount = "delete_account";
        private const string GenerateKeyPair = "generateKeyPair";
        private const string GenerateKeyPairFromBrainKey = "generateKeyPairFromBrainKey";
        private const string SignAndSendOperation = "signAndSendOperation";
        private const string SignAndSendTransaction = "signAndSendTransaction";
        private const string SignDigest = "signDigest";
        private const string GetPublicKey = "getPublicKey";
        private const string FromBase58 = "fromBase58";
        private const string ToBase58 = "toBase58";
        private const string VerifySignature = "verifySignature";
        private const string EncryptDocument = "encryptDocument";
        private const string DecryptDocument = "decryptDocument";
        private const string EncryptData = "encryptData";
        private const string DecryptData = "decryptData";
        private const string ListKeys = "list_keys";
        private const string SuggestBrainKey = "suggest_brain_key";
        private const string NormalizeBrainKey = "normalize_brain_key";
        
        
        
        
        
        
        
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetValue(string value)
        {
            switch (value)
            {
                case Vote:
                    return Vote;
                case AccountExists:
                    return AccountExists;
                case HasPrivateKeys:
                    return HasPrivateKeys;
                case HasAccountOwnerPrivateKey:
                    return HasAccountActivePrivateKey;
                case HasAccountMemoPrivateKey:
                    return HasAccountMemoPrivateKey;
                case GetActiveAuthority:
                    return GetActiveAuthority;
                case GetOwnerAuthority:
                    return GetOwnerAuthority;
                case GetMemoKey:
                    return GetMemoKey;
                case GetAccountBalance:
                    return GetAccountBalance;
                case GetVestingBalance:
                    return GetVestingBalance;
                case CreateSimpleAuthority:
                    return CreateSimpleAuthority;
                case CreateSimpleMultisigAuthority:
                    return CreateSimpleMultisigAuthority;
                case CreateSimpleManagedAuthority:
                    return CreateSimpleManagedAuthority;
                case CreateSimpleMultiManagedAuthority:
                    return CreateSimpleMultiManagedAuthority;
                case UpdateAccount:
                    return UpdateAccount;
                case DepositVesting:
                    return DepositVesting;
                case WithdrawVestings:
                    return WithdrawVestings;
                case VoteForWitness:
                    return VoteForWitness;
                case UpdateToWitness:
                    return UpdateToWitness;
                case GetAccount:
                    return GetAccount;
                case CreateAccount:
                    return CreateAccount;
                case Transfer:
                    return Transfer;
                case GetAccountUiaBalance:
                    return GetAccountUiaBalance;
                case CreateUia:
                    return CreateUia;
                case IssueUia:
                    return IssueUia;
                case BurnUia:
                    return BurnUia;
                case GetUiaAuthority:
                    return GetUiaAuthority;
                case HasUiaPrivateKey:
                    return HasUiaPrivateKey;
                case DeleteAccount:
                    return DeleteAccount;
                case GenerateKeyPair:
                    return GenerateKeyPair;
                case GenerateKeyPairFromBrainKey:
                    return GenerateKeyPairFromBrainKey;
                case SignAndSendOperation:
                    return SignAndSendOperation;
                case SignAndSendTransaction:
                    return SignAndSendTransaction;
                case SignDigest:
                    return SignDigest;
                case GetPublicKey:
                    return GetPublicKey;
                case FromBase58:
                    return FromBase58;
                case ToBase58:
                    return ToBase58;
                case VerifySignature:
                    return VerifySignature;
                case EncryptDocument:
                    return EncryptDocument;
                case DecryptDocument:
                    return DecryptDocument;
                case EncryptData:
                    return EncryptData;
                case DecryptData:
                    return DecryptData;
                case ListKeys:
                    return ListKeys;
                case SuggestBrainKey:
                    return SuggestBrainKey;
                case NormalizeBrainKey:
                    return NormalizeBrainKey;

            }

            return string.Empty;
        }
    }
}