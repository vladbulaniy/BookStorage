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
            D result;
            var sourceFields = GetListFields(S);
            var destinationFields = GetListFields(D);

            foreach (var sField in sourceFields.Select((value, i) => new { i, value }))
            {
                var sFieldName = sField.value;
                var index = sField.i;

                if (sFieldName == destinationFields[index])
                {
                    result[sFieldName] = destinationFields[index];
                }
            }

            return result;
        }

        public static List<string> GetListFields(Type t)
        {
            var result = from f in t.GetFields() select f.Name;
            return result.ToList();
        }
    }
}
