using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEditorLibrary
{
    public class Skill
    {
        public Skill(string name) 
        {
            SkillName = name;
        }

        public string SkillName { get; set; }
    }
}
