using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03.DynamicArray
{
    class CycledDynamicArray<T> : DynamicArray<T>
    {
        public CycledDynamicArray(IEnumerable<T> enums)
            : base(enums) { }
        public CycledDynamicArray()
            : base() { }
        public CycledDynamicArray(int size)
            : base(size) { }

        public new CycledDynamicArrayEnum<T> GetEnumerator()
        {
            return new CycledDynamicArrayEnum<T>(array,Length);
        }
    }
}
