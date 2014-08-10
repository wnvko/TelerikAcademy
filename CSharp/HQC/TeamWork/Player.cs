namespace HangMan
{
    using System;
    using System.Collections.Generic;

    using HangMan.Interfaces;
    class Player : IPlayer, IComparable<IPlayer>
    {
        private string name;

        private int mistakes;

        public Player(string name, int mistakes)
        {
            this.name = name;
            this.mistakes = mistakes;
        }

        public Player()
            : this(string.Empty, 999)
        {
        }

        public int Mistakes
        {
            get
            {
                return mistakes;
            }
            set
            {
                mistakes = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int CompareTo(IPlayer other)
        {
            return this.Mistakes.CompareTo(other.Mistakes);
        }
    }
}