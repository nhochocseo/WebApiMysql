[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(WebApiMysql.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace WebApiMysql.App_Start
{
    using System.Web.Http;
    using System.Reflection;
    using NHibernate;
    using System;
    using System.Configuration;
    using System.Linq;
    using System.IO;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using WebApiMysql.Interface;
    using WebApiMysql.Implement;
    using Common.Response;
    using System.Collections.Generic;
    using Common;

    public class SimpleInjectorWebApiInitializer
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            InitializeContainer(container);
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void InitializeContainer(Container container)
        {
            container.Register<IPortalDanhMuc, PortalDanhMucImp>(Lifestyle.Scoped);
            container.Register<IPortalusers, PortalUsersImp>(Lifestyle.Scoped);
            // For instance:
            // Register your types, for instance using the scoped lifestyle:
            container.Register(() =>
            {
                List<TokenResponese> items;
                using (StreamReader r = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "UrlApi.json"))
                {
                    string json = r.ReadToEnd();
                    items = JsonConvert.DeserializeObject<List<TokenResponese>>(json);
                }
                return items.Where(x => x != null).ToList();
            }, Lifestyle.Transient);

            // Doc config file
            container.Register(() =>
            {
                config cf = new config();
                using (StreamReader file = File.OpenText(AppDomain.CurrentDomain.BaseDirectory + "config.json"))
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject o = (JObject)JToken.ReadFrom(reader);
                    cf.json = o;
                }
                return cf;
            }, Lifestyle.Transient);
        }
        public static void AutoMap(Container container, params Assembly[] assemblies)
        {
            container.ResolveUnregisteredType += (s, e) =>
            {
                if (e.UnregisteredServiceType.IsInterface && !e.Handled)
                {
                    Type[] concreteTypes = (
                        from assembly in assemblies
                        from type in assembly.GetTypes()
                        where !type.IsAbstract && !type.IsGenericType
                        where e.UnregisteredServiceType.IsAssignableFrom(type)
                        select type)
                        .ToArray();

                    if (concreteTypes.Length == 1)
                    {
                        e.Register(Lifestyle.Scoped.CreateRegistration(concreteTypes[0],
                            container));
                    }
                }
            };
        }
    }
}