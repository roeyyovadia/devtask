using devtask.Enum;
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
        public statusMode mode{ get; set; }


        public Status(string name)
        {
            id = new Guid();
            this.name = name;
            mode = statusMode.none;
        }

        public Status(string name , statusMode mode)
        {
            id = new Guid();
            this.name = name;
            this.mode = mode;
        }

    }
    
}
