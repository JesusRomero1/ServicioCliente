using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroServicio.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MicroServicio
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ABDContext>(Options => Options.UseInMemoryDatabase("ClienteDB"));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ABDContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            //Agregamos data de prueba solo si no hay data en BD
            if (!context.Clientes.Any())
            {
                context.Clientes.AddRange(new List<Cliente>()
                {
                    new Cliente(){Nombre = "Jesús", Apellido="Romero", Edad="35", FechaNacimiento="23/06/84"},
                    new Cliente(){Nombre = "Juan", Apellido="Rosales", Edad="30", FechaNacimiento="23/06/89"},
                    new Cliente(){Nombre = "Luis", Apellido="Bravo", Edad="25", FechaNacimiento="23/06/94"},
                    new Cliente(){Nombre = "Anthony", Apellido="Cardin", Edad="20", FechaNacimiento="23/99/"},
                    new Cliente(){Nombre = "Sara", Apellido="Jimenez", Edad="15", FechaNacimiento="23/06/02"}
                });

                context.SaveChanges();
            }
        }
    }
}
