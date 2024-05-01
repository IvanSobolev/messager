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
            .WithOne(t => t.ConnectUser)
            .HasForeignKey(t => t.UserId);

        modelBuilder.Entity<Message>()
            .HasOne(m => m.ToUser)
            .WithMany(u => u.ReceivedMessages)
            .HasForeignKey(m => m.ToId);

        modelBuilder.Entity<Message>()
            .HasOne(m => m.FromUser)
            .WithMany(u => u.SentMessages)
            .HasForeignKey(m => m.FromId);

        modelBuilder.Entity<Content>()
            .HasOne(c => c.message)
            .WithMany(m => m.Context)
            .HasForeignKey(c => c.MessageId);
    }
}