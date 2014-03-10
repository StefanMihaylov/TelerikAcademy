namespace ThreeDSpace
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class PathStorage
    {
        public static void SavePath(Path path)
        {
            StreamWriter writer = new StreamWriter(@"../../SavedPath.txt");
            using (writer)
            {
                foreach (var point in path.AllPoints3D)
                {
                    writer.WriteLine(point);
                }
            }
        } 

        public static Path LoadPath()
        {
            Path result = new Path();
            StreamReader reader = new StreamReader(@"../../SavedPath.txt");
            using (reader)
            {
                string currentLine = reader.ReadLine();
                while (currentLine != null)
                {
                    string[] coordinates = currentLine.Split(new char[] { '{', ',', '}' }, StringSplitOptions.RemoveEmptyEntries);
                    double coordinateX = double.Parse(coordinates[0]);
                    double coordinateY = double.Parse(coordinates[1]);
                    double coordinateZ = double.Parse(coordinates[2]);
                    Point3D currentPoint = new Point3D(coordinateX, coordinateY, coordinateZ);
                    result.Add(currentPoint);

                    currentLine = reader.ReadLine();
                }                
            }
            return result;
        }
    }
}
