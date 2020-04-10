using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace GildedRoseKata
{
    public class UpdateQualityShould
    {
        [Fact]
        public void DoNothingGivenSulfuras()
        {
            var items = new List<Item> {new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80}};
            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();
            Assert.Equal(80, items.First().Quality);
        }

        [Fact]
        public void AllItemsDecreaseSellInValue()
        {
            var items = new List<Item> {new Item {Name = "Foo", SellIn = 10, Quality = 9}};
            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();
            Assert.Equal(9, items.First().SellIn);
        }
    }
}