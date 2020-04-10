namespace GildedRoseKata.Items
{
    public interface IItem
    {
        void Process();
        string Name { get; set; }
        int SellIn { get; set; }
        int Quality { get; set; }
    }
}