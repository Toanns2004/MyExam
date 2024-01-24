using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyExam.Entities;
using MyExam.DTOs;
using MyExam.Model;
using Microsoft.AspNetCore.Authorization;

namespace MyExam.Controllers
{
    [ApiController]
    [Route("/api/order")]
    public class OrderController : Controller
    {
        private readonly OrderSystemContext _context;
        public OrderController(OrderSystemContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create(OrderModel model)
        {
            try
            {
                Order order = new Order {
                    Name = model.Name,
                    Quantity = model.Quantity,
                    Deliverytime = model.Deliverytime,
                    Address = model.Address,
                    Phone = model.Phone
                };
                _context.OrderTbl.Add(order);
                _context.SaveChanges();
                return Created("", new OrderDTO
                {
                    Name = order.Name,
                    Quantity = order.Quantity,
                    Deliverytime = order.Deliverytime,
                    Address = order.Address,
                    Phone = order.Phone
                });

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Edit(OrderModel model)
        {
            try
            {
                _context.OrderTbl.Update(new Order
                {
                    id = model.Id,
                    Deliverytime = model.Deliverytime,
                    Address = model.Address,
                });
                _context.SaveChanges();
                return Ok("Successfully");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }
    }
}
