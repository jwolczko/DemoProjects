namespace Vote.Data.Entities
{
    public abstract class StoredProcedureResult
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
