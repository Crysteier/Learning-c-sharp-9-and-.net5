namespace Exercise02
{
    public class Square : Shape
    {
        public string Color;

        public Square(string color, double width)
        {
            Color = color;
            Width = width;
            Height = width;
            Area = width * width;
        }
    }
}