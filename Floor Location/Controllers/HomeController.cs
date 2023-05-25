using Floor_Location.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Floor_Location.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ExcelAccess _exMap;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _exMap = new ExcelAccess();
        }

        public IActionResult Index()
        {
            ExcelAccess excelMap = new ExcelAccess();
            //List<ExcelMapDM> excelMapData = excelMap.ExcelList();
            var excelList = excelMap.ExcelList();

            ExcelMapVM model = new ExcelMapVM()
            {
                excelMapDM = excelList
            };

            return View(model);
        }
        public IActionResult AddExcelValue(string Location_name, string Location_ID, string Is_clearance)
        {
            _exMap.AddExcelValue(Location_name, Location_ID, Is_clearance);

            return RedirectToAction("Index");
        }
        public IActionResult UpdateExcelValue(int rowIndex, string Location_name, string Location_ID, string Is_clearance)
        {
            int adjustedIndex = rowIndex + 1;
            _exMap.UpdateExcelValue(adjustedIndex, Location_name, Location_ID, Is_clearance);

            return RedirectToAction("Index");
        }
        public IActionResult DeleteExcelRow(int rowIndex)
        {
            int adjustedIndex = rowIndex + 1;
            _exMap.DeleteExcelRow(adjustedIndex);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}