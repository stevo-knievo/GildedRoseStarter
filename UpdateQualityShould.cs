using System.Collections.Generic;
using System.Linq;
using GildedRoseKata.Items;
using Xunit;

namespace GildedRoseKata
{
    public class UpdateQualityShould
    {
        private const int DefaultSellIn = 10;
        private const int DefaultQuality = 20;

        private static DefaultItem UpdateQuality(DefaultItem item)
        {
            var items = new List<DefaultItem> {item};
            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            return items.First();
        }

        [Fact]
        public void DoNothingGivenSulfuras()
        {
            var item = UpdateQuality(new LegendaryItem() {Name = "Sulfuras, Hand of Ragnaros", SellIn = DefaultSellIn, Quality = 80});
            Assert.Equal(DefaultSellIn, item.SellIn);
            Assert.Equal(80, item.Quality);
        }

        [Fact]
        public void AllItemsDecreaseSellInValue()
        {
            var item = UpdateQuality(new StandardItem {Name = "Foo", SellIn = DefaultSellIn, Quality = DefaultQuality});
            Assert.Equal(9, item.SellIn);
        }

        [Fact]
        public void AllItemsDecreaseQualityValue()
        {
            var item = UpdateQuality(new StandardItem {Name = "Foo", SellIn = DefaultSellIn, Quality = DefaultQuality});
            Assert.Equal(DefaultQuality - 1, item.Quality);
        }

        [Fact]
        public void QualityValueShouldDecreaseTwiceAsFastIfSellInIsPasted()
        {
            var item = UpdateQuality(new StandardItem {Name = "Foo", SellIn = 0, Quality = DefaultQuality});
            Assert.Equal(DefaultQuality - 2, item.Quality);
        }


        [Fact]
        public void QualityValueShouldNeverBelowZero()
        {
            var item = UpdateQuality(new StandardItem {Name = "Foo", SellIn = DefaultSellIn, Quality = 0});
            Assert.Equal(0, item.Quality);
        }


        [Fact]
        public void IncreasesQualityGivenAgedBrie()
        {
            var item = UpdateQuality(new IncreaseItem {Name = "Aged Brie", SellIn = DefaultSellIn, Quality = DefaultQuality});
            Assert.Equal(DefaultQuality + 1, item.Quality);
            Assert.Equal(DefaultSellIn - 1, item.SellIn);
        }


        [Fact]
        public void QualityShouldBeNeverMoreThanFifty()
        {
            var item = UpdateQuality(new IncreaseItem {Name = "Aged Brie", SellIn = DefaultSellIn, Quality = 50});
            Assert.Equal(50, item.Quality);
            Assert.Equal(DefaultSellIn - 1, item.SellIn);
        }


        [Fact]
        public void QualityOfBackstagePassesOutsideOfTenDays()
        {
            var item = UpdateQuality(new ConcertItems {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = DefaultQuality});
            Assert.Equal(DefaultQuality + 1, item.Quality);
            Assert.Equal(10, item.SellIn);
        }


        [Fact]
        public void QualityOfBackstagePassesInsideOfTenDays()
        {
            var item = UpdateQuality(new ConcertItems {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = DefaultSellIn, Quality = DefaultQuality});
            Assert.Equal(DefaultQuality + 2, item.Quality);
            Assert.Equal(DefaultSellIn - 1, item.SellIn);
        }

        [Fact]
        public void QualityOfBackstagePassesInsideOfTenDaysShouldNeverBeMoreThenFifty()
        {
            var item = UpdateQuality(new ConcertItems {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = DefaultSellIn, Quality = 49});
            Assert.Equal(50, item.Quality);
            Assert.Equal(DefaultSellIn - 1, item.SellIn);
        }

        [Fact]
        public void QualityOfBackstagePassesInsideOfFiveDays()
        {
            var item = UpdateQuality(new ConcertItems {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = DefaultQuality});
            Assert.Equal(DefaultQuality + 3, item.Quality);
            Assert.Equal(4, item.SellIn);
        }

        [Fact]
        public void QualityOfBackstagePassesInsideOfFiveDaysShouldNeverBeMoreThenFifty()
        {
            var item = UpdateQuality(new ConcertItems {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49});
            Assert.Equal(50, item.Quality);
            Assert.Equal(4, item.SellIn);
        }

        [Fact]
        public void QualityOfBackstagePassesAfterTheConcertDate()
        {
            var item = UpdateQuality(new ConcertItems {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = DefaultQuality});
            Assert.Equal(0, item.Quality);
            Assert.Equal(-1, item.SellIn);
        }

        [Fact]
        public void QualityOfConjuredItems()
        {
            var item = UpdateQuality(new StandardItem {Name = "Conjured Mana Cake", SellIn = DefaultSellIn, Quality = DefaultQuality});
            Assert.Equal(DefaultQuality - 2, item.Quality);
            Assert.Equal(DefaultSellIn - 1, item.SellIn);
        }
    }
}