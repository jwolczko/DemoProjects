namespace Vote.Model
{
    public abstract class Person
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Name => $"{FirstName} {LastName}";

        public virtual PersonType Type{ get; set; }
    }
}
