using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace DynamicArray
{
    public class DynamicArray<T> : IEnumerable<T>, ICloneable
    {
        private T[] _mass;
        private int _length;
        private int _capacity;

        public DynamicArray()
        {
            Length = 0;
            Capacity = 8;
            Mass = new T[Capacity];
        }
        public DynamicArray(int capacity)
        {
            Length = 0;
            Capacity = capacity;
            Mass = new T[Capacity];
        }
        public DynamicArray(IEnumerable<T> collection)
        {
            Length = collection.Count();

            while (Capacity < Length)
                Capacity *= 2;

            Mass = new T[Length];

            int i = 0;
            foreach (var item in collection)
                Mass[i] = item;
        }

        public int Length
        {
            get
            {
                return _length;
            }
            private set
            {
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
                _capacity = value;
                Length = Min(Length, Capacity);

                T[] temp = new T[Capacity];

                for (int i = 0; i < Length; i++)
                    temp[i] = Mass[i];
            }
        }
        protected T[] Mass
        {
            get
            {
                return _mass;
            }
            set
            {
                _mass = value;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < Length || index < 0 && index >= -Length)
                    return Mass[(Length + index) % Length];
                else
                    throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < Length || index < 0 && index >= -Length)
                    Mass[(Length + index) % Length] = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Add(T item)
        {
            Length++;

            if (Capacity < Length)
            {
                Capacity *= 2;
                T[] temp = new T[Capacity];

                for (int i = 0; i < Length - 1; i++)
                    temp[i] = Mass[i];

                Mass = temp;
            }

            Mass[Length - 1] = item;
        }
        public void AddRange(IEnumerable<T> collection)
        {
            int CollectionLength = collection.Count();
            Length += CollectionLength;

            while (Capacity < Length)
                Capacity *= 2;

            if (Capacity > Mass.Length)
            {
                T[] temp = new T[Capacity];

                for (int i = 0; i < Length - 1; i++)
                    temp[i] = Mass[i];

                Mass = temp;
            }

            int j = 0;
            foreach (var item in collection)
            {
                Mass[Length - CollectionLength + j] = item;
                j++;
            }
        }
        public bool Insert(T item, int index)
        {
            if (index >= 0 && index < Length)
                Length++;
            else
                throw new ArgumentOutOfRangeException();

            if (Capacity < Length)
            {
                T[] temp = new T[Capacity];

                for (int i = 0; i < Length - 1; i++)
                    temp[i] = Mass[i];

                Mass = temp;
            }

            for (int i = Length - 1; i > index; i--)
                Mass[i] = Mass[i - 1];

            Mass[index] = item;

            return true;
        }
        public bool Remove(int index)
        {
            if (Length - 1 > 0 && index < Length)
                Length--;
            else
                return false;

            T[] temp = new T[Capacity];

            for (int i = 0; i < index; i++)
                temp[i] = Mass[i];

            for (int i = index + 1; i < Length + 1; i++)
                temp[i] = Mass[i];

            Mass = temp;

            return true;
        }
        public T[] ToArray()
        {
            T[] result = new T[Length];

            for (int i = 0; i < Length; i++)
                result[i] = Mass[i];

            return result;
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            return new DynamicArrayEnumerator<T>(Mass, Length);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public object Clone()
        {
            DynamicArray<T> result = new DynamicArray<T>(Capacity);
            result.AddRange(Mass);
            return result;
        }

        public class DynamicArrayEnumerator<T> : IEnumerator<T>
        {
            private int _index;
            private T[] _mass;
            private int _length;

            public DynamicArrayEnumerator(T[] mass, int length)
            {
                _index = -1;
                _mass = mass;
                _length = length;
            }

            protected int Index
            {
                get
                {
                    return _index;
                }
                set
                {
                    _index = value;
                }
            }
            protected T[] Mass
            {
                get
                {
                    return _mass;
                }
                set
                {
                    _mass = value;
                }
            }
            protected int Length
            {
                get
                {
                    return _length;
                }
            }
            public T Current => Mass[Index];
            object IEnumerator.Current => Current;

            public void Dispose() { }
            public virtual bool MoveNext()
            {
                if (++Index == Length)
                    return false;
                else
                    return true;
            }
            public void Reset()
            {
                _index = -1;
            }
        }
    }
}
