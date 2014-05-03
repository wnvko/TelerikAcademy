namespace MyLinkedList
{
    public class ListItem<T>
    {
        private T value;
        private ListItem<T> nextItem;

        public ListItem(T value, ListItem<T> parentItem)
        {
            this.Value = value;
            parentItem.NextItem = this;
        }

        public ListItem(T value)
        {
            this.Value = value;
            this.NextItem = null;
        }

        public T Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }

        public ListItem<T> NextItem
        {
            get
            {
                return this.nextItem;
            }

            set
            {
                this.nextItem = value;
            }
        }
    }
}
