namespace GildedRoseKata.Items
{
    public class ConcertItems : Item, IItem
    {
        public void Process()
        {
            if (SellIn <= 10 && SellIn > 5)
            {
                Quality += 2;
            }
            else if (SellIn <= 5)
            {
                Quality += 3;
            }
            else
            {
                Quality += 1;
            }

            if (Quality > 50)
            {
                Quality = 50;
            }

            if (SellIn <= 0)
            {
                Quality = 0;
            }

            SellIn -= 1;
        }
    }
}