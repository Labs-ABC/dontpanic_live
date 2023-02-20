using Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Services
{
  public static class DatabaseManagementService
  {
    public static void MigrationInitialisation(this IApplicationBuilder app) 
    {
      using (var serviceScope = app.ApplicationServices.CreateScope())
      {
        var serviceDb = serviceScope.ServiceProvider.GetService<DbEquationContext>();
        serviceDb.Database.Migrate();
      }
    }
  }
}
//command
//dotnet ef migrations add Inicial