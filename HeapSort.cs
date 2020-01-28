using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeRecoveryCS
{
    class HeapSort
    {
        public void Heap_Sort(FoundBars[] array)
        {
            Heap_Sort(array, 0, array.Length, Comparer<int>.Default);
        }

        public static void Heap_Sort(FoundBars[] array, int offset, int length, IComparer<int> comparer)
        {
            Heap_Sort(array, offset, length, comparer.Compare);
        }

        public static void Heap_Sort(FoundBars[] array, int offset, int length, Comparison<int> comparison)
        {
            // build binary heap from all items
            for (int i = 0; i < length; i++)
            {
                int index = i;
                FoundBars item = array[offset + i]; // use next item

                // and move it on top, if greater than parent
                while (index > 0 && comparison(array[offset + (index - 1) / 2].x, item.x) < 0)
                {
                    int top = (index - 1) / 2;
                    array[offset + index] = array[offset + top];
                    index = top;
                }
                array[offset + index] = item;
            }

            for (int i = length - 1; i > 0; i--)
            {
                // delete max and place it as last
                FoundBars last = array[offset + i];
                array[offset + i] = array[offset];

                int index = 0;
                // the last one positioned in the heap
                while (index * 2 + 1 < i)
                {
                    int left = index * 2 + 1, right = left + 1;

                    if (right < i && comparison(array[offset + left].x, array[offset + right].x) < 0)
                    {
                        if (comparison(last.x, array[offset + right].x) > 0) break;

                        array[offset + index] = array[offset + right];
                        index = right;
                    }
                    else
                    {
                        if (comparison(last.x, array[offset + left].x) > 0) break;

                        array[offset + index] = array[offset + left];
                        index = left;
                    }
                }
                array[offset + index] = last;
            }
        }
    }


    public class HeapSortSize
    {
        public void Heap_Sort(List<FoundBars> array)
        {
            Heap_Sort(array, 0, array.Count, Comparer<int>.Default);
        }

        public static void Heap_Sort(List<FoundBars> array, int offset, int length, IComparer<int> comparer)
        {
            Heap_Sort(array, offset, length, comparer.Compare);
        }

        public static void Heap_Sort(List<FoundBars> array, int offset, int length, Comparison<int> comparison)
        {
            // build binary heap from all items
            for (int i = 0; i < length; i++)
            {
                int index = i;
                FoundBars item = array[offset + i]; // use next item

                // and move it on top, if greater than parent
                while (index > 0 && comparison(array[offset + (index - 1) / 2].barWidth, item.barWidth) < 0)
                {
                    int top = (index - 1) / 2;
                    array[offset + index] = array[offset + top];
                    index = top;
                }
                array[offset + index] = item;
            }

            for (int i = length - 1; i > 0; i--)
            {
                // delete max and place it as last
                FoundBars last = array[offset + i];
                array[offset + i] = array[offset];

                int index = 0;
                // the last one positioned in the heap
                while (index * 2 + 1 < i)
                {
                    int left = index * 2 + 1, right = left + 1;

                    if (right < i && comparison(array[offset + left].barWidth, array[offset + right].barWidth) < 0)
                    {
                        if (comparison(last.barWidth, array[offset + right].barWidth) > 0) break;

                        array[offset + index] = array[offset + right];
                        index = right;
                    }
                    else
                    {
                        if (comparison(last.barWidth, array[offset + left].barWidth) > 0) break;

                        array[offset + index] = array[offset + left];
                        index = left;
                    }
                }
                array[offset + index] = last;
            }
        }
    }
}
