namespace AttributesExample
{
    using System;

    [Version("2.3")]
    public class VersionTest
    {
        // 11. Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations and methods and holds a version in the format major.minor (e.g. 2.11). Apply the version attribute to a sample class and display its version at runtime.
        
        static void Main()
        {
            Type type = typeof(VersionTest);
            object[] allAttributes = type.GetCustomAttributes(false);
            foreach (VersionAttribute version in allAttributes)
            {
                Console.WriteLine("This class version is {0}", version.Version);
            }
        }
    }
}
