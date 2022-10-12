using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore
{ 
    public class Level
    {
        private int _exp;
        private int _level;
        private int _levelUpEdge = 1000;
        private int _growEdge = 1000;
        public bool isNew = true;
        public delegate void OnLevelUpDelegate();

        public int CurrentLevel 
        {
            get => _level;
            set => _level = value;
        }
        public int CurrentExp
        {
            get => _exp;
            set
            {
                _exp = value;
                while (value >= _levelUpEdge)
                {
                    CurrentLevel += 1;
                    _levelUpEdge += _growEdge * _level;
                    OnLevelUpEvent?.Invoke();
                }
            }
        }

        public Level()
        {
            _level = 1;
            _exp = 0;
        }
        public Level(int exp)
        {
            CurrentExp = exp;
        }
        public void AddExp(int value)
        {
            CurrentExp = CurrentExp + value;
        }
        public event OnLevelUpDelegate OnLevelUpEvent;
    }
}
