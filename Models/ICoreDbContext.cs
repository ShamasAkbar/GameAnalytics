using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameAnalyticCore.Models
{
    public interface ICoreDbContext : IDisposable
    {
        DbSet<GameUser> GameUsers { get; set; }
        DbSet<Events> Events { get; set; }
    }
}
