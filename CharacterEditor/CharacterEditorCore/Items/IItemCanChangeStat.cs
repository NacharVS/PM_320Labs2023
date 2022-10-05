using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore.Items
{
    public interface IItemCanChangeStat
    {
        public int HPChange { get; set; }
        public int ManaChange { get; set; }
        public int PdefChange { get; set; }
        public int AttackChange { get; set; }
        public int MagicalAttackChange { get; set; }
    }
}
