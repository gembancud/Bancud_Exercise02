using System;
using System.Collections;

namespace Exercose02_B
{
    public class Polynomial:IEnumerable
    {
        private LinkedList<Term> polyLinkedList;

        public LinkedList<Term> PolyLinkedList
        {
            get { return polyLinkedList; }
            set { polyLinkedList = value; }
        }

        public Polynomial()
        {
            polyLinkedList= new LinkedList<Term>();
        }

        public void ReadPolynomial(string input)
        {
            foreach (string term in GetTerms(input))
            {
                foreach (Term SegregatableString in DissectTerm(term))
                {
                    PolyLinkedList.AddToTail(SegregatableString);
                }
            }

        }

        private IEnumerable DissectTerm(string Term)
        {
            var newTerm= new Term();
            string tempString = null;
            int flag = 0;
            foreach (var x in Term)
            {
                if (char.IsNumber(x) || x == '-')
                {
                    tempString += x;

                }
                else flag++;

                if (flag == 1)
                {
                    newTerm.Coef = Convert.ToInt32(tempString);
                    tempString = null;
                    flag++;
                }

            }
            newTerm.Exponent = Convert.ToInt32(tempString);
            yield return newTerm;
        }

        private IEnumerable GetTerms(string input)
        {
            string temp = null;
            foreach (var x in input)
            {
                if (x != '+') temp += x;
                else
                {
                    yield return temp;
                    temp = null;
                }
            }

            yield return temp;
        }

        public IEnumerator GetEnumerator()
        {
            var temp = PolyLinkedList.Head;
            while (temp.Data != null)
            {
                yield return temp;
                temp = temp.Next;
            }
        }

        public override string ToString()
        {
            string Polynomial = null;
            foreach (Term term in PolyLinkedList)
            {
                Polynomial += term+ "+";
            }

            return Polynomial;
        }
    }
}