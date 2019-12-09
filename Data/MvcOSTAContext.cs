using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OpenShiftTestApp.Models;

namespace OpenShiftTestApp.Data
{
    public class MvcOSTAContext : DbContext
    {
        public MvcOSTAContext(DbContextOptions<MvcOSTAContext> options)
            : base(options)
        {
        }
        public DbSet<SomeEntity> SomeEntity { get; set; }
    }
}
