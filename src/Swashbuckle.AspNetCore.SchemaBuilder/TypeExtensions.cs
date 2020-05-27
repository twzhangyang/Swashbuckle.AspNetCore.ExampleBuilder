using System;
using System.Collections.Generic;

namespace Swashbuckle.AspNetCore.SchemaBuilder
{
    public static class TypeExtensions
    {
        public static bool IsListType(this Type type)
        {
            if (!type.IsGenericType)
            {
                return false;
            }

            var genericTypeDefinition = type.GetGenericTypeDefinition();
            if (genericTypeDefinition == typeof(List<>))
            {
                return true;
            }

            if (genericTypeDefinition == typeof(IEnumerable<>))
            {
                return true;
            }

            if (genericTypeDefinition == typeof(IReadOnlyCollection<>))
            {
                return true;
            }

            return false;
        }

        public static bool IsSimpleType(this Type type)
        {
            if (type.IsNullablePrimitiveType())
            {
                return true;
            }
            
            return type.IsPrimitive
                   || type.IsEnum
                   || type == typeof(DateTimeOffset)
                   || type == typeof(DateTime)
                   || type == typeof(string)
                   || type == typeof(decimal);
            
        }

        public static bool IsNullablePrimitiveType(this Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return true;
            }

            return false;
        }
    }
}