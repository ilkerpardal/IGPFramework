using System;

namespace IgpFramework.Api.Helpers
{
    public static class Helper
    {
        public static bool IsAssigned(this object value)
        {
            return (value == null || (value is string stringValue && String.IsNullOrEmpty(stringValue)));
        }
    }
}
    
