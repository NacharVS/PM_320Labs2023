namespace CharacterEditorCore
{
    public class Characterictic
    {
        private int _value;
        private int _minValue;
        private int _maxValue;

        public Characterictic(int minValue, int maxValue)
        {
            MaxValue = maxValue;
            MinValue = minValue;
            Value = MinValue;
        }

        public int MaxValue
        {
            get { return _maxValue; }
            private set
            {
                if (value >= _minValue)
                {
                    _maxValue = value;
                }
            }
        }

        public int MinValue
        {
            get { return _minValue; }
            private set
            {
                if (value <= _maxValue)
                {
                    _minValue = value;
                }
            }
        }
        public int Value
        {
            get { return _value; }
            set 
            {
                if (value >= _minValue && value <= _maxValue)
                {
                    _value = value;
                }
                else if (value < _minValue)
                {
                    _value = _minValue;
                }
                else
                {
                    _value = _maxValue;
                }
            }
        }
    }
}