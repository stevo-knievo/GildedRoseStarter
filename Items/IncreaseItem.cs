namespace GildedRoseKata.Items
{
    public class IncreaseItem : Item, IItem
    {
        public void Process()
        {
            if (Quality < 50)
            {
                Quality += 1;
            }

            if (SellIn <= 0)
            {
                Quality += 1;
            }

            if (Quality > 50)
            {
                Quality = 50;
            }

            SellIn -= 1;
        }
    }
}