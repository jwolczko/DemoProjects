namespace Vote.Data.Entities
{
    public class Candidate : StoredProcedureResult
    {
        public long Votes { get; set; }
    }
}
