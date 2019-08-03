using AutoMapper;
using System;

namespace IgpFramework.Api.Helpers
{
    public static class Helper
    {
        public static bool IsAssigned(this object value)
        {
            return (value == null || (value is string stringValue && String.IsNullOrEmpty(stringValue)));
        }

        public static T Map<T>(this object source) {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<object, T>(); });
            IMapper mapper = config.CreateMapper();
            return mapper.Map<object, T>(source);
        }
    }
}
    
