namespace MobilePhone
{
    using System;

    internal class Display
    {
        private const double MaxScreenSize = 10;
        private const double MinScreenSize = 1;
        private const int MinNumberOfColors = 2;

        private double size;
        private int numberOfColors;

        // Constructors
        internal Display()
        {
        }

        internal Display(double size, int numberOfColors)
            : this()
        {
            this.Size = size;
            this.NumberOfColors = numberOfColors;
        }

        // Properties
        internal double Size
        {
            get
            {
                return this.size;
            }

            set
            {
                if (value > MaxScreenSize || value < MinScreenSize)
                {
                    throw new ArgumentException("Input for display size is out of range. Size should be 1 - 10 inches.");
                }

                this.size = value;
            }
        }

        internal int NumberOfColors
        {
            get
            {
                return this.numberOfColors;
            }

            set
            {
                if (value < MinNumberOfColors)
                {
                    throw new ArgumentException("Input for diplay number of colors is out of range. Number of colors should be at least 2.");
                }

                this.numberOfColors = value;
            }
        }
    }
}