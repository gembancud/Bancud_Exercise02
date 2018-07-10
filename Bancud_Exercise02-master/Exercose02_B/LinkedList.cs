using System.Collections;
using System.Collections.Generic;

namespace Exercose02_B
{
    public class LinkedList<T>:IEnumerable<T>
    {
        public Node<T> _header { get; set; }
        public Node<T> _trailer { get; set; }
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }
        public int Size { get; private set; }

        public LinkedList()
        {
            _header = new Node<T>(default(T), null, null);
            _trailer = new Node<T>(default(T), _header, null);
            _header.Next = _trailer;
            Size = 0;
        }

        #region AddFunctions
        public void AddToTail(T data)
        {
            AddBetween(data, _trailer.Prev, _trailer);
        }
        public void AddToHead(T data)
        {
            AddBetween(data, _header, _header.Next);
        }
        private void AddBetween(T data, Node<T> prev, Node<T> next)
        {
            var newNode = new Node<T>(data, prev, next);
            prev.Next = newNode;
            next.Prev = newNode;

            Head = _header.Next;
            Tail = _trailer.Prev;
            Size++;
        }
        #endregion

        public void Remove(Node<T> prevNode, Node<T> nextNode)
        {
            prevNode.Next = nextNode;
            nextNode.Prev = prevNode;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var temp = Head;
            while (temp.Data != null)
            {
                yield return temp.Data;
                temp = temp.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
