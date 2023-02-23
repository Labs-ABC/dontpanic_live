using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
	public class DbEquationContext : DbContext
	{
		public DbEquationContext(DbContextOptions<DbEquationContext> options) : base(options)
		{
		}

		public DbSet<Equation> Equations { get; set; }
	}
}
