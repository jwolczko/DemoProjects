namespace Vote.Model
{
    public class Vote
    {
        public long Id { get; set; }

        public Voter Voter { get; set; }
        public Candidate Candidate { get; set; }
    }
}
