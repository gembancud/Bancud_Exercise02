using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02_A
{
    public class LinkedList<T>
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

        #region Remove
        private void Remove(Node<T> prev, Node<T> next)
        {
            prev.Next = next;
            next.Prev = prev;
        }
        public Node<T> RemoveAt(int i)
        {
            if (i >= Size) throw new System.ArgumentOutOfRangeException();
            var temp = Head;
            for (int j = 0; j < i; j++)
            {
                temp = temp.Next;
            }

            Remove(temp.Prev, temp.Next);
            Size--;
            return temp;
        }
        #endregion

        
    }
}
