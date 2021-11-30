using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope()) 
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.EnsureCreated();
                
                //Cinemas
                if(!context.Cinemas.Any())
                {

                }
                //Actors
                if (!context.Actors.Any())
                {

                }
                //Producers
                if (!context.Producers.Any())
                {

                }
                //Movies
                if (!context.Movies.Any())
                {

                }
                //Actors and Movies
                if (!context.Actors_Movies.Any())
                {

                }
            }
        }
    }
}
