using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCharacterEditor
{
    class Characters
    {
        public List<Character> characters;

        public Characters()
        {
            characters = new List<Character>();
        }
        public void Add(Character character)
        {
            characters.Add(character);
        }

        public void ClearList()
        {
            characters.Clear();
        }
    }
}
