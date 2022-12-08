using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameAnalyticCore.Models
{
    public class CoreDbContext: DbContext
    {
        public CoreDbContext(DbContextOptions options) : base(options) { }
        public DbSet<GameUser> GameUsers
        {
            get;
            set;
        }
        public DbSet<Events> Events { get; set; }
    }
}
