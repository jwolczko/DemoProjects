namespace Vote.Model
{
    public class Voter : Person
    {
        public override PersonType Type => PersonType.Voter;

        public string HasVote { get; set; }
    }
}