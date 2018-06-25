namespace Alexandria.net.Messaging.Responses.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class Result
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string registrar { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Owner owner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Active active { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Options options { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RightsToPublish rights_to_publish { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string statistics { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int top_n_control_flags { get; set; }
    }
}