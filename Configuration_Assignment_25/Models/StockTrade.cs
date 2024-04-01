namespace Configuration_Assignment_25.Models
{
    /// <summary>
    /// Model class for Stock Trades related values
    /// </summary>
    public class StockTrade
    {
        public string? StockSymbol { get; set; }
        public string? StockName { get; set; }
        public double Price { get; set; } = 0;
        public uint Quantity{ get; set; } = 0;
    }
}
