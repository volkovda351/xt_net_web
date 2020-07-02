using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{
	public class CycledDynamicArray<T> : DynamicArray<T>
	{
        public override IEnumerator<T> GetEnumerator()
        {
            return new CycledDynamicArrayEnumerator<T>(Mass, Length);
        }

        public class CycledDynamicArrayEnumerator<T> : DynamicArrayEnumerator<T>
        {
            public CycledDynamicArrayEnumerator(T[] mass, int length) : base(mass, length) { }

            public override bool MoveNext()
            {
                Index = (Index + 1) % Length;
                return true;
            }
        }

    }
}
