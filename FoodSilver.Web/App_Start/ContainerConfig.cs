using Autofac;
using Autofac.Integration.Mvc;
using FoodSilver.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// we will remove .App_Start from this namespace to be like other config files
namespace FoodSilver.Web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            // build the IoC container
            var builder = new ContainerBuilder();

            // this extention method is designed for mvc 5 and it's search for all controllers and adds them to the container, it take the assembly file
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // we will use the instance of 'InMemoryRestaurantData' as a singleton but this will never work for multiple users cuz they will edit the same object but will work for now
            // we can config it to creat a new instance on each http req also
            builder.RegisterType<InMemoryRestaurantData>().As<IRestaurantData>().SingleInstance();

            // tells mvc5 to use this container to resolve DI
            var container = builder.Build();

            // pass my container as a resolver to this entire app and use autofac to wrap it, this method is part of mvc assembly
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}