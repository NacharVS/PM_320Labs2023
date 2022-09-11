namespace CharacterEditorCore
{
    class Characteristics
    {
        private int _value;
        private int _minValue;
        private int _maxValue;

        public Characteristics(int value, int minValue, int maxValue)
        {
            _value = value;
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public int Value
        {
            get { return _value; }
            set
            {
                if(value >= _minValue && value <= _maxValue)
                {
                    _value = value;
                }
            }
        }

        public int MinValue
        {
            get { return _minValue; }
            set
            {
                if(value >= _minValue)
                {
                    _minValue = value;
                }
            }
        }

        public int MaxValue
        {
            get { return _maxValue; }
            set
            {
                if(value <= _maxValue)
                {
                    _maxValue = value;
                }
            }
        }
    }
}
