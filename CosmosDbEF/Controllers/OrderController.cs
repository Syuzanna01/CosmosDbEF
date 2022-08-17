using CosmosDbEF.Data;
using CosmosDbEF.Model;
using Microsoft.AspNetCore.Mvc;

namespace CosmosDbEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DataContext _Context;
        public OrderController(DataContext Context)
        {
            _Context = Context;
        }
        [HttpPost("SaveOrders")]
        public ActionResult SaveOrder()
        {
            var order = new Order()
            {
                ID = 1,
                FirstName = "Albus",
                LastName = "Dambldor",
                Age = "150",
                Email = "Hogwarts.am"
            };
            _Context.Order.Add(order);
            _Context.SaveChanges();

            return Ok();
        }
    }
}
