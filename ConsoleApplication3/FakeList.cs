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
                    count -= 1;
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
            singleResultingString += items[count - 1].ToString(); ;
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
        {//list1-list2
            foreach (T item in list2){list1.Remove(item);}
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
    }
}

//When you need to use a new object each time you are iterating over it, create a new one within loop