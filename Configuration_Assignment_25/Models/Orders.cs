using ServiceContracts.DTO;

namespace Configuration_Assignment_25.Models
{
    /// <summary>
    /// Model class for Orders
    /// </summary>
    public class Orders
    {
        public List<BuyOrderResponse> BuyOrders { get; set; } = new List<BuyOrderResponse>();
        public List<SellOrderResponse> SellOrders { get; set; } = new List<SellOrderResponse>();
    }
}
