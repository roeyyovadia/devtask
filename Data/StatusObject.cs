using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using devtask.Objects;

namespace Database
{
    public class StatusObject : DbContext
    {
        public StatusObject (DbContextOptions<StatusObject> options)
            : base(options)
        {
        }

        public DbSet<devtask.Objects.Status> Status { get; set; }
    }
}
