namespace ThreeDSpace
{
    using System;

    class PathTestMain
    {
        /*
        1. Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space. Implement the ToString() to 
	        enable printing a 3D point.
        2. Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}. 
	        Add a static property to return the point O.
        3. Write a static class with a static method to calculate the distance between two points in the 3D space.
        4. Create a class Path to hold a sequence of points in the 3D space. 
           Create a static class PathStorage with static methods to save and load paths from a text file. Use a file format 
            of your choice. */

        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            // define two points
            Point3D firstPoint = new Point3D(1.1, 2.2, 3.3);
            Point3D secondPoint = new Point3D(5.5, 4.4, 6.6);
            Point3D thirdPoint = new Point3D(9.9, 8.8, 7.7);
            
            // print center of coordinate system
            Console.WriteLine("Point0: {0}", Point3D.Point0);

            // print points
            Console.WriteLine("Point1: {0}",firstPoint);
            Console.WriteLine("Point2: {0}",secondPoint);
            Console.WriteLine("Point3: {0}",thirdPoint);

            // distance betweent two points
            Console.WriteLine("Distance between Point1 and Point3 is {0:f3}", Distance3D.CalcDistance(firstPoint,thirdPoint));
            Console.WriteLine();

            // add point to path
            Path path = new Path();
            path.Add(firstPoint);
            path.Add(secondPoint);
            path.Add(thirdPoint);

            // save path
            PathStorage.SavePath(path);


            Console.WriteLine(" Restored paths");
            Path restoredPath = PathStorage.LoadPath();
            foreach (var currestPath in restoredPath.AllPoints3D)
            {
                Console.WriteLine(currestPath);
            }

        }
    }
}
