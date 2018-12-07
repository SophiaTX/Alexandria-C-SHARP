namespace Alexandria.net.Input
{
    public class VoteForWitness
    {
        public string voting_account { get; set; }
        public string witness_to_vote_for { get; set; }
        public bool approve { get; set; }
    }
}