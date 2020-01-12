using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace ProdajaVozilaApp.Model.Dto.Alati
{
    public static class GetProperties
    { 
        public static object GetPropertyValue(object source, string propertyName)
        {
            PropertyInfo property = source.GetType().GetProperty(propertyName);
            return property.GetValue(source, null);
        }

        public static Dictionary<string, string> MakeDictionaryOfProperties(object @object, int brojNivoa)
        {
            if(brojNivoa<=0 || @object==null) return new Dictionary<string, string>();
            var props = @object.GetType().GetProperties();

            var keyValueTuples = props.Select(e => (e.Name, GetProperties.GetPropertyValue(@object, e.Name))).ToList();

            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach ((string Name, object obj) in keyValueTuples)
            {
                if(Regex.IsMatch(Name,@".*(([Ii][Dd])|(Slika)).*")) continue;
                if (obj is IObject)
                {
                    foreach ((string Var, string Value) in MakeDictionaryOfProperties(obj, brojNivoa-1))
                    {
                        dictionary.Add(Var, Value);
                    }
                }
                else
                {
                    if(obj==null) continue;
                    dictionary.Add(CamelCaseToText(Name), obj?.ToString());
                }
            }
            return dictionary;
        }

        private static string CamelCaseToText(string camelString)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int i = 0;
            foreach (char c in camelString)
            {
                if (i!=0 && $"{c}".ToUpper() == $"{c}")
                    stringBuilder.Append($" {c}".ToLower());
                else
                    stringBuilder.Append(c);
                i++;
            }
            return stringBuilder.ToString();
        }
    }
}
