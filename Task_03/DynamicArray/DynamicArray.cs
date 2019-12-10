﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03.DynamicArray
{
    class DynamicArray<T>: IEnumerable<T>, IEnumerable
    {
        public int Length { get; private set; }
        public int Capacity
        {
            get => array.Length;
        }

        private T[] array;
        public DynamicArray()
        {
            array = new T[8];
            Length = 0;
        }
        public DynamicArray(int size)
        {
            array = new T[size];
            Length = 0;
        }
        public DynamicArray(IEnumerable<T> enums)
        {
            array = new T[enums.Count()];
            Length = 0;
            foreach (var item in enums)
            {
                array[Length] = item;
                Length++;
            }

        }


        public T this[int index]
        {
            get
            {
                if (index > Length || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return array[index];
            }
            set
            {
                if (index > Length || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                array[index] = value;
            }
        }
        public void Add(T something)
        {
            if (Length >= Capacity)
            {
                ResizeArray();
            }
            array[Length] = something;
            Length++;
        }
        public void AddRange(IEnumerable<T> enums)
        {
            if ((Length + enums.Count()) >= Capacity)
            {
                ResizeArray(Length + enums.Count());
            }
            foreach (var item in enums)
            {
                array[Length] = item;
                Length++;
            }
        }
        public bool Remove(T elem)
        {
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(elem))
                {
                    index = i;
                    MakeUnShift(index);
                    Length--;
                    return true;
                }
            }
            return false;
        }
        public bool Insert(int position, T elem)
        {
            if (position < 0 || position > Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            if ((Length + 1) >= Capacity)
            {
                ResizeArray();
            }
            MakeShift(position, elem);
            Length++;
            return true;

        }
        public T[] ToArray()
        {
            T[] outArray = new T[Length];
            for (int i = 0; i < Length; i++)
            {
                outArray[i] = array[i];
            }
            return outArray;
        }

        private void MakeUnShift(int index)
        {
            for (int i = index; i < Length; i++)
            {
                array[i] = array[i + 1];
            }
        }
        private void MakeShift(int index, T elem)
        {
            for (int i = Length; i >= index; i--)
            {
                array[i + 1] = array[i];
            }
            array[index] = elem;
        }
        private void ResizeArray()
        {
            T[] newArray = new T[array.Length * 2];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
            array = newArray;
        }
        private void ResizeArray(int newCapacity)
        {
            T[] newArray = new T[newCapacity];
            int iU = 0;
            if (newCapacity <= array.Length)
            {
                iU = newCapacity;
            }
            else
            {
                iU = array.Length;
            }
            for (int i = 0; i < iU; i++)
            {
                newArray[i] = array[i];
            }
            array = newArray;
        }


        public DynamicArrayEnum<T> GetEnumerator()
        {
            return new DynamicArrayEnum<T>(array, Length);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
