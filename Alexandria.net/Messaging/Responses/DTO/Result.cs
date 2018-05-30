namespace Alexandria.net.Messaging.Responses.DTO
{
    public class Result
    {
        public string id { get; set; }
        public string registrar { get; set; }
        public string name { get; set; }
        public Owner owner { get; set; }
        public Active active { get; set; }
        public Options options { get; set; }
        public RightsToPublish rights_to_publish { get; set; }
        public string statistics { get; set; }
        public int top_n_control_flags { get; set; }
    }
}