namespace FilesTree
{
    using System;
    using System.IO;

    public class Program
    {
        /* Define classes File { string name, int size } and Folder { string name, File[] files, Folder[] childFolders } and using them build a tree keeping all files and folders on the hard drive starting from C:\WINDOWS. Implement a method that calculates the sum of the file sizes in given subtree of the tree and test it accordingly. Use recursive DFS traversal. */

        public static void Main()
        {
            Folder root = ReadFolderInfo(@"C:\Windows\System32");  // C:\Windows - too slow - only 33GB on my PC

            long size = CalculateSize(root);
            Console.WriteLine("\n\t Directory \"{2}\" size is {0} bytes = {1:f2} Mb", size, ((double)size)/(1024*1024), root.Name);
        }

        private static long CalculateSize(Folder folder)
        {
            long sum = 0;
            if (folder.Files != null)
            {
                for (int i = 0; i < folder.Files.Length; i++)
                {
                    sum += folder.Files[i].Size;
                }
            }

            if (folder.ChildFolders != null)
            {
                for (int i = 0; i < folder.ChildFolders.Length; i++)
                {
                    sum += CalculateSize(folder.ChildFolders[i]);
                }
            }

            return sum;
        }

        private static Folder ReadFolderInfo(string path)
        {
            File[] filesWithSize = null;
            Folder[] subFolders = null;
            try
            {
                string[] fileNames = Directory.GetFiles(path);
                filesWithSize = new File[fileNames.Length];
                for (int i = 0; i < fileNames.Length; i++)
                {
                    string fileName = fileNames[i];
                    FileInfo info = new FileInfo(fileName);
                    filesWithSize[i] = new File(info.Name, info.Length);
                }

                string[] directoryNames = Directory.GetDirectories(path);

                subFolders = new Folder[directoryNames.Length];
                for (int i = 0; i < directoryNames.Length; i++)
                {
                    string dirName = directoryNames[i];
                    subFolders[i] = ReadFolderInfo(dirName);
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("\t No permition for directory \"{0}\"", path);
            }

            return new Folder(path, filesWithSize, subFolders);
        }
    }
}
