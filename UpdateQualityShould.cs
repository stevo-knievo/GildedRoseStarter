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

        private static Item UpdateQuality(string name = "Foo", int sellIn = DefaultSellIn, int quality = DefaultQuality)
        {
            var items = new List<Item> {new Item {Name = name, SellIn = sellIn, Quality = quality}};
            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            return items.First();
        }

        [Fact]
        public void DoNothingGivenSulfuras()
        {
            var item = UpdateQuality(name: "Sulfuras, Hand of Ragnaros");
            Assert.Equal(DefaultSellIn, item.SellIn);
            Assert.Equal(DefaultQuality, item.Quality);
        }

        [Fact]
        public void AllItemsDecreaseSellInValue()
        {
            var item = UpdateQuality();
            Assert.Equal(9, item.SellIn);
        }

        [Fact]
        public void AllItemsDecreaseQualityValue()
        {
            var item = UpdateQuality();
            Assert.Equal(DefaultQuality - 1, item.Quality);
        }

        [Fact]
        public void QualityValueShouldDecreaseTwiceAsFastIfSellInIsPasted()
        {
            var item = UpdateQuality(sellIn: 0);
            Assert.Equal(DefaultQuality - 2, item.Quality);
        }

        [Fact]
        public void QualityValueShouldNeverBeZero()
        {
            var item = UpdateQuality(quality: 0);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void IncreasesQualityGivenAgedBrie()
        {
            var item = UpdateQuality(name: "Aged Brie");
            Assert.Equal(DefaultQuality + 1, item.Quality);
        }

        [Fact]
        public void QualityShouldBeNeverMoreThanFifty()
        {
            var item = UpdateQuality(name: "Aged Brie", quality: 50);
            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void QualityOfBackstagePassesOutsideOfTenDays()
        {
            var item = UpdateQuality(name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 11);
            Assert.Equal(DefaultQuality + 1, item.Quality);
        }

        [Fact]
        public void QualityOfBackstagePassesInsideOfTenDays()
        {
            var item = UpdateQuality(name: "Backstage passes to a TAFKAL80ETC concert");
            Assert.Equal(DefaultQuality + 2, item.Quality);
        }

        [Fact]
        public void QualityOfBackstagePassesInsideOfFiveDays()
        {
            var item = UpdateQuality(name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 5);
            Assert.Equal(DefaultQuality + 3, item.Quality);
        }

        [Fact]
        public void QualityOfBackstagePassesAfterTheConcertDate()
        {
            var item = UpdateQuality(name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 0);
            Assert.Equal(0, item.Quality);
        }
    }
}