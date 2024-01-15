using Microsoft.EntityFrameworkCore;
using Vote.Data.Entities;

namespace Vote.Data
{
    public class VoteDb : DbContext
    {
        public VoteDb(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Entities.Vote> Votes { get; set; }
        
        public DbSet<Voter> Voters { get; set; }
        public DbSet<Candidate> Candidates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(e => e.FirstName)
                .HasMaxLength(200)
                .IsUnicode(true);

                entity.Property(e => e.LastName)
                    .HasMaxLength(200)
                    .IsUnicode(true);

                entity.Property(e => e.Type).HasColumnType("int");

                entity.HasMany(e => e.CandidateVots)
                    .WithOne(e => e.Candidate)
                    .HasForeignKey(e => e.IdCandidate)
                    .HasPrincipalKey(e => e.Id);

                entity.HasMany(e => e.VoterVots)
                    .WithOne(e => e.Voter)
                    .HasForeignKey(e => e.IdVoter)
                    .HasPrincipalKey(e => e.Id);

            });

            modelBuilder.Entity<Entities.Vote>(entity =>
            {
                entity.HasKey(p => p.Id);
            });
        }
    }
}