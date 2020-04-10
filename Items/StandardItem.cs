namespace GildedRoseKata.Items
{
    public class StandardItem : DefaultItem
    {
        public override void Process()
        {
            SetQuality(-1);

            if (IsExpired())
            {
                SetQuality(-1);
            }

            ProcessSellIn();
        }
    }
}