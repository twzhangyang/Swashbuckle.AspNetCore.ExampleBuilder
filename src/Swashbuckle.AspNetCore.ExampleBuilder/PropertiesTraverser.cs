using System;
using System.Collections;
using System.Reflection;

namespace Swashbuckle.AspNetCore.ExampleBuilder
{
    public class PropertiesTraverser
    {
        private readonly object _o;

        public PropertiesTraverser(object o)
        {
            _o = o;
        }

        public PropertiesGraph Walk()
        {
            if (!_o.GetType().IsClass)
            {
                throw new ArgumentException("waiting input class object");
            }

            var graph = new PropertiesGraph(null, _o, _o.GetType());
            var properties = _o.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                Walk(graph, property.Name, property.GetValue(_o), property.PropertyType);
            }

            return graph;
        }

        private void Walk(PropertiesGraph graph, string propertyName, object o, Type type)
        {
            if (o == null)
            {
               graph.AddSimpleValueProperty(propertyName, null, type);
               return;
            }
            
            if (type.IsSimpleType())
            {
                var t = type.IsGenericType ? type.GetGenericArguments()[0] : type;
                graph.AddSimpleValueProperty(propertyName, o, t);
            }
            else if (type.IsArray)
            {
                var nestedType = type.GetElementType();

                foreach (var item in o as Array)
                {
                    var itemNode = new PropertiesGraph(null, item, item.GetType());
                    graph.AddArrayProperty(propertyName, itemNode);

                    Walk(itemNode, null, item, nestedType);
                }
            }
            else if (type.IsListType())
            {
                var nestedType = type.GetGenericArguments()[0];

                foreach (var item in o as IEnumerable)
                {
                    var itemNode = new PropertiesGraph(null, item, item.GetType());
                    graph.AddArrayProperty(propertyName, itemNode);

                    Walk(itemNode, null, item, nestedType);
                }
            }
            else
            {
                var graphNode = new PropertiesGraph(propertyName, o, type);
                var properties = o.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (var property in properties)
                {
                    Walk(graphNode, property.Name, property.GetValue(o), property.PropertyType);
                }

                graph.ObjectProperties.Add(graphNode);
            }
        }
    }
}