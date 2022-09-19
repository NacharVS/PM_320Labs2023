using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWithInterface
{
    public interface IRepairible
    {
        public int Condition { get; set; }
        public void Repair();
    }
}
