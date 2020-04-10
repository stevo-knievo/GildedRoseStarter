using System;

namespace GildedRoseKata.Items
{
    public class StandardItem : Item, IItem
    {
        public void Process()
        {
            if (Quality > 0)
            {
                Quality -= 1;

                if (SellIn <= 0)
                {
                    Quality -= 1;
                }
            }

            if (Quality < 0)
            {
                Quality = 0;
            }

            SellIn -= 1;
        }
    }
}