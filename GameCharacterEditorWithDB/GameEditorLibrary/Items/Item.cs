using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEditorLibrary
{
    public class Item
    {
        public Item(string name) 
        {
            ItemName = name;
        }

        public string ItemName { get; set; }
    }
}
