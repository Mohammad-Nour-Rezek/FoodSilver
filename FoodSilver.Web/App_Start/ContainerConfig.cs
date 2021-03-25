using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using FoodSilver.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

// we will remove .App_Start from this namespace to be like other config files
namespace FoodSilver.Web
{
    public class ContainerConfig
    {
        // give it 'HttpConfiguration httpConfiguration' parameter for web api
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            // build the IoC container
            var builder = new ContainerBuilder();

            // this extention method is designed for mvc 5 and it's search for all controllers and adds them to the container, it take the assembly file
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            
            // register all api controllers in the application
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            // we will use the instance of 'InMemoryRestaurantData' as a singleton but this will never work for multiple users cuz they will edit the same object but will work for now
            // we can config it to creat a new instance on each http req also
            //builder.RegisterType<InMemoryRestaurantData>().As<IRestaurantData>().SingleInstance();
            builder.RegisterType<SqlRestaurantData>()
                   .As<IRestaurantData>()
                    // we use this pattern if the component implement 'unit of work': create a particular component and allowed it to be around for a single HTTP req and after performing all operation for a particular req from a user, when the req is over throw it away and then create new one for new req
                   .InstancePerRequest(); // create an instance of SqlRestaurantData with each comming request

            // register the DbContext object in the container and now EF need connection string in web.config, when component start with req the instance will look to connection string when instantiate the class with the same class name
            // type SqlRestaurantData need to injected in the constructor
            builder.RegisterType<FoodSilverDbContext>().InstancePerRequest();

            // tells mvc5 to use this container to resolve DI
            var container = builder.Build();

            // pass my container as a resolver to this entire app and use autofac to wrap it, this method is part of mvc assembly
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // for wep api
            // need Autofac.WebApi2 pkg, this way all api controllers are registered in the IoC container
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}