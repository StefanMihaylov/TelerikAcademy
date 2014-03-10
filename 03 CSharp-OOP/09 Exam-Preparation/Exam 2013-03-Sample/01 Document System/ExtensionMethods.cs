using System;

namespace DocumentSystem
{
    public static class ExtensionMethods
    {
        public static uint ToUInt(this object obj)
        {
            uint result = 0;
            uint.TryParse(obj.ToString(), out result);
            return result;
        }
    }
}
