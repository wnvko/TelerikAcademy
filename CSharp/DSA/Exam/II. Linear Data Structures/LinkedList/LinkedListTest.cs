namespace MyLinkedList
{
    using System.Collections.Generic;

    public class LinkedListTest
    {
        public static void Main()
        {
            MyLinkedList<string> myList = new MyLinkedList<string>();
            myList.AddLast("Milko");
            myList.AddLast("Ilio");
            myList.AddFirst("Koko");
            myList.RemoveFirst();
            myList.RemoveLast();
            myList.RemoveFirst();

            // Next row will throw an exception if uncomment
            //myList.RemoveLast();
        }
    }
}
