using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace NullReference.Data
{
    public interface IConfigureAutoMappings { }

    public class AutoMap
    {
        private static IMappingEngine _engine;

        public static TDestination Map<TSource, TDestination>(TSource source)
        {
            if (_engine == null)
            {
                var markerInterface = typeof(IConfigureAutoMappings);                
                var assemblies = AppDomain.CurrentDomain.GetAssemblies();

                var cfgs = new List<Type>();

                foreach (var assembly in assemblies)
                {
                    try
                    {
                        var typesInAssembly = assembly.GetTypes().Where(p => markerInterface.IsAssignableFrom(p) && p.IsClass);
                        cfgs.AddRange(typesInAssembly);
                    }
                    catch (ReflectionTypeLoadException)
                    {
                    }
                }

                foreach (var type in cfgs)
                    Activator.CreateInstance(type);

                _engine = Mapper.Engine;
            }

            return _engine.Map<TSource, TDestination>(source);
        }        
    }    
}
