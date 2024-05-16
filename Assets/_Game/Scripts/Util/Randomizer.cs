using AppCore;
using System;
using System.Collections.Generic;

namespace IdleRPG
{
    public class Randomizer<T> where T : IRandomValue
    {
        public Randomizer()
        {
        }

        public T GetRandomValue(IEnumerable<T> randomValues)
        {
            List<T> allItems = new List<T>(randomValues);

            if (allItems.Count <= 0)
                throw new ArgumentOutOfRangeException(randomValues.ToString());

            float totalChance = 0f;

            allItems?.Shuffle();

            foreach (var item in allItems)
            {
                totalChance += item.Chance;
            }

            float random = FloatRange.Random(0f, totalChance);
            float cumulativeChance = 0f;

            foreach (var item in allItems)
            {
                cumulativeChance += item.Chance;

                if (random <= cumulativeChance)
                    return item;
            }

            return default;
        }

    }
}