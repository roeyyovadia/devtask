using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace devtask.Objects
{
    public class Transaction
    {
        [Key]
        public Guid id { get; set; }
        [Column]
        public Status from { get; set; }
        [Column]
        public Status to { get; set; }

        public Transaction()
        {
        }

        public Transaction(Status from , Status to)
        {
            if (!isVaild(from,to))
                return;
            id = new Guid();
            this.from = from;
            this.to = to;
        }

        private bool isVaild(Status from , Status to)
        {
            if (isInitToOrphan(from,to))
                return false;
            if (isFinal(from, to))
                return false;
            return true;
        }

        private bool isInitToOrphan(Status from, Status to)
        {
            if (from.mode == Enum.statusMode.initial && to.mode == Enum.statusMode.orphan)
                return true;
            return false;
        }

        private bool isFinal(Status from, Status to)
        {
            if (from.mode == Enum.statusMode.final)
                return true;
            return false;
        }
    }
}
