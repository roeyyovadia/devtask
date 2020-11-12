using devtask.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace devtask.Objects
{
    class StatusLink
    {
        // TODO : Change to guid of the first status
        public string root { get; set; }        
        public List<string> nextLST { get; set; }
        // TODO : Change to guid
        public string name { get; set; }
        // TODO : Change to guid
        public List<string> prevLST { get; set; }
        //TODO: Could add Status for easier search

        public StatusLink(string name)
        {
            root = "";
            nextLST = new List<string>();
            this.name = name;
            prevLST = new List<string>();
        }

        public StatusLink(string name,string root)
        {
            this.root = root;
            this.name = name;
            nextLST = new List<string>();
            prevLST = new List<string>();
        }

    }
}
