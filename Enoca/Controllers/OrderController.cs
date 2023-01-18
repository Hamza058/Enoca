using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enoca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        OrderManager om = new OrderManager(new EFOrderDal());
        CompanyManager cm=new CompanyManager(new EFCompanyDal());

        [HttpPost]
        public async Task<IActionResult> Post(Order order)
        {
            try
            {
                var company = cm.TGetByID(order.CompanyId);
                bool date = company.StartTime <= order.Date && order.Date <= company.FinishTime;

                if (company.Status)
                {
                    if(date)
                    {
                        om.TAdd(order);
                        return await Task.FromResult(Ok("Başarıyla sipariş oluşturuldu"));
                    }
                    else
                    {
                        return await Task.FromResult(NotFound("Firma Şuanda Sipariş Almıyor"));
                    }
                    
                }
                else
                {
                    return await Task.FromResult(NotFound("Firma Onaylı Değil"));
                }
            }
            catch (Exception)
            {
                return await Task.FromResult(BadRequest());
            }
            
        }
    }
}
