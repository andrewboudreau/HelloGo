using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace PersonApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(builder => builder
                    .Configure(app => app
                        .UseDeveloperExceptionPage()
                        .UseRouting()
                        .UseEndpoints(ep =>
                            ep.MapGet("/", async context =>
                                await context.Response.WriteAsync("Hello World!")    
                            )
                        )
                    )
                ).Build();

            await host.RunAsync();
        }
    }
}
