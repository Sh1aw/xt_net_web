using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03.DynamicArray
{
    class CycledDynamicArrayEnum<T>: IEnumerator<T>
    {
        public T[] array;

        private int index = -1;
        private int length;
        public CycledDynamicArrayEnum(T[] array, int length)
        {
            this.array = array;
            this.length = length;

        }
        public T Current
        {
            get
            {
                try
                {
                    return array[index];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            if (index + 1 < length)
            {
                index++;
                return true;
            }
            else
            {
                index = 0;
                return true;
            }
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
