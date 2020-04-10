using System.Collections.Generic;
using GildedRoseKata.Items;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<IItem> Items;

        public GildedRose(IList<IItem> items)
        {
            Items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                item.Process();
            }
        }
    }
}