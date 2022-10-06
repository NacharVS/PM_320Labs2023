using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEditorLibrary
{
    public interface IChangeStat
    {
        void ChangeStatistic(Unit unit, string material, bool boo);
    }
}
