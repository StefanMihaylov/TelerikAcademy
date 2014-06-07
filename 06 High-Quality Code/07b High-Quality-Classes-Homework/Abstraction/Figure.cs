namespace Abstraction
{
    using System.Text;

    public abstract class Figure
    {
        public abstract double CalculatePerimeter();

        public abstract double CalculateSurface();

       public override string ToString()
       {
           StringBuilder result = new StringBuilder();

           result.AppendFormat("I am a {0}. ", this.GetType().Name);
           result.AppendFormat("My perimeter is {0:f2}. ", this.CalculatePerimeter());
           result.AppendFormat("My surface is {0:f2}.", this.CalculateSurface());

           return result.ToString();
       }
    }
}
