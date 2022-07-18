namespace Sample.Core.Models.TaxCalcStore
{
    public class Item
    {
        //[PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}