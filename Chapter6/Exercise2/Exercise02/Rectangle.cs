namespace Exercise02
{
    public class Rectangle : Shape
    {
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
            Area = width * height;
        }
    }
}