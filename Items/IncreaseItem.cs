namespace GildedRoseKata.Items
{
    public class IncreaseItem : DefaultItem
    {
        public override void Process()
        {
            SetQuality(1);

            if (IsExpired())
            {
                SetQuality(1);
            }

            ProcessSellIn();
        }
    }
}