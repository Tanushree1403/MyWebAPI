using Autofac;
using Autofac.Integration.Mvc;
using EmployeeManagement.Web.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Web.AutoFac
{
	public class ContainerConfig
	{
        public static void RegisterContainer()
        {
            // create new IOC container
            var builder = new ContainerBuilder();
            // add controllers to this container
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<EmployeeDB>().As<IEmployeeDB>().SingleInstance();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
	}
}