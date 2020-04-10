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
        private IEnumerable<Item> UpdateQuality(string name = "Sulfuras, Hand of Ragnaros", int sellIn = 0, int quality = 80)
        {
            var items = new List<Item> {new Item {Name = name, SellIn = sellIn, Quality = quality}};
            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            return items;
        }

        [Fact]
        public void DoNothingGivenSulfuras()
        {
            var items = UpdateQuality();
            Assert.Equal(80, items.First().Quality);
        }

        [Fact]
        public void AllItemsDecreaseSellInValue()
        {
            var items = UpdateQuality("Foo", 10, 9);
            Assert.Equal(9, items.First().SellIn);
        }

        [Fact]
        public void AllItemsDecreaseQualityValue()
        {
            var items = UpdateQuality("Foo", 10, 9);
            Assert.Equal(8, items.First().Quality);
        }

        [Fact]
        public void QualityValueShouldDecreaseTwiceAsFastIfSellInIsPasted()
        {
            var items = UpdateQuality("Foo", 0, 9);
            Assert.Equal(7, items.First().Quality);
        }
    }
}