using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFcharacterictic.Core.interfaces;

namespace WPFcharacterictic.Core
{
    public class InventoryItem : IHaveName
    {
        private string _name;
        public string Name 
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
