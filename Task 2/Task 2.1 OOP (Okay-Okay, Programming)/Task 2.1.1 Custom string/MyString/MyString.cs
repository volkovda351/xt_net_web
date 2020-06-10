using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace MyStringLib
{
    public sealed class MyString
    {
        private const int DEFAULT_CAPACITY = 16;
        private const char NULL_SYMBOL = '\0';

        private char[] _symbols;
        private int _capacity;
        private int _length;

        public MyString(int capacity = DEFAULT_CAPACITY)
        {
            Capacity = capacity;
            Symbols = new char[Capacity];
            Length = 0;
        }
        public MyString(string str, int capacity = DEFAULT_CAPACITY)
        {
            Capacity = capacity;

            if (Capacity < str.Length)
                Capacity = _newCapacity(str.Length);

            Symbols = new char[Capacity];

            for (int i = 0; i < str.Length; i++)
                Symbols[i] = str[i];

            Length = str.Length;
        }
        public MyString(char[] charArray, int capacity = DEFAULT_CAPACITY)
        {
            Capacity = capacity;

            if (Capacity < charArray.Length)
                Capacity = _newCapacity(charArray.Length);

            Symbols = new char[Capacity];

            for (int i = 0; i < charArray.Length; i++)
                Symbols[i] = charArray[i];

            Length = charArray.Length;
        }

        public int Length
        {
            get
            {
                return _length;
            }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Value of length is invalid");
                else
                    _length = value;
            }
        }
        public int Capacity
        {
            get
            {
                return _capacity;
            }
            set
            {
                if (value < _length || value == 0)
                    throw new ArgumentException("Value of capacity of invalid");
                else
                    _capacity = value;
            }
        }
        private char[] Symbols
        {
            get
            {
                return _symbols;
            }
            set
            {
                _symbols = value;
            }
        }

        public char this[int index]
        {
            get
            {
                if (index >= 0 && index < Length || index < 0 && index >= -Length)
                    return Symbols[(Length + index) % Length];
                else
                    throw new IndexOutOfRangeException("Index is invalid");
            }
            set
            {
                if (index >= 0 && index < Length || index < 0 && index >= -Length)
                    Symbols[(Length + index) % Length] = value;
                else
                    throw new IndexOutOfRangeException("Index is invalid");
            }
        }

        public static bool operator ==(MyString myStr1, MyString myStr2)
        {
            if (myStr1.Length == myStr2.Length)
            {
                for (int i = 0; i < myStr1.Length; i++)
                    if (myStr1[i] != myStr2[i])
                        return false;

                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(MyString myStr1, MyString myStr2)
        {
            return !(myStr1 == myStr2);
        }
        public static bool operator <(MyString myStr1, MyString myStr2)
        {
            for (int i = 0; i < Min(myStr1.Length, myStr2.Length); i++)
            {
                if (myStr1[i] < myStr2[i])
                {
                    return true;
                }
                else
                {
                    if (myStr1[i] > myStr2[i])
                        return false;
                }
            }

            if (myStr1.Length < myStr2.Length)
                return true;
            else
                return false;
        }
        public static bool operator <=(MyString myStr1, MyString myStr2)
        {
            return !(myStr1 > myStr2);
        }
        public static bool operator >(MyString myStr1, MyString myStr2)
        {
            for (int i = 0; i < Min(myStr1.Length, myStr2.Length); i++)
            {
                if (myStr1[i] > myStr2[i])
                {
                    return true;
                }
                else
                {
                    if (myStr1[i] < myStr2[i])
                        return false;
                }
            }

            if (myStr1.Length > myStr2.Length)
                return true;
            else
                return false;
        }
        public static bool operator >=(MyString myStr1, MyString myStr2)
        {
            return !(myStr1 < myStr2);
        }
        public static MyString operator +(MyString myStr1, MyString myStr2)
        {
            MyString result = myStr1.Clone();
            result.Append(myStr2.ToString());
            return result;
        }
        public static MyString operator *(MyString myStr, int n)
        {
            MyString result = myStr.Clone();
            result.Repeat(n);
            return result;
        }
        public static implicit operator MyString(string str)
        {
            return new MyString(str);
        }
        public static implicit operator MyString(char[] charArr)
        {
            return new MyString(charArr);
        }
        public static explicit operator String(MyString myStr)
        {
            return myStr.ToString();
        }

        public void Append(char c)
        {
            Append(c.ToString());
        }
        public void Append(string str)
        {
            int newLength = Length + str.Length;
            bool isExtended = false;

            if (Capacity < newLength)
            {
                Capacity = _newCapacity(newLength);
                isExtended = true;
            }

            if (isExtended)
            {
                char[] temp = new char[Capacity];

                for (int i = 0; i < Length; i++)
                    temp[i] = Symbols[i];

                Symbols = temp;
            }

            for (int i = Length; i < Length + str.Length; i++)
                Symbols[i] = str[i - Length];

            Length += str.Length;
        }
        public MyString Clone()
        {
            MyString result = new MyString();
            result.Symbols = Symbols;
            result.Capacity = Capacity;
            result.Length = Length;
            return result;
        }
        public void Insert(char c, int pos)
        {
            Insert(c.ToString(), pos);
        }
        public void Insert(string str, int pos)
        {
            int newLength = Length + str.Length;

            if (Capacity < newLength)
                Capacity = _newCapacity(newLength);

            char[] temp = new char[Capacity];

            for (int i = 0; i < pos; i++)
                temp[i] = Symbols[i];

            for (int i = pos; i < pos + str.Length; i++)
                temp[i] = str[i - pos];

            for (int i = pos + str.Length; i < Length + str.Length; i++)
                temp[i] = Symbols[i - str.Length];

            Symbols = temp;
            Length += str.Length;
        }
        public void Remove(int startPos, int count)
        {
            int newLength = Length - count;

            if (Capacity < newLength)
                Capacity = _newCapacity(newLength);

            char[] temp = new char[Capacity];

            for (int i = 0; i < startPos; i++)
                temp[i] = Symbols[i];

            for (int i = startPos + count; i < Length - count; i++)
                temp[i] = Symbols[i + count];

            Symbols = temp;
            Length -= count;
        }
        public void Remove(char c)
        {
            Remove(c.ToString());
        }
        public void Remove(string pattern)
        {
            string str = $"{pattern}{NULL_SYMBOL}{this.ToString()}";

            int[] z = _zFunction(str);

            int cntRemoves = 0;

            for (int i = pattern.Length + 1; i < Length + pattern.Length + 1; i++)
            {
                if (z[i] == pattern.Length)
                {
                    for (int j = i; j < pattern.Length + i; j++)
                    {
                        Symbols[j - pattern.Length - 1] = NULL_SYMBOL;
                        cntRemoves++;
                    }
                }
            }

            int newLength = Length - cntRemoves;
            char[] temp = new char[_newCapacity(newLength)];

            for (int i = 0, j = 0; i < Length; i++)
            {
                if (Symbols[i] != NULL_SYMBOL)
                {
                    temp[j] = Symbols[i];
                    j++;
                }
            }

            Symbols = temp;
            Length -= cntRemoves;
        }
        public int Find(char c)
        {
            return Find(c.ToString());
        }
        public int Find(string pattern)
        {
            string str = $"{pattern}{NULL_SYMBOL}{this.ToString()}";

            int[] z = _zFunction(str);

            for (int i = pattern.Length + 1; i < Length + pattern.Length + 1; i++)
                if (z[i] == pattern.Length)
                    return i - pattern.Length - 1;

            return -1;
        }
        public void Repeat(int n)
        {
            int newLength = Length * n;

            char[] temp = new char[_newCapacity(newLength)];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < Length; j++)
                    temp[i * Length + j] = Symbols[j];

            Symbols = temp;
            Length *= n;
        }
        public void Reverse()
        {
            char[] temp = new char[Capacity];

            for (int i = 0; i < _length; i++)
                temp[Length - i - 1] = Symbols[i];

            Symbols = temp;
        }
        public void RandomShuffle()
        {
            Random rnd = new Random();

            for (int i = 0; i < Length - 1; i++)
            {
                int randomNumber = rnd.Next(i, Length);
                char temp = Symbols[randomNumber];
                Symbols[randomNumber] = Symbols[i];
                Symbols[i] = temp;
            }
        }
        public char[] ToCharArr()
        {
            char[] result = new char[Length];

            for (int i = 0; i < Length; i++)
                result[i] = Symbols[i];

            return result;
        }
        public override string ToString()
        {
            return new string(ToCharArr());
        }

        private static int _newCapacity(int newLength)
        {
            return (int)Pow(2, (int)Log(newLength, 2) + 1);
        }
        private static int[] _zFunction(string str)
        {
            int[] z = new int[str.Length];
            z[0] = 0;

            int l = 0;
            int r = 0;

            for (int i = 1; i < z.Length; i++)
            {
                z[i] = Max(0, Min(z[i - l], r - i));

                while (i + z[i] < z.Length && str[z[i]] == str[i + z[i]])
                    z[i]++;

                if (i + z[i] > r)
                {
                    l = i;
                    r = i + z[i];
                }
            }

            return z;
        }
    }
}
