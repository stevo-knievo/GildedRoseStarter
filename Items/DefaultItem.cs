using System;

namespace GildedRoseKata.Items
{
    public abstract class DefaultItem : Item
    {
        public abstract void Process();

        protected void ProcessSellIn()
        {
            SellIn -= 1;
        }

        protected void SetQuality(int incremental)
        {
            if (Name.Contains("conjured", StringComparison.OrdinalIgnoreCase))
            {
                incremental *= 2;
            }

            Quality += incremental;


            if (Quality > 50)
            {
                Quality = 50;
            }

            if (Quality < 0)
            {
                Quality = 0;
            }
        }

        protected bool IsExpired()
        {
            return SellIn <= 0;
        }
    }
}