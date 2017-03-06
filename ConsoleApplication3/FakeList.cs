using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public class FakeList<T> : IEnumerable<T>
    {
        private T[] items;
        private int count;
        private int capacity;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        public int Capacity
        {   
            get { return capacity; }
            set { capacity = value; }
        }

        public FakeList()
        {
            count = 0;
            capacity = 0;
            items = new T[capacity];            
        }

        public T this[int index]
        {
            get
            { if (index >= 0 && index <= Count)
                {
                    return items[index];
                }
                return items[index];
            }
            set
            {
                if (index >= 0 && index <= Count)
                {
                    items[index] = value;
                }
            }
        }

        public T GetItem(int index)
        {
            return items[index];
        }


        public void Add(T itemToAdd)
        {
            T[] itemsAdded = new T[count + 1];
            for (int i = 0; i < count; i++)
            {
                itemsAdded[i] = items[i];
            }
            IncreaseCapacity();
            items = itemsAdded;
            items[count] = itemToAdd;
            count += 1;
        }
        public void IncreaseCapacity()
        {
            if (capacity < count * 2)
            {
                capacity = capacity * 2;
            }
        }

        public bool Remove(T itemToRemove)
        {
            for (int i = 0; i < count; i++)
            {
                if (items[i].Equals(itemToRemove))
                {
                    int indexOfFirstInstance = i;
                    
                    for (int j = indexOfFirstInstance; j < count-1; j++)
                    {
                        items[j]=items[j+1];
                    }
                    items[count-1] = default(T);
                    count --;
                    return true;
                }
            }           
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < items.Length; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
             return GetEnumerator();
        }

        public override string ToString()      
        {
            string singleResultingString = "";

            for (int i = 0; i < count-1; i++)
            {
                singleResultingString += items[i].ToString() + ", ";
            }
            singleResultingString += items[count - 1].ToString(); 
            return singleResultingString;
        }

        public  static FakeList<T> operator+ (FakeList<T> list1, FakeList<T> list2)
        {
            FakeList<T> combinedList = new FakeList<T>();
            for (int i = 0; i < list1.Count; i++)
            {
                combinedList.Add(list1[i]);
            }
            foreach (T item in list2)
            {
                combinedList.Add(item);
            }
            return combinedList;
        }

        public static FakeList<T> operator -(FakeList<T> list1, FakeList<T> list2)
        {
            foreach (T item in list2)
            {
                list1.Remove(item); 
            }
            return list1;
        }

        public FakeList<T> Zip(FakeList<T> listToZipWith)
        {
            int countOfShorterList = (count >= listToZipWith.Count) ? listToZipWith.count : count;
            int countOfZipper = 2 * countOfShorterList;
            FakeList<T> resultingList = new FakeList<T>();
            for (int i = 0; i < countOfZipper; i++)
            {
                if (i % 2 == 0)
                {
                    resultingList.Add(items[i/2]);
                }
                else
                {
                    resultingList.Add(listToZipWith[(i-1)/2]);
                }
            }
            return resultingList;
        }

        public FakeList<T> Zip(FakeList<T> firstAddedList, FakeList<T> secondAddedList)
        {
            int countOfShorterAddedList = (firstAddedList.Count>= secondAddedList.Count)?
                secondAddedList.Count : firstAddedList.Count;
            int countOfShortestList = (count >= countOfShorterAddedList) ? count : countOfShorterAddedList;
            int countOfZipper = 3 * countOfShortestList;
            FakeList<T> resultingList = new FakeList<T>();
            for (int i = 0; i < countOfZipper; i++)
            {
                if (i % 3 == 0)
                {
                    resultingList.Add(items[i / 3]);
                }
                else if (i % 3 == 1)
                {
                    resultingList.Add(firstAddedList[(i - 1) / 3]);
                }
                else if (i % 3 == 2)
                {
                    resultingList.Add(secondAddedList[(i - 2) / 3]);
                }
            }
            return resultingList;
        }

        public FakeList<T> Zip(FakeList<T> firstAddedList, FakeList<T> secondAddedList, 
            FakeList<T> thirdAddedList)
        {
            int countOfShortestList;
            if (count <= firstAddedList.Count && count <= secondAddedList.Count && count <= thirdAddedList.Count)
            {
                countOfShortestList = count;
            }
            else if (firstAddedList.Count <= count && firstAddedList.Count <= secondAddedList.Count
                && firstAddedList.Count <= thirdAddedList.Count)
            {
                countOfShortestList = firstAddedList.Count;
            }
            else if (secondAddedList.Count <= count && secondAddedList.Count <= firstAddedList.Count
                && secondAddedList.Count <= thirdAddedList.Count)
            {
                countOfShortestList = secondAddedList.Count;
            }
            else if (thirdAddedList.Count <= count && thirdAddedList.Count <= firstAddedList.Count &&
                thirdAddedList.Count <= secondAddedList.Count)
            {
                countOfShortestList = thirdAddedList.Count;
            }
            else countOfShortestList = count;

            int countOfZipper = 4 * countOfShortestList;
            FakeList<T> resultingList = new FakeList<T>();
            for (int i = 0; i < countOfZipper; i++)
            {
                if (i % 4 == 0)
                {
                    resultingList.Add(items[i / 4]);
                }
                else if (i % 4 == 1)
                {
                    resultingList.Add(firstAddedList[(i - 1) / 4]);
                }
                else if (i % 4 == 2)
                {
                    resultingList.Add(secondAddedList[(i - 2) / 4]);
                }
                else if (i % 4 == 3)
                {
                    resultingList.Add(thirdAddedList[(i - 3) / 4]);
                }
            }
            return resultingList;
        }

        public  void Swap(T[] items, int m, int n)
        {
            T temporary;

            temporary = items[m];
            items[m] = items[n];
            items[n] = temporary;
        }
        //public abstract int Compare(T x, T y)
        //{
        //Comparer<T>.Compare Method (T, T)
        //}

        //public void BubbleSort()
        //{
        //    int i, j;
        //    for (j=Count-1; j>0; j--)
        //    {
        //        for (i=0; i < j; i++)
        //        {
        //            if (items[i].Compare(items[i + 1])  )  //FIND HOW TO COMPARE GENERICS (Icomparable?)
        //            {
        //                Swap(items, i, i + 1);
        //            }
        //        }
        //    }
        //}
    }
}

