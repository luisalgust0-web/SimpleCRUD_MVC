using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleCRUD_MVC.Business.Models.Output;
using SimpleCRUD_MVC.Business.Services.Base;
using SimpleCRUD_MVC.Data;
using SimpleCRUD_MVC.Data.Models;
using System.Linq.Expressions;

namespace SimpleCRUD_MVC.Business.Services
{
    public class OrderItemService : BaseService<OrderItem>
    {
        private readonly IMapper _mapper;
        private readonly SimpleCRUD_MVCContext _context;

        public OrderItemService(IMapper mapper, SimpleCRUD_MVCContext context) : base(mapper, context)
        {
            _mapper = mapper;
            _context = context;
        }

        public List<OrderItemOutput> GetOrderItemByOrderId (int orderId)
        {
            List<OrderItem> orderList = _context.OrderItem.Include(x => x.Product).Include(x => x.Order.Client).Where(x => x.OrderId == orderId).ToList();
            return _mapper.Map<List<OrderItemOutput>>(orderList);
        }
    }
}
