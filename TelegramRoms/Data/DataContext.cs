using TelegramRoms.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace TelegramRoms.Data
{
    partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chat>()
                .Property(c => c.ChatId)
                .ValueGeneratedNever();
        }

        public DbSet<Chat> Chats { get; set; }
    }
}
