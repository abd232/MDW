using MDW.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using NpgsqlTypes;
using System.Diagnostics;

namespace MDW.Controllers
{
    [ApiController]
    [Route("drug")]
    public class DrugController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly MDWDbContext _dbContext;
        
        public DrugController(MDWDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("addDrug")]
        public void addDrug(Drug drug)
        {
            _dbContext.drugs.Add(drug);
            _dbContext.SaveChanges();
        }
        [HttpGet]
        [Route("GetDrugCount")]
        public int GetDrugCount()
        {
            return _dbContext.drugs.Count();
        }
        [HttpGet]
        [Route("GetDrug/{PageNum}/{PageSize}")]
        public Drug[] GetDrug(int PageNum = 1, int PageSize = 50,int orderby = 0)
        {
            return _dbContext.drugs.OrderBy(p => p.Id).Skip((PageNum - 1)* PageSize ).Take(PageSize).ToArray();
        }
        [HttpGet]
        [Route("GetDrugById/{DrugId}")]
        public ActionResult<Drug> GetDrugById(int DrugId = 0)
        {
            var drug = _dbContext.drugs.Find(DrugId);
            if (drug != null)
                return Ok(_dbContext.drugs.Find(DrugId));
            else 
                return BadRequest();
        }
        [HttpPost]
        [Route("EditDrug")]
        public ActionResult EditDrug([FromForm] Drug drug)
        {
            var drug1 = _dbContext.drugs.Find(drug.Id);
            if (drug1 == null)
                return BadRequest(drug1);
            //Debug.WriteLine(drug.Id + " " + drug1.Id);
            drug1.drugname = drug.drugname;
            drug1.genericnames = drug.genericnames;
            drug1.dosetype = drug.dosetype; 
            drug1.dosetype = drug.dosetype;
            _dbContext.SaveChanges();
            return Redirect("Index");
        }
        [HttpDelete]
        [Route("DeleteDrug/{DrugId}")]
        public ActionResult DeleteDrug(int DrugId)
        {
            var drug = _dbContext.drugs.Find(DrugId);
            if (drug != null) {
                _dbContext.drugs.Remove(drug);
                _dbContext.SaveChanges(true);
                return Ok();
            }
            else
                return BadRequest();
        }
    }
}