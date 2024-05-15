using System.Collections.Generic;
using UnityEngine;

namespace AppCore
{
    public class RandomList<T>
    {
        private List<T> allItems = new List<T>();
        private List<int> queueIndexesUsedToNotRepeat = new List<int>();
        private int dontRepeatLastItems = 3;

        public RandomList(List<T> allItems, int dontRepeatLastItems = 3)
        {
            this.allItems = new List<T>(allItems);
            this.dontRepeatLastItems = Mathf.Max(dontRepeatLastItems, 0);
        }

        public int GetRandomIndexFromArrayOfIndexes(List<int> indexes) => indexes[UnityEngine.Random.Range(0, indexes.Count)];

        private List<int> IndexesToList(int count)
        {
            var list = new List<int>();
            for (int i = 0; i < count; i++)
            {
                list.Add(i);
            }
            return list;
        }

        private void FlushPreviousQueue()
        {
            // If queue is higher than items to not repeat - flush queue. Not important, but it's better to clear it.
            while (queueIndexesUsedToNotRepeat.Count > dontRepeatLastItems)
            {
                queueIndexesUsedToNotRepeat.RemoveAt(0);
            }
        }

        public T GetRandomItem()
        {
            var tempArray = IndexesToList(allItems.Count);

            for (int i = 0;
                // Index has to be less than total amount of queued to not repeat
                i < queueIndexesUsedToNotRepeat.Count
                // Index has to be less than unrepeatable number
                && i < dontRepeatLastItems
                // Amount of items left for random has to be at least 1
                && tempArray.Count > 1; i++)
            {
                // Last index of queued array
                int lastIndexInQueue = queueIndexesUsedToNotRepeat.Count - 1;
                // Remove items starting with the last used
                tempArray.Remove(queueIndexesUsedToNotRepeat[lastIndexInQueue - i]);
            }

            // Random index from list of indexes
            var indexToBeUsed = GetRandomIndexFromArrayOfIndexes(tempArray);

            // Added random item to the end of queue
            queueIndexesUsedToNotRepeat.Add(indexToBeUsed);

            FlushPreviousQueue();

            return allItems[indexToBeUsed];
        }
    }
}
