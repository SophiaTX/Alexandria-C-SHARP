namespace Alexandria.net.Messaging.Responses.DTO
{
    public class AboutData
    {
        public string blockchain_version { get; set; }
        public string client_version { get; set; }
        public string steem_revision { get; set; }
        public string steem_revision_age { get; set; }
        public string fc_revision { get; set; }
        public string fc_revision_age { get; set; }
        public string compile_date { get; set; }
        public string boost_version { get; set; }
        public string openssl_version { get; set; }
        public string build { get; set; }
        public string server_blockchain_version { get; set; }
        public string server_steem_revision { get; set; }
        public string server_fc_revision { get; set; }
        public string chain_id { get; set; }
    }
}