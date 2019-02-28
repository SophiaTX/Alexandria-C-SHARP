namespace Alexandria.net.API
{
    /// <summary>
    /// 
    /// </summary>
    public class GetGroupResponse
    {
        public string Admin { get; set; }
        public string GroupName { get; set; }
        public string CurrentGroupName { get; set; }
        public string Description{ get; set; }
        public string [] Members { get; set; }
        public string GroupKey{ get; set; }
        public string CurrentSeq{ get; set; }
        
    }
}