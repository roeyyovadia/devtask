using devtask.Util;
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

        public Transaction(Status from, Status to)
        {
            if (!isVaild(from, to))
                return;
            id = new Guid();
            this.from = from;
            this.to = to;
        }

        private bool isVaild(Status from, Status to)
        {
            if (isInitToOrphan(from, to))
                return false;
            if (isFinal(from))
                return false;
            return true;
        }

        //Extra protection Maybe not needed
        private bool isInitToOrphan(Status from, Status to)
        {            
            if (from.labelsLst != null && to.labelsLst != null)
                if (from.labelsLst.Contains(PARAMS.LABEL_INIT) && to.labelsLst.Contains(PARAMS.LABEL_ORPHAN))
                    return true;
            return false;
        }

        //Maybe not needed
        private bool isFinal(Status from)
        {
            if (from.labelsLst != null)
                if (from.labelsLst.Contains(PARAMS.LABEL_FINAL))
                    return true;
            return false;
        }
    }
}
