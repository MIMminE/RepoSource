using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinkedList
{   
    #region "노드 구조"
    class MylistNode<T>
    {
        public T Data { get; set; }
        public MylistNode<T>? Next = null;
        public MylistNode<T>? Prev = null;
    }
    #endregion

    class MyList<T>
    {   
        #region "MyList 멤버 변수"

        private MylistNode<T>? _First = null;
        private MylistNode<T>? _Last = null;
        private int _Count = 0;

        #endregion
        
        #region "AddLast 메소드
        public MylistNode<T> AddLast(T item)
        {
            MylistNode<T> newNode = new MylistNode<T>();
            newNode.Data = item;

            if (_First == null)
            {
                _First = newNode;
                _Last = newNode;
            }
            else if (_Last != null)
            {
                newNode.Prev = _Last;
                _Last.Next = newNode;
                _Last = newNode;

            }
            _Count++;
            return newNode;
        }
        public void AddLast(MylistNode<T> node)
        {
            if(_First == null)
            {
                _First = node;
                _Last = node;
            }
            else if(_Last != null)
            {
                node.Prev = _Last;
                _Last.Next = node;
                _Last = node;
            }
            _Count++;
        }
        #endregion

        #region "Remove 메소드"
        public void Remove(MylistNode<T> node)
        {
            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;
            _Count--;
        }
        public bool Remove(T item)
        {
            MylistNode<T> thisNode = _First;
            while (thisNode != _Last) {
                if (thisNode.Data.Equals(item))
                {
                    thisNode.Prev.Next = thisNode.Next;
                    thisNode.Next.Prev = thisNode.Prev;
                    _Count--;
                    return true;
                }
                thisNode = _First.Next;
            }
            return false;
        }
        #endregion
    }
}