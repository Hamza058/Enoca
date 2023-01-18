using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enoca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        CompanyManager cm = new CompanyManager(new EFCompanyDal());

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await Task.FromResult(Ok(cm.TGetList()));
        }
        [HttpPost]
        public async Task<IActionResult> Post(Company company)
        {
            cm.TAdd(company);
            return await Task.FromResult(Ok("Başarıyla Şirket Eklendi"));
        }
        [HttpPut]
        public async Task<IActionResult> Put(Company company)
        {
            var value = cm.TGetByID(company.CompanyId);
            if (value != null)
            {
                value.StartTime = company.StartTime;
                value.FinishTime= company.FinishTime;
                value.Status = company.Status;
                cm.TUpdate(value);
                return await Task.FromResult(Ok("Başarıyla Güncellendi"));
            }
            else
            {
                return await Task.FromResult(NotFound("Girilen id ye ait şirket bulunamadı"));
            }
        }
    }
}
