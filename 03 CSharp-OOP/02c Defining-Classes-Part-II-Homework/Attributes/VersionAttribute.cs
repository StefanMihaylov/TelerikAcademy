
namespace AttributesExample
{
    using System;

    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Method |
     AttributeTargets.Class | AttributeTargets.Interface,
    AllowMultiple = false)]

    public class VersionAttribute : System.Attribute
    {
        public string Version {get; private set;}

        public VersionAttribute(string version)
        {
            this.Version = version;
        }
    }
}
