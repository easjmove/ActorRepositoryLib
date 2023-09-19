using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActorRepositoryLib
{
    public class ActorsDbContext : DbContext
    {
        public ActorsDbContext(DbContextOptions<ActorsDbContext> options) : base(options) { }

        public DbSet<Actor> Actors { get; set; }
    }
}
