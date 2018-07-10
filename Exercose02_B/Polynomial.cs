using System;
using System.Collections;
using System.Runtime.Remoting.Messaging;

namespace Exercose02_B
{
    public class Polynomial : IEnumerable
    {
        private LinkedList<Term> polyLinkedList;

        public LinkedList<Term> PolyLinkedList
        {
            get { return polyLinkedList; }
            set { polyLinkedList = value; }
        }

        public Polynomial()
        {
            polyLinkedList = new LinkedList<Term>();
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
            this.CombineTerms();
            this.OrderDecreasing();

        }

        private IEnumerable DissectTerm(string Term)
        {
            if (Term == null) yield break;
            var newTerm = new Term();
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
                    if (tempString == null) tempString = "1";
                    newTerm.Coef = Convert.ToInt32(tempString);
                    tempString = null;
                    flag++;
                }

            }

            if (tempString == null) tempString = "1";
            if(flag==0) newTerm.Coef = Convert.ToInt32(tempString);
            else
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
                Polynomial += term + "+";
            }

            Polynomial = Polynomial.Remove(Polynomial.Length - 1);
            return Polynomial;
        }

        public Polynomial AddPolynomial(Polynomial polynomial)
        {
            this.OrderDecreasing();
            polynomial.OrderDecreasing();

            var ThisTerm = polyLinkedList.Head;
            var ThatTerm = polynomial.PolyLinkedList.Head;
            Polynomial ResultantPolynomial = new Polynomial();
            while (ThisTerm.Data != null || ThatTerm.Data != null)
            {
                if (ThisTerm.Data == null)
                {
                    ResultantPolynomial.PolyLinkedList.AddToHead(ThatTerm.Data);
                    ThatTerm = ThatTerm.Next;
                    continue;
                }

                if (ThatTerm.Data == null)
                {
                    ResultantPolynomial.PolyLinkedList.AddToHead(ThisTerm.Data);
                    ThisTerm = ThisTerm.Next;
                    continue;
                }

                if (ThisTerm.Data.Exponent == ThatTerm.Data.Exponent)
                {
                    int SumCoef = ThisTerm.Data.Coef + ThatTerm.Data.Coef;
                    ResultantPolynomial.PolyLinkedList.AddToHead(new Term(SumCoef,ThisTerm.Data.Exponent));
                    ThisTerm = ThisTerm.Next;
                    ThatTerm = ThatTerm.Next;
                    continue;
                }

                if (ThisTerm.Data.Exponent > ThatTerm.Data.Exponent)
                {
                    ResultantPolynomial.PolyLinkedList.AddToHead(ThisTerm.Data);
                    ThisTerm = ThisTerm.Next;
                    continue;
                }
                if (ThisTerm.Data.Exponent < ThatTerm.Data.Exponent)
                {
                    ResultantPolynomial.PolyLinkedList.AddToHead(ThatTerm.Data);
                    ThatTerm = ThatTerm.Next;
                    continue;
                }
            }
            ResultantPolynomial.OrderDecreasing();
            return ResultantPolynomial;
        }

        public Polynomial MultiPolynomial(Polynomial polynomial)
        {
            var ThisPolynomial = this.PolyLinkedList.Head;
            var ThatPolynomial = polynomial.PolyLinkedList.Head;
            Polynomial ProductPolynomial= new Polynomial();;

            while (ThisPolynomial.Data != null)
            {
                while (ThatPolynomial.Data != null)
                {
                    Term ProductTerm = Multiply(ThisPolynomial.Data, ThatPolynomial.Data);
                    ProductPolynomial.PolyLinkedList.AddToTail(ProductTerm);
                    ThatPolynomial = ThatPolynomial.Next;
                }

                ThisPolynomial = ThisPolynomial.Next;
                ThatPolynomial = polynomial.PolyLinkedList.Head;
            }
            ProductPolynomial.OrderDecreasing();
            ProductPolynomial.CombineTerms();

            return ProductPolynomial;
        }

        public Term Multiply(Term thisTerm, Term thatTerm)
        {
            int Coef = thisTerm.Coef * thatTerm.Coef;
            int Exponent = thisTerm.Exponent + thatTerm.Exponent;
            Term ProductTerm = new Term(Coef, Exponent);
            return ProductTerm;
        }

        public void OrderDecreasing()
        {
            var temp = PolyLinkedList.Head;
            bool flag = false;
            while (!flag)
            {
                flag = true;
                while (temp.Next.Data != null)
                {
                    if (temp.Data.Exponent < temp.Next.Data.Exponent)
                        flag = Swap(temp);
                    temp = temp.Next;
                }
                temp = PolyLinkedList.Head;
            }
        }

        public void CombineTerms()
        {
            var temp = PolyLinkedList.Head;
            while (temp.Data != null)
            {
                if (temp.Next.Data == null) break;
                if (temp.Data.Exponent == temp.Next.Data.Exponent)
                {
                    int SumCoef = temp.Data.Coef + temp.Next.Data.Coef;
                    Term newTerm = new Term(SumCoef,temp.Data.Exponent);
                    temp.Data = newTerm;
                    PolyLinkedList.Remove(temp,temp.Next.Next);
                }
                temp = temp.Next;
            }
            this.OrderDecreasing();
        }

        public bool Swap<T>(Node<T> node)
        {
            T Data = node.Data;
            node.Data = node.Next.Data;
            node.Next.Data = Data;
            return false;
        }
    }
}