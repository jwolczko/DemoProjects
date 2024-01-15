namespace Vote.Data.Entities
{
    public class Voter : StoredProcedureResult
    {
        public bool HasVote { get; set; }
    }
}
