using System;
using Microsoft.AspNetCore.Mvc;
using WaterProject.Models;
using System.Linq;
using System.Collections.Generic;
namespace WaterProject.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private ICharityRepository repository;

        public NavigationMenuViewComponent (ICharityRepository r)
        {
            repository = r;
        }

        public IViewComponentResult Invoke()
        {
            //gets this from the URL
            ViewBag.SelectedType = RouteData?.Values["category"];

            return View(repository.Projects
                .Select(x => x.Type)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
