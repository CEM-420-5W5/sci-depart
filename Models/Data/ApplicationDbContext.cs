using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace Models.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public const string ADMIN_ROLE = "admin";

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Card>().HasData(Seed.SeedCards());

        builder.Entity<IdentityUser>().HasData(Seed.SeedUsers());
        builder.Entity<IdentityRole>().HasData(Seed.SeedRoles());
        builder.Entity<IdentityUserRole<string>>().HasData(Seed.SeedUserRoles());

        builder.Entity<IdentityUser>().HasData(Seed.SeedTestUsers());
        builder.Entity<Player>().HasData(Seed.SeedTestPlayers());

        // Lorsque le modèle de données se complexifient, il faut éventuellement utiliser Fluent API
        // https://learn.microsoft.com/en-us/ef/ef6/modeling/code-first/fluent/types-and-properties
        // pour préciser certaines relations.
        // Nous allons couvrir ce sujet plus tard dans la session
        builder.Entity<Match>()
            .HasOne(m => m.PlayerDataA)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Match>()
            .HasOne(m => m.PlayerDataB)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<PlayableCard>()
            .HasOne(pc => pc.CardsPileOwner)
            .WithMany(mp => mp.CardsPile)
            .HasForeignKey(pc => pc.CardsPileOwnerId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<PlayableCard>()
            .HasOne(pc => pc.HandOwner)
            .WithMany(mp => mp.Hand)
            .HasForeignKey(pc => pc.HandOwnerId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<PlayableCard>()
            .HasOne(pc => pc.BattleFieldOwner)
            .WithMany(mp => mp.BattleField)
            .HasForeignKey(pc => pc.BattleFieldOwnerId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<PlayableCard>()
            .HasOne(pc => pc.GraveyardOwner)
            .WithMany(mp => mp.Graveyard)
            .HasForeignKey(pc => pc.GraveyardOwnerId)
            .OnDelete(DeleteBehavior.NoAction);
        // Fin de Fluent API
    }

    public DbSet<Card> Cards { get; set; } = default!;

    public DbSet<Player> Players { get; set; } = default!;

    public DbSet<Match> Matches { get; set; } = default!;

    public DbSet<MatchPlayerData> MatchPlayersData { get; set; } = default!;
}
