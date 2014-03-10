using System;
using System.Collections;
using System.Collections.Generic;

namespace BitArray64Example
{
    class BitArray64 : IEnumerable<int>
    {
        private ulong array;

        public int Length { get { return 64; } }

        // Enumerator
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<int> GetEnumerator()
        {
            int index = 0;
            while (index < 64)
            {
                int bit;

                if ((this.array & ((ulong)1 << index)) != 0)
                {
                    bit = 1;
                }
                else
                {
                    bit = 0;
                }

                yield return bit;
                index++;
            }
        }

        // methods
        public override int GetHashCode()
        {
            return base.GetHashCode() ^ (int)this.array;
        }

        public override bool Equals(object obj)
        {
            if (obj is BitArray64)
            {
                ulong convertedArray = ConvertArrayToUlong((BitArray64)(obj));
                if (this.array == convertedArray)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !first.Equals(second);
        }

        // indexer
        public int this[int index]
        {
            get
            {
                if (index >= 64 || index < 0)
                {
                    throw new IndexOutOfRangeException("Index out of range 0...63");
                }

                if ((this.array & ((ulong)1 << index)) != 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (index >= 64 || index < 0)
                {
                    throw new IndexOutOfRangeException("Index out of range 0...63");
                }

                if (value != 0 && value != 1)
                {
                    throw new IndexOutOfRangeException("Value can be only 0 and 1");
                }

                ulong mask = (ulong)1 << index;
                if (value == 0)
                {
                    this.array &= (~mask);
                }
                else
                {
                    this.array |= mask;
                }
            }
        }

        private ulong ConvertArrayToUlong(BitArray64 array)
        {
            ulong result = 0;
           for (int index = 0; index < array.Length; index++)
			{
			    if (array[index] == 1)
                {
                    result |= ((ulong)1 << index);
                }
			}
            return result;
        }
    }
}
