using System;
using System.Linq;
namespace WaterProject.Models
{
    //widely used and reduced duplication
    //
    public class EFCharityRepository : ICharityRepository
    {
        private CharityDBContext _context;

        //constructor
        public EFCharityRepository (CharityDBContext context)
        {
            _context = context;
        }

        public IQueryable<Project> Projects => _context.Projects;
    }
}
