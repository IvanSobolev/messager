using Microsoft.EntityFrameworkCore;

public class MessengerContext : DbContext
{
    public MessengerContext(DbContextOptions<MessengerContext> options)
    : base(options)
    {}

    public DbSet<Token> Tokens { get; set; }
    public DbSet<Content> Contents { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Message> Messages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Определение взаимосвязей между таблицами
        modelBuilder.Entity<User>()
            .HasMany(u => u.Tokens)
            .WithOne()
            .HasForeignKey(t => t.Id);

        modelBuilder.Entity<User>()
            .HasMany(u => u.ReceivedMessages)
            .WithOne(m => m.ToUser)
            .HasForeignKey(m => m.ToId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.SentMessages)
            .WithOne(m => m.FromUser)
            .HasForeignKey(m => m.FromId);
    }
}