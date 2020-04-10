using System.Collections.Generic;
using GildedRoseKata.Items;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<DefaultItem> Items;

        public GildedRose(IList<DefaultItem> items)
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