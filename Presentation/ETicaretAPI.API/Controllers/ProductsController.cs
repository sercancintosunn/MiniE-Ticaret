using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        readonly private IOrderWriteRepository _orderWriteRepository;

        readonly private ICustomerWriteRepository _customerWriteRepository;
        readonly private IOrderReadRepository _orderReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository,IOrderWriteRepository orderWriteRepository,ICustomerWriteRepository customerWriteRepository,IOrderReadRepository orderReadRepository)
        {
            _productReadRepository = productReadRepository; 
            _productWriteRepository = productWriteRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
            _orderReadRepository = orderReadRepository;
        }
        [HttpGet]
        public async Task Get()
        {
            Order order = await _orderReadRepository.GetByIdAsync("e08d4514-dc88-4999-ac67-86feede82935");

            order.Address = "Çanakkale";

            await _orderWriteRepository.SaveAsync();

        }

        
    }
}
