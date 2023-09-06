using System.Collections;
using System.Collections.Generic;

namespace MyLinkedList
{
    /* 
       Author  : MINmin
       Date    : 2023. 09. 06
       Name    : LinkedList 구현해보기 1
    */ 
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            LinkedListNode<int> node1 = list.AddLast(1);
            LinkedListNode<int> node2 = list.AddLast(2);
            LinkedListNode<int> node3 = list.AddLast(3);

            list.Remove(node1);


            MyList<int> myList = new MyList<int>();
            MylistNode<int> myNode1 = myList.AddLast(1);
            MylistNode<int> myNode2 = myList.AddLast(2);
            MylistNode<int> myNode3 = myList.AddLast(3);
            MylistNode<int> newNode = new MylistNode<int> { Data = 7 };

            myList.AddLast(newNode);
            myList.Remove(2);
            myList.Remove(myNode2);
        }
    }
}