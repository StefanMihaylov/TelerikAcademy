namespace CohesionAndCoupling
{
    using System;

    public class FileNameSplitter
    {
        public static string GetFileExtension(string fileName)
        {
            int indexOfLastDot = GetDotIndex(fileName);
            string extension = fileName.Substring(indexOfLastDot + 1);
            return extension;
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            int indexOfLastDot = GetDotIndex(fileName);
            string extension = fileName.Substring(0, indexOfLastDot);
            return extension;
        }

        private static int GetDotIndex(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException("Filename cannot be null or whitespace");
            }

            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                throw new ArgumentNullException("Invalid filename! Filename doesn't contain extention and '.' symbol!");
            }

            return indexOfLastDot;
        }
    }
}
