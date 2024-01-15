using System.ComponentModel.DataAnnotations.Schema;

namespace Vote.Data.Entities
{
    [Table("Vote")]
    public class Vote
    {        
        public long Id { get; set; }
        public Person Candidate { get; set; }
        public Person Voter { get; set; }

        [Column("IdCandidate")]
        public long IdCandidate { get; set; }
        [Column("IdVoter")]
        public long IdVoter { get; set; }
    }
}
