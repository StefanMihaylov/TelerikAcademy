namespace TraverseDirectory
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class TraverseDir
    {
        public const string Extention = ".exe";
       // public const string Root = @"C:\Windows"; // too many files
        public const string Root = @"C:\Windows\System32";

        public static void Main()
        {
            var rootDir = new DirectoryInfo(Root);

            Stack<DirectoryInfo> stack = new Stack<DirectoryInfo>();
            stack.Push(rootDir);

            while (stack.Count > 0)
            {
                var currentDir = stack.Pop();
                try
                {
                    var files = currentDir.GetFiles().Where(f => f.Extension == Extention).ToList();
                    if (files.Count > 0)
                    {
                        Console.WriteLine("\tDir: {0} => {2} Files: {1}",
                            currentDir.FullName, string.Join(", ", files.Select(f => f.Name)), files.Count);
                    }

                    var subDirectories = currentDir.GetDirectories();
                    foreach (var dir in subDirectories)
                    {
                        stack.Push(dir);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("\t No permition for dir \"{0}\"", currentDir.FullName);
                }

            }
        }
    }
}
