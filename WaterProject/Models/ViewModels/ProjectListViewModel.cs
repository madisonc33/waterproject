using System;
using System.Collections.Generic;

namespace WaterProject.Models.ViewModels
{
    public class ProjectListViewModel
    {
        
        public IEnumerable<Project> Projects { get; set; }

        public PagingInfo PagingInfo { get; set; }

        public string CurrentCategory { get; set; }
    }
}
