namespace CohesionAndCoupling
{
    using System;

    public class UtilsExamples
    {
        public static void Main()
        {
            Console.WriteLine("File extentions:");

            // Console.WriteLine(FileNameSplitter.GetFileExtension("example"));
            Console.WriteLine(FileNameSplitter.GetFileExtension("example.pdf"));
            Console.WriteLine(FileNameSplitter.GetFileExtension("example.new.pdf"));

            Console.WriteLine("\nFile names:");

            // Console.WriteLine(FileNameSplitter.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileNameSplitter.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileNameSplitter.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("\nCalculate distance:");
            Console.WriteLine("Distance in the 2D space = {0:f2}", Geometry.CalculateDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}", Geometry.CalculateDistance3D(5, 2, -1, 3, -6, 4));

            double width = 3;
            double height = 4;
            double depth = 5;
            Console.WriteLine();
            Console.WriteLine("Volume = {0:f2}", Geometry.CalculateVolume(width, height, depth));
            Console.WriteLine("Diagonal XYZ = {0:f2}", Geometry.CalculateDiagonal3D(width, height, depth));
            Console.WriteLine("Diagonal XY = {0:f2}", Geometry.CalculateDiagonal2D(width, height));
            Console.WriteLine("Diagonal XZ = {0:f2}", Geometry.CalculateDiagonal2D(width, depth));
            Console.WriteLine("Diagonal YZ = {0:f2}", Geometry.CalculateDiagonal2D(height, depth));
        }
    }
}
