using HubChatEjemplo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HubChatEjemplo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserModel> Usuarios { get; set; }
    }
}
