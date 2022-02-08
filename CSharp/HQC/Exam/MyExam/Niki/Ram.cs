namespace Computers
{
    using Contracts;

    public class Ram : IRam
    {
        private int value;
        private int amount;

        public Ram(int amount)
        {
            this.amount = amount;
        }

        public int Amount
        {
            get
            {
                return this.amount;
            }

            set
            {
                this.amount = value;
            }
        }

        public void SaveValue(int newValue)
        {
            this.value = newValue;
        }

        public int LoadValue()
        {
            return this.value;
        }
    }
}