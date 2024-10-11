using EmployeeCrudBlazor.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrudBlazor.Context
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

        public DbSet<Employee> Employees { get; set; }
    }
}

