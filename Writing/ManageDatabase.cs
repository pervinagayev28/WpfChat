using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Writing
{
    public class MessageContext : DbContext
    {
        public DbSet<Message> Message { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-47DGCU6\\SQL;Database=Message;User Id=sa;Password=pervina9266_1;TrustServerCertificate=True;");
        }
    }

    public class Message
    {
        public int Id { get; set; }
        public string check { get; set; }
        public string Content { get; set; }
        public DateTime date { get; set; }
    }

    
}