using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using uBike.Repository.Implement;
using uBike.Repository.Interface;
using uBike.Service.Implement;
using uBike.Service.Infrastructure;
using uBike.Service.Interface;
using Unity;

namespace uBike
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            //var service = new ServiceCollection();
            //ConfigureServices(service);
            
            //Repository���U
            container.RegisterType<IuBikeRepository, uBikeRepository>();

            //Service���U
            container.RegisterType<IuBikeService, uBikeService>();

            //AutoMapper���U
            var config = new MapperConfiguration(x =>x.AddProfile(new MappingProfile()));
            container.RegisterInstance<IMapper>(config.CreateMapper());

            //����@�b��IHttpClientFactory
            //container.RegisterType<IHttpClientFactory>();
        }

        //private static void ConfigureServices(ServiceCollection services)
        //{
        //    services.AddHttpClient("YouBike")
        //        .ConfigurePrimaryHttpMessageHandler(()=>new HttpClientHandler 
        //        {
        //            Proxy=new WebProxy("")
        //        })

        //}

    }
}