using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Core.Models.DTOs.Order;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IMapper mapper, IOrderRepository orderRepository) : base(mapper)
        {
            _orderRepository = orderRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> GetOrders()
        {
            var orders = await _orderRepository.GetAll();
            return Ok(Mapper.Map<IEnumerable<OrderResponse>>(orders));
        }
        
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> GetOrdersByUser(int userId)
        {
            var orders = await _orderRepository.GetByUserId(userId);
            return Ok(Mapper.Map<IEnumerable<OrderResponse>>(orders));
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResponse>> GetOrder(int id)
        {
            var order = await _orderRepository.GetById(id);
            if (order == null)
                return NotFound();
            
            return Ok(Mapper.Map<OrderResponse>(order));
        }
        
        [HttpPost]
        public async Task<ActionResult<OrderResponse>> CreateOrder([FromBody] CreateOrderRequest request)
        {
            Console.WriteLine("ASDASD");
            var order = Mapper.Map<Order>(request);
            order.Status = OrderStatus.Open;
            order.Tps = 0.05m;
            order.Tvq = 0.09975m;
            order.Total = order.SubTotal * (1 + order.Tps + order.Tvq);
            var createdOrder = await _orderRepository.Create(order);
            
            var response = Mapper.Map<OrderResponse>(createdOrder);
            return CreatedAtAction(nameof(GetOrder), new { id = createdOrder.OrderId }, response);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _orderRepository.GetById(id);
            if (order == null)
                return NotFound();
            
            await _orderRepository.Delete(id);
            return NoContent();
        }
    }
}
