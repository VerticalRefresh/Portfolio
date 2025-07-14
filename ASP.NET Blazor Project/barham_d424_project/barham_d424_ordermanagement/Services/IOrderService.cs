using barham_d424_ordermanagement.Models;

namespace barham_d424_ordermanagement.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrdersThisWeekAsync();
        Task<List<Order>> GetAllOrdersAsync();
    }
}
