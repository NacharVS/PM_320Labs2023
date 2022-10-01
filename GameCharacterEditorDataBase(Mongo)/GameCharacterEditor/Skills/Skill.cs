using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace GameCharacterEditor
{
    class Skill
    {
        public string SkillName { get; set; }

        public Skill(string skillName)
        {
            SkillName = skillName;
        }
    }
}
