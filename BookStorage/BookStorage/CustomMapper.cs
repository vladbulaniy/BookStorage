using BookStorage.Attributes;
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
            var sourceProperties = GetPropertieysList(typeof(S));
            var destinationProperties = GetPropertieysList(typeof(D));

            foreach (var item in sourceProperties)
            {
                PropertyInfo dPropertyInfo = dType.GetProperty(item);
                PropertyInfo sPropertyInfo = sType.GetProperty(item);
                
                if (Validation(sPropertyInfo, dPropertyInfo))
                {
                    dPropertyInfo.SetValue(destination, GetPropValue(source, item));
                }                
            }
            return destination;
        }

        public static bool Validation (PropertyInfo sPropertyInfo, PropertyInfo dPropertyInfo)
        {
            bool result = false;
            Ignore attr = (Ignore)Attribute.GetCustomAttribute(sPropertyInfo, typeof(Ignore), false);
            var isIgnore = attr?.isIgnore ?? false;

            result = sPropertyInfo.Name == dPropertyInfo.Name && sPropertyInfo.PropertyType == dPropertyInfo.PropertyType && !isIgnore;
            
            return result;
        }

        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }

        public static List<string> GetPropertieysList(Type t)
        {
            var result = from f in t.GetProperties() select f.Name;
            return result.ToList();
        }

        public static D ForMember<D>(D destination, Func<int, int> retF)
        { 

            return destination;
        }
    }
}
