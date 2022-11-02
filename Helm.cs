using WPFcharacterictic.Core.BaseEntitys;
using WPFcharacterictic.Core;

namespace Armor
{
    public class Helm
    {
        private string _name;
        public string Name 
        { 
            get { return _name; }
            set { _name = value; }
        }

        private Entity _whoCan;
        public Entity WhoCan 
        { 
            get { return _whoCan; }
            set { }
        }



    }
}