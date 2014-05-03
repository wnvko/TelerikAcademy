namespace MyLinkedList
{
    using System;
    class MyLinkedList<T>
    {
        private ListItem<T> myListHead;
        private ListItem<T> myListTail;
        private int myListCount;

        public MyLinkedList()
        {
            this.myListHead = null;
            this.myListTail = null;
            this.myListCount = 0;
        }

        public void AddLast(T item)
        {
            if (this.myListHead == null)
            {
                this.myListHead = new ListItem<T>(item);
                myListTail = myListHead;
            }
            else
            {
                ListItem<T> newItem = new ListItem<T>(item, this.myListTail);
                this.myListTail = newItem;
            }

            myListCount++;
        }

        public void AddFirst(T item)
        {
            if (this.myListHead == null)
            {
                this.myListHead = new ListItem<T>(item);
                myListTail = myListHead;
            }
            else
            {
                ListItem<T> newItem = new ListItem<T>(item);
                newItem.NextItem = this.myListHead;
                this.myListHead = newItem;
            }

            myListCount++;
        }

        public void RemoveLast()
        {
            if (this.myListHead != null)
            {
                if (this.myListHead != this.myListTail)
                {
                    ListItem<T> buffer = this.myListHead;
                    while (true)
                    {
                        if (buffer.NextItem == this.myListTail)
                        {
                            this.myListTail = buffer;
                            this.myListTail.NextItem = null;
                            myListCount--;
                            break;
                        }
                        else
                        {
                            buffer = buffer.NextItem;
                        }
                    }
                }
                else
                {
                    this.myListHead = null;
                    this.myListTail = null;
                    this.myListCount = 0;
                }
            }
            else
            {
                throw new ArgumentException("Cannot remove item from an empty list");
            }
        }

        public void RemoveFirst()
        {
            if (this.myListHead != null)
            {
                if (this.myListHead != this.myListTail)
                {
                    this.myListHead = this.myListHead.NextItem;
                    myListCount--;
                }
                else
                {
                    this.myListHead = null;
                    this.myListTail = null;
                    this.myListCount = 0;
                }
            }
            else
            {
                throw new ArgumentException("Cannot remove item from an empty list");
            }
        }
    }
}
