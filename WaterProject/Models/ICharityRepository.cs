using System;
using System.Linq;
namespace WaterProject.Models
{
    //change it to interface - creates a template that is meant to be inheritted (becomes base class)
    public interface ICharityRepository
    {
        //putting in a class/object that is easy to query
        IQueryable<Project> Projects { get; }
    }
}
