namespace Vote.Model
{
    public class Candidate : Person
    {
        public long VotesNumber { get; set; }
        public override PersonType Type => PersonType.Candidate;
    }
}
