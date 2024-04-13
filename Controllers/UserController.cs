using MDW.Context;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace MDW.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly MDWDbContext _dbContext;

        public UserController(MDWDbContext  dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<User> objUserList = _dbContext.users.ToList();
            return View(objUserList);
        }
    }
}
