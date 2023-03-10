﻿using Guide.Finance.EntityFramework;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Guide.Finance.E2ETests.Base;

public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
       
        builder.UseEnvironment("E2ETests");
        builder.ConfigureServices(services =>
        {
            var serviceProvider = services.BuildServiceProvider();
            using var scope = serviceProvider.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetService<GuideFinanceDbContext>();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            
        });
        base.ConfigureWebHost(builder);
    }
}