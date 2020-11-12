using devtask.Enum;
using devtask.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace devtask.Objects
{
    public class Status
    {
        [Key]
        public Guid id { get; set; }
        [Column(TypeName = "string")]
        public string name { get; set; }
        [Column]
        public List<string> labelsLst { get; set; }
        //public statusMode mode{ get; set; }


        public Status(string name, bool isFrist)
        {
            id = new Guid();
            this.name = name;
            labelsLst = new List<string>();
            if (isFrist)
                labelsLst.Add(PARAMS.LABEL_INIT);
        }

        public Status(string name, List<string> labelsLst)
        {
            id = new Guid();
            this.name = name;
            this.labelsLst = labelsLst;
        }


    }


}
