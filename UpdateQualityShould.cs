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
        private const int DefaultSellIn = 10;
        private const int DefaultQuality = 20;

        private static IEnumerable<Item> UpdateQuality(string name = "Foo", int sellIn = DefaultSellIn, int quality = DefaultQuality)
        {
            var items = new List<Item> {new Item {Name = name, SellIn = sellIn, Quality = quality}};
            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            return items;
        }

        [Fact]
        public void DoNothingGivenSulfuras()
        {
            var items = UpdateQuality(name: "Sulfuras, Hand of Ragnaros");
            var item = items.First();
            Assert.Equal(DefaultSellIn, item.SellIn);
            Assert.Equal(DefaultQuality, item.Quality);
        }

        [Fact]
        public void AllItemsDecreaseSellInValue()
        {
            var items = UpdateQuality();
            Assert.Equal(9, items.First().SellIn);
        }

        [Fact]
        public void AllItemsDecreaseQualityValue()
        {
            var items = UpdateQuality();
            Assert.Equal(DefaultQuality - 1, items.First().Quality);
        }

        [Fact]
        public void QualityValueShouldDecreaseTwiceAsFastIfSellInIsPasted()
        {
            var items = UpdateQuality(sellIn: 0);
            Assert.Equal(DefaultQuality - 2, items.First().Quality);
        }

        [Fact]
        public void QualityValueShouldNeverBeZero()
        {
            var items = UpdateQuality(quality: 0);
            Assert.Equal(0, items.First().Quality);
        }

        [Fact]
        public void IncreasesQualityGivenAgedBrie()
        {
            var items = UpdateQuality(name: "Aged Brie");
            Assert.Equal(DefaultQuality + 1, items.First().Quality);
        }

        [Fact]
        public void QualityShouldBeNeverMoreThanFifty()
        {
            var items = UpdateQuality(name: "Aged Brie", quality: 50);
            Assert.Equal(50, items.First().Quality);
        }

        [Fact]
        public void QualityOfBackstagePassesOutsideOfTenDays()
        {
            var items = UpdateQuality(name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 11);
            Assert.Equal(DefaultQuality + 1, items.First().Quality);
        }

        [Fact]
        public void QualityOfBackstagePassesInsideOfTenDays()
        {
            var items = UpdateQuality(name: "Backstage passes to a TAFKAL80ETC concert");
            Assert.Equal(DefaultQuality + 2, items.First().Quality);
        }

        [Fact]
        public void QualityOfBackstagePassesInsideOfFiveDays()
        {
            var items = UpdateQuality(name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 5);
            Assert.Equal(DefaultQuality + 3, items.First().Quality);
        }

        [Fact]
        public void QualityOfBackstagePassesAfterTheConcertDate()
        {
            var items = UpdateQuality(name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 0);
            Assert.Equal(0, items.First().Quality);
        }
    }
}