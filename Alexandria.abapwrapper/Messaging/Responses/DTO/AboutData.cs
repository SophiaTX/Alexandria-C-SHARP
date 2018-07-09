namespace Alexandria.net.Messaging.Responses.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class AboutData
    {
        public string blockchain_version { get; set; }
        public string client_version { get; set; }
        public string sophiatx_revision { get; set; }
        public string sophiatx_revision_age { get; set; }
        public string fc_revision { get; set; }
        public string fc_revision_age { get; set; }
        public string compile_date { get; set; }
        public string boost_version { get; set; }
        public string openssl_version { get; set; }
        public string build { get; set; }
        public string server_blockchain_version { get; set; }
        public string server_sophiatx_revision { get; set; }
        public string server_fc_revision { get; set; }
        public string chain_id { get; set; }
    }
}