using System;
using Microsoft.EntityFrameworkCore;

//this is the class that allows the program to access the DB
namespace WaterProject.Models
{
    //colon is how you show inheritance
    //DbContext allows the crud functionality
    public class CharityDBContext : DbContext
    {
        //contructor - just has the name and the computer knows
        public CharityDBContext (DbContextOptions<CharityDBContext> options) : base (options)
        {

        }

        //type of object that we are building or wanting to store (set of projects)
        public DbSet<Project> Projects { get; set; }
    }
}
