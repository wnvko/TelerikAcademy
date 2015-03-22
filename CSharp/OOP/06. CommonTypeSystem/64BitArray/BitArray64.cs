namespace _64BitArray
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class BitArray64 : IEnumerator<int>, IEnumerable<int>
    {
        public const int BitArrayCapacity = 64;
        private ulong bitArray;
        private int position = -1;

        #region Constructors
        public BitArray64(ulong bitArray = 0)
        {
            this.BitArray = bitArray;
        }
        #endregion

        #region Properties
        public ulong BitArray
        {
            get
            {
                return this.bitArray;
            }

            set
            {
                this.bitArray = value;
            }
        }
        #endregion

        #region Indexer
        public int this[int index]
        {
            get
            {
                if (index < 0 || index > 63)
                {
                    throw new IndexOutOfRangeException("Index must be in range 0-63.");
                }

                return this.GetBitOnCurrentPosition(index);
            }

            set
            {
                if (index < 0 || index > 63)
                {
                    throw new IndexOutOfRangeException("Index must be in range 0-63.");
                }

                if (value != 0 && value != 1)
                {
                    throw new ArgumentException("Bit value must be 0 or 1");
                }

                this.SetBitOnCurrentPosition(index, value);
            }
        }
        #endregion

        #region IEnumerator methods
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < BitArrayCapacity; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int Current
        {
            get { return this.GetBitOnCurrentPosition(this.position); }
        }

        public void Dispose()
        {
            this.Reset();
        }
        #endregion

        #region IEnumerable methods and properties
        object IEnumerator.Current
        {
            get
            {
                return this.GetBitOnCurrentPosition(this.position);
            }
        }

        public bool MoveNext()
        {
            this.position++;
            return this.position < BitArrayCapacity;
        }

        public void Reset()
        {
            this.position = -1;
        }
        #endregion

        #region Overrided methods
        public override string ToString()
        {
            StringBuilder stringValue = new StringBuilder();
            for (int i = 63; i >= 0; i--)
            {
                stringValue.Append(this[i]);
            }

            stringValue.Append(Environment.NewLine);
            return stringValue.ToString();
        }

        public override bool Equals(object obj)
        {
            BitArray64 valueToCheck = obj as BitArray64;
            if ((object)valueToCheck == null)
            {
                return false;
            }

            return this.BitArray == valueToCheck.BitArray;
        }

        public override int GetHashCode()
        {
            return this.BitArray.GetHashCode();
        }

        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !first.Equals(second);
        }
        #endregion

        #region Private methods
        private int GetBitOnCurrentPosition(int position)
        {
            ulong mask = ((ulong)1) << position;
            ulong bitOnCurrentPosition = (this.BitArray & mask) >> position;
            return (int)bitOnCurrentPosition;
        }

        private void SetBitOnCurrentPosition(int position, int bitValue)
        {
            ulong mask = ((ulong)1) << position;
            if (bitValue == 1)
            {
                this.BitArray = this.BitArray | mask;
            }
            else
            {
                mask = ~mask;
                this.BitArray = this.BitArray & mask;
            }
        }
        #endregion
    }
}
