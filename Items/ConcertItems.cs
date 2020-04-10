namespace GildedRoseKata.Items
{
    public class ConcertItems : DefaultItem
    {
        public override void Process()
        {
            if (IsPreSale())
            {
                SetQuality(2);
            }
            else if (IsLastMinuteSale())
            {
                SetQuality(3);
            }
            else
            {
                SetQuality(1);
            }

            if (IsExpired())
            {
                SetToSoldOut();
            }

            ProcessSellIn();
        }

        private bool IsLastMinuteSale()
        {
            return SellIn <= 5;
        }

        private bool IsPreSale()
        {
            return SellIn <= 10 && SellIn > 5;
        }

        private void SetToSoldOut()
        {
            Quality = 0;
        }
    }
}