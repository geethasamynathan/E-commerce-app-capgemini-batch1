using AutoMapper;
using E_Commerce_Backend.DTO;
using E_Commerce_Backend.IService;
using E_Commerce_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;

namespace E_Commerce_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderRepository;
        private readonly IMapper _mapper;
        private readonly EcommerceContext _context;
        private readonly ILogger<OrderController> _logger;
        public OrderController(IMapper mapper, EcommerceContext context, ILogger<OrderController> logger, IOrderService orderRepository)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
            _orderRepository = orderRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Order> orders = _context.Orders.ToList();
            if (orders != null)
            {
                var orderDTOs = _mapper.Map<List<OrderDTO>>(orders);
                return Ok(orderDTOs);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<OrderDTO> GetById(int id)
        {
            var order = _context.Orders.Find(id)

    ;
            if (order == null)
            {
                return NotFound();
            }

            var orderDTO = _mapper.Map<OrderDTO>(order);
            return orderDTO;
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetByUserId(int userId)
        {
            var orders = _orderRepository.GetByUserId(userId);
            return Ok(orders);
        }

        [HttpGet("status/{status}")]
        public IActionResult GetByStatus(string status)
        {
            var orders = _orderRepository.GetByStatus(status);
            return Ok(orders);
        }

        [HttpPost]
        public IActionResult Add([FromBody] OrderDTO orderdto)
        {
            var order = _mapper.Map<Order>(orderdto);
            order.OrderDate = DateTime.Now;
            order.Status = "Pending";
            _orderRepository.Add(order);
          // _orderRepository.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = order.OrderId }, orderdto);
        }
        [HttpPut]
        public IActionResult Update(int id, [FromBody] OrderDTO orderdto)
        {
            if (id != orderdto.OrderId)
            {
                return BadRequest();
            }

            var existingOrder = _orderRepository.GetById(id)

    ;

            if (existingOrder == null)
            {
                return NotFound();
            }
            existingOrder.UserId = orderdto.UserId;
            existingOrder.ProductId = orderdto.ProductId;
            existingOrder.OrderId = orderdto.OrderId;
            existingOrder.Quantity = orderdto.Quantity;
            Order order = _mapper.Map<Order>(orderdto);
            order.OrderDate = DateTime.Now;
            order.Status = "Pending";
            _orderRepository.Update(order);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var order = _orderRepository.GetById(id)

    ;
            if (order == null)
            {
                return NotFound();
            }
            _orderRepository.Delete(id)

    ;
            return Ok();
        }
    }
}
