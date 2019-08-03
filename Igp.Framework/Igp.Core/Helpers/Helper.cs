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

        public static T Map<T>(this object source)
        {
            try
            {
                Mapper.Initialize(config => { config.CreateMap(source.GetType(), typeof(T)); });
                return Mapper.Map<T>(source);
            }
            catch (Exception ex)
            {
                return default(T);
            }

        }
    }
}
