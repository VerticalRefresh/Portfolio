using barham_d424_capstone.Models;

namespace barham_d424_capstone.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrdersThisWeekAsync();
        Task<List<Order>> GetAllOrdersAsync();
    }
}
