using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var Users = new User[3] {
    new User(1, "James", "Breefton", DateTimeOffset.Now.AddDays(-31) , 4),
    new User(2, "Anna", "Forkenspoon", DateTimeOffset.Now.AddDays(-7),5),
    new User(3, "Dee", "Argile", DateTimeOffset.Now, 10),
};

var host = Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(builder => builder
        .Configure(app => app
            .UseRouting()
            .UseEndpoints(ep =>
            {
                ep.MapGet("/users", async context =>
                    await context.Response.WriteAsJsonAsync(Users));

                ep.MapGet("/users/{id:int}", async context =>
                {
                    var id = int.Parse(context.Request.RouteValues["id"].ToString()) - 1;
                    await context.Response.WriteAsJsonAsync(Users[id]);
                });

                ep.MapGet("/", async context =>
                    await context.Response.WriteAsync("Hello World!"));
            })
        ))
    .Build();

await host.RunAsync();

record User(int Id, string GivenName, string FamilyName, DateTimeOffset StartDate, int Rating);
