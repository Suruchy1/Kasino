
using Kasino.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kasino.Infrastructure.Data
{
    public class KasinoDbContext : DbContext
    {
        public KasinoDbContext(DbContextOptions<KasinoDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<IdentityVerification> IdentityVerifications { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<BetSelection> BetSelections { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<SportEvent> SportEvents { get; set; }
        public DbSet<Odds> Odds { get; set; }
        public DbSet<Bonus> Bonuses { get; set; }
        public DbSet<SlotGame> SlotGames { get; set; }
        public DbSet<UserBonus> UserBonuses { get; set; }
        public DbSet<BonusUsage> BonusUsages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey(x => x.UserId);
            modelBuilder.Entity<Role>().HasKey(x => x.RoleId);
            modelBuilder.Entity<IdentityVerification>().HasKey(x => x.VerificationId);
            modelBuilder.Entity<Wallet>().HasKey(x => x.WalletId);
            modelBuilder.Entity<Transaction>().HasKey(x => x.TransactionId);
            modelBuilder.Entity<Bet>().HasKey(x => x.BetId);
            modelBuilder.Entity<BetSelection>().HasKey(x => x.SelectionId);
            modelBuilder.Entity<Sport>().HasKey(x => x.SportId);
            modelBuilder.Entity<SportEvent>().HasKey(x => x.EventId);
            modelBuilder.Entity<Odds>().HasKey(x => x.OddsId);
            modelBuilder.Entity<Bonus>().HasKey(x => x.BonusId);
            modelBuilder.Entity<SlotGame>().HasKey(x => x.GameId);
            modelBuilder.Entity<UserBonus>().HasKey(x => x.UserBonusId);
            modelBuilder.Entity<BonusUsage>().HasKey(x => x.UsageId);

            modelBuilder.Entity<User>()
                .HasIndex(x => x.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasOne<Role>()
                .WithMany()
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Wallet>()
                .HasIndex(x => x.UserId)
                .IsUnique();

            modelBuilder.Entity<IdentityVerification>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Wallet>()
                .HasOne<User>()
                .WithOne()
                .HasForeignKey<Wallet>(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne<Wallet>()
                .WithMany()
                .HasForeignKey(x => x.WalletId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Bet>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BetSelection>()
                .HasOne<Bet>()
                .WithMany()
                .HasForeignKey(x => x.BetId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BetSelection>()
                .HasOne<SportEvent>()
                .WithMany()
                .HasForeignKey(x => x.EventId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BetSelection>()
                .HasOne<Odds>()
                .WithMany()
                .HasForeignKey(x => x.OddsId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SportEvent>()
                .HasOne<Sport>()
                .WithMany()
                .HasForeignKey(x => x.SportId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SportEvent>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Odds>()
                .HasOne<SportEvent>()
                .WithMany()
                .HasForeignKey(x => x.EventId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Odds>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SlotGame>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SlotGame>()
                .HasOne<Bonus>()
                .WithMany()
                .HasForeignKey(x => x.BonusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserBonus>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserBonus>()
                .HasOne<Bonus>()
                .WithMany()
                .HasForeignKey(x => x.BonusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserBonus>()
                .HasOne<SlotGame>()
                .WithMany()
                .HasForeignKey(x => x.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BonusUsage>()
                .HasOne<UserBonus>()
                .WithMany()
                .HasForeignKey(x => x.UserBonusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BonusUsage>()
                .HasOne<Bet>()
                .WithMany()
                .HasForeignKey(x => x.BetId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Wallet>()
                .Property(x => x.Balance)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Transaction>()
                .Property(x => x.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Bet>()
                .Property(x => x.StakeAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Bet>()
                .Property(x => x.PotentialPayout)
                .HasPrecision(18, 2);

            modelBuilder.Entity<BetSelection>()
                .Property(x => x.OddsValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Odds>()
                .Property(x => x.OddsValue)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Bonus>()
                .Property(x => x.Value)
                .HasPrecision(18, 4);

            modelBuilder.Entity<BonusUsage>()
                .Property(x => x.AppliedValue)
                .HasPrecision(18, 4);
        }
    }
}
