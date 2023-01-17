using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enoca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductManager pm = new ProductManager(new EFProductDal());

        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            pm.TAdd(product);
            return await Task.FromResult(Ok("Başarıyla Şirket Eklendi"));
        }
    }
}
