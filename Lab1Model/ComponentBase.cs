using System;


namespace Lab1Model
{
    public abstract class ComponentBase : IComponent
    {
        private double _value;

        public double Value
        {
            get
            {
                return _value;
            }

            set
            {
                if (value >= 0)
                {
                    _value = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Value must not be less than zero");
                }
            }
        }

        public double GetImpedance(double freq)
        {
            if (freq < 0)
            {
                throw new ArgumentOutOfRangeException("Frequency must not be less than zero");
            }

            return CalcImpedance(freq);
        }

        protected abstract double CalcImpedance(double freq);
    }
}
