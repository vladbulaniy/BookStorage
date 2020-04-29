using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BookStorage
{
    public static class CustomMapper
    {
        public static D Map<S, D>(S source, D destination)
        {
            var sType = typeof(S);
            var dType = typeof(D);
            var sourceProperties = GetPropertysList(typeof(S));
            var destinationProperties = GetPropertysList(typeof(D));

            foreach (var item in sourceProperties)
            {
                PropertyInfo dPropertyInfo = dType.GetProperty(item);
                PropertyInfo sPropertyInfo = sType.GetProperty(item);
                dPropertyInfo.SetValue(destination, GetPropValue(source,item));
            }

            return destination;
        }

        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }

        public static List<string> GetPropertysList(Type t)
        {
            var result = from f in t.GetProperties() select f.Name;
            return result.ToList();
        }
    }
}
