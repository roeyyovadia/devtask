using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using devtask.Objects;

namespace Database
{
    public class TransactionObject : DbContext
    {
        public TransactionObject (DbContextOptions<TransactionObject> options)
            : base(options)
        {
        }

        public DbSet<devtask.Objects.Transaction> Transaction { get; set; }
    }
}
