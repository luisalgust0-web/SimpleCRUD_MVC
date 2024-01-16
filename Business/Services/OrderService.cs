using AutoMapper;
using SimpleCRUD_MVC.Business.Models.Output;
using SimpleCRUD_MVC.Business.Services.Base;
using SimpleCRUD_MVC.Data;
using SimpleCRUD_MVC.Data.Models;
using System.Transactions;

namespace SimpleCRUD_MVC.Business.Services
{
    public class OrderService : BaseService<Order>
    {
        public readonly OrderItemService _orderItemService;
        public OrderService(IMapper mapper, SimpleCRUD_MVCContext context, OrderItemService orderItemService) : base(mapper, context)
        {
            _orderItemService = orderItemService;
        }

        public override bool Delete(int id)
        {
            List<OrderItemOutput> ordersItem =  _orderItemService.GetOrderItemByOrderId(id);
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (var orderItem in ordersItem)
                {
                    _orderItemService.Delete(orderItem.Id);
                }
                base.Delete(id);

                scope.Complete();
            }
            return true;
        }
    }
}
