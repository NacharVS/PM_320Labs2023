using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore.DataBase
{
    public interface ICharacterRep
    {
        public BaseCharacteristics GetCharacter(string Id);
        public List<CharacterIdName> GetAllChars();
        public bool UpdateCharacterInDb(string characterId, BaseCharacteristics character);
        public bool UpdateInventory(string characterId, BaseCharacteristics character);
        public bool AddCharacterToDb(BaseCharacteristics character);
    }
}
