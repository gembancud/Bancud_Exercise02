namespace Exercose02_B
{
    public class Term
    {
        private int coef;

        public int Coef
        {
            get { return coef; }
            set { coef = value; }
        }

        private int exponent;

        public int Exponent
        {
            get { return exponent; }
            set { exponent = value; }
        }

        public override string ToString()
        {
            return coef + "x^" + exponent;
        }

        public Term(int _coef, int _exponent)
        {
            coef = _coef;
            exponent = _exponent;
        }

        public Term()
        {
            
        }
    }
}