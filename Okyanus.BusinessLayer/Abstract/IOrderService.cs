using Okyanus.EntityLayer.Entities;

namespace Okyanus.BusinessLayer.Abstract
{
    public interface IOrderService : IGenericService<Order>
    {
        Task UpdateOrderStatusAsync(int id, string orderStatus);
    }
}
