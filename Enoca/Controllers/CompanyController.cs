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
            var companies = cm.TGetList();
            return await Task.FromResult(Ok(companies));
        }
        [HttpPost]
        public async Task<IActionResult> Post(Company company)
        {
            cm.TAdd(company);
            return await Task.FromResult(Ok("Başarıyla Şirket Eklendi"));
        }
    }
}
