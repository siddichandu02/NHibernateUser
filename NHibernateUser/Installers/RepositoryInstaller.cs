using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using NHibernateUser.Repository;

namespace NHibernate.Installer
{
    

    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
                        container.Register(
                        Classes.FromThisAssembly()
                        .BasedOn(typeof(IRepository))
                        .WithService.AllInterfaces()
                        .LifestylePerWebRequest());
            // container.Register(Component.For(typeof(IRepository<>)().ImplementedBy(typeof(Repository<>)())));
        }
	}
}

       