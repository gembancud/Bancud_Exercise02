using System;
using System.Security.Cryptography.X509Certificates;

namespace Exercose02_B
{
    public class View
    {
        public void Test1()
        {
            Polynomial polynomial1 = new Polynomial();
            string input1 = "5x^2+2x^1+11x^4";
            polynomial1.ReadPolynomial(input1);
            Console.WriteLine(polynomial1);


            Polynomial polynomial2 = new Polynomial();
            string input2 = "3x^4+x^5+2x^6";
            polynomial2.ReadPolynomial(input2);
            Console.WriteLine(polynomial2);


            Console.WriteLine(polynomial1);
            Console.WriteLine(polynomial2);

            Polynomial Resultant = polynomial1.AddPolynomial(polynomial2);
            Console.WriteLine(Resultant);
        }

        public void Test2()
        {
            Polynomial polynomial1 = new Polynomial();
            string input1 = "5x^2+2x^1+11x^4+2x^4";
            polynomial1.ReadPolynomial(input1);
            polynomial1.OrderDecreasing();
            polynomial1.CombineTerms();
            Console.WriteLine(polynomial1);

        }

    }
}