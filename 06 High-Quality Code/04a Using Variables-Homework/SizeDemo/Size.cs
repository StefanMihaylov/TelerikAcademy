using System;

public class Size
{
    public Size(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    public double Width { get; set; }

    public double Height { get; set; }

    public static Size GetRotatedSize(Size size, double rotationAngle)
    {
        double sinOfAngle = Math.Sin(rotationAngle);
        double cosineOfAngle = Math.Cos(rotationAngle);
        double absoluteSinOfAngle = Math.Abs(sinOfAngle);
        double absoluteCosineOfAngle = Math.Abs(cosineOfAngle);

        double rotatedWidth = (size.Width * absoluteCosineOfAngle) + (size.Height * absoluteSinOfAngle);
        double rotatedHeight = (size.Width * absoluteSinOfAngle) + (size.Height * absoluteCosineOfAngle);

        Size rotatedSize = new Size(rotatedWidth, rotatedHeight);

        return rotatedSize;
    }
}
