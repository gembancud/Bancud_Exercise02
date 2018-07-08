using System;

namespace Exercose02_B
{
    public class View
    {
        public View()
        {
            Polynomial polynomial= new Polynomial();
            string input = "5x^2+2a^3";
            polynomial.ReadPolynomial(input);
            Console.WriteLine(polynomial);
        }

    }
}