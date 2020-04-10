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

        private static IItem UpdateQuality(IItem item)
        {
            var items = new List<IItem> {item};
            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            return items.First();
        }

        [Fact]
        public void DoNothingGivenSulfuras()
        {
            var item = UpdateQuality(new LegendaryItem() {Name = "Sulfuras, Hand of Ragnaros", SellIn = DefaultSellIn, Quality = DefaultQuality});
            Assert.Equal(DefaultSellIn, item.SellIn);
            Assert.Equal(DefaultQuality, item.Quality);
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
        }


        [Fact]
        public void QualityShouldBeNeverMoreThanFifty()
        {
            var item = UpdateQuality(new IncreaseItem {Name = "Aged Brie", SellIn = DefaultSellIn, Quality = 50});
            Assert.Equal(50, item.Quality);
        }


        [Fact]
        public void QualityOfBackstagePassesOutsideOfTenDays()
        {
            var item = UpdateQuality(new ConcertItems {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = DefaultQuality});
            Assert.Equal(DefaultQuality + 1, item.Quality);
        }


        [Fact]
        public void QualityOfBackstagePassesInsideOfTenDays()
        {
            var item = UpdateQuality(new ConcertItems {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = DefaultSellIn, Quality = DefaultQuality});
            Assert.Equal(DefaultQuality + 2, item.Quality);
        }

        [Fact]
        public void QualityOfBackstagePassesInsideOfFiveDays()
        {
            var item = UpdateQuality(new ConcertItems {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = DefaultQuality});
            Assert.Equal(DefaultQuality + 3, item.Quality);
        }

        [Fact]
        public void QualityOfBackstagePassesAfterTheConcertDate()
        {
            var item = UpdateQuality(new ConcertItems {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = DefaultQuality});
            Assert.Equal(0, item.Quality);
        }
    }
}