using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igp.Core.Helpers
{
    public static class Helper
    {
        public static bool IsAssigned(this object value)
        {
            return !(value == null || (value is string stringValue && String.IsNullOrEmpty(stringValue)));
        }

        public static T Map<T>(this object source, Dictionary<Type,Type> types)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    foreach (var item in types)
                    {
                        cfg.CreateMap(item.Key, item.Value);
                    }
                }
                );
                var mapper = config.CreateMapper();
                return mapper.Map<T>(source);
            }
            catch (Exception ex)
            {
                return default(T);
            }

        }
    }
}
