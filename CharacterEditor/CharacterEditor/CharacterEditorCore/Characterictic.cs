namespace CharacterEditorCore
{
    public class Characterictic
    {
        private int _value;
        private int _minValue;
        private int _maxValue;

        public Characterictic(int value, int minValue, int maxValue)
        {
            MaxValue = maxValue;
            MinValue = minValue;
            Value = value;
        }

        public int MaxValue
        {
            get { return _maxValue; }
            set
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
            set
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
            }
        }
    }
}