using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Heap__Manuzzato
{
    internal class Heap
    {
        public int Count { get; private set; }

        private int[] _elements;

        public Heap()
        {
            _elements = new int[100];
            this[0] = -1;
            Count = 0;
        }

        public int this[int i]
        {
            get
            {
                return _elements[i];
            }
            set
            {
                _elements[i] = value;
            }
        }

        public void Insert(int element)
        {
            this[++Count] = element;
            GoUp(Count);
        }

        public int Remove()
        {
            if (Count == 0)
                throw new IndexOutOfRangeException("Heap vuoto");

            int smallest = this[1];
            this[1] = this[Count];
            Count--;

            GoDown(1);
            return smallest;
        }

        public int Peek()
        {
            if (Count == 0)
                throw new IndexOutOfRangeException("Heap vuoto");
            return this[1];
        }

        public int GetParent(int i)
        {
            if (i == 1)
                throw new IndexOutOfRangeException("Il nodo radice non ha un padre");
            return this[i / 2];
        }

        private void GoUp(int currentindex)
        {
            if (currentindex == 1)
                return;

            int fatherIndex = currentindex / 2;

            if (this[currentindex] < this[fatherIndex])
            {
                Swap(currentindex, fatherIndex);
                GoUp(fatherIndex);
            }
        }

        private void GoDown(int i)
        {
            int leftSon = i * 2;
            int rightSon = i * 2 + 1;

            if (leftSon > Count)
                return;

            int smallest = leftSon;
            if (rightSon <= Count && this[rightSon] < this[leftSon])
                smallest = rightSon;

            if (this[i] <= this[smallest])
                return;

            Swap(i, smallest);
            GoDown(smallest);
        }

        private void Swap(int i, int j) 
        {
            int temp = this[i];
            this[i] = this[j];
            this[j] = temp;
        }
    }
}
