using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Areas.Admin.Models;
using Portfolio.Contexts;

namespace Portfolio.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize]
    public class PositionController : Controller
    {
        PortfolioDbContext _dbContext = new PortfolioDbContext();
        public IActionResult Index(int? condition)
        {
            var data = _dbContext.Positions.Where(x => x.Deleted == 0).ToList();
            return View(data);
        }

        [HttpPost]
        public IActionResult GetDataWithFilter(string condition)
        {
            List<Position> data = new List<Position>();
            
           
                switch (condition)
                {
                    case "0":
                        data = _dbContext.Positions.ToList();
                        break;
                    case "1":
                        data = _dbContext.Positions.Where(x => x.Deleted == 0).ToList();
                        break;
                    case "2":
                        data = _dbContext.Positions.Where(x => x.Deleted != 0).ToList();
                        break;
                    default:
                        break;
                }
            return View("Index", data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Position position)
        {
            _dbContext.Positions.Add(position);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var deletedData = _dbContext.Positions.FirstOrDefault(x => x.ID == id);
            if (deletedData != null)
            {
                deletedData.Deleted = id;
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
