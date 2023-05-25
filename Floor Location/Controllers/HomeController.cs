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
        public void AddExcelValue(string Location_name, string Location_ID, string Is_clearance)
        {
            _exMap.AddExcelValue(Location_name, Location_ID, Is_clearance);
        }
        public void UpdateExcelValue(int rowIndex, string Location_name, string Location_ID, string Is_clearance)
        {
            _exMap.UpdateExcelValue(rowIndex, Location_name, Location_ID, Is_clearance);
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