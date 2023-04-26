using Microsoft.EntityFrameworkCore;
using MessageAPI.Models;

namespace MessageAPI.Data
{
    public class MessageContext : DbContext
    {
        public MessageContext(DbContextOptions<MessageContext> options): base(options){}

        public DbSet<Email> Emails { get; set; }
        public DbSet<Osoba> Osobe { get; set; }
        public DbSet<Poruka> Poruke { get; set; }

    }
}
