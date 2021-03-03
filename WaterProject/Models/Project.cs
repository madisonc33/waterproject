using System;
using System.ComponentModel.DataAnnotations;
namespace WaterProject.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        public string Type {get;set;}

        public string Program { get; set; }

        public int Impact { get; set; }

        public string Phase { get; set; }

        public DateTime CompletionDate { get; set; }

        public string Features { get; set; }
    }
}
