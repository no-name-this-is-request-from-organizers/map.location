using Map.Location.Data.Attributes;
using Map.Location.Data.Entity;
using Map.Location.General.Expansions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map.Location.EF
{
    public partial class ServiceDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
