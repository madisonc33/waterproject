using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WaterProject.Models;
using WaterProject.Models.ViewModels;

namespace WaterProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ICharityRepository _repository;

        public int PageSize = 4;

        public HomeController(ILogger<HomeController> logger, ICharityRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index(string category, int page= 1 )
        {
            //query using Linq ( can write saw SQL which we will learn later
            return View(new ProjectListViewModel
            {
                Projects = _repository.Projects
                    .Where(p => category == null || p.Type == category)
                    .OrderBy(p => p.ProjectId)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    //checks if it is null, if it is then if takes the total of all projects, otherwise it gets it where the category matches
                    TotalNumItems = category == null ? _repository.Projects.Count() : _repository.Projects.Where(x => x.Type == category).Count()
                },
                CurrentCategory = category
            }) ;
        }

        //can pass in the name of the page you want to call, and pass objects
        //objects passed come in automatically (@model IEnumerable<object>) makes it iterable - allows us to say "foreach i in Model" and go through them
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
