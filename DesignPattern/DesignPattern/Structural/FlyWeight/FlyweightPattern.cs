using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Structural.FlyWeight
{
    //https://dotnettutorials.net/lesson/flyweight-design-pattern/
    internal class FlyweightPattern
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n Red color Circles ");
            for (int i = 0; i < 3; i++)
            {
                Circle circle = (Circle)ShapeFactory.GetShape("circle");
                circle.SetColor("Red");
                circle.Draw();
            }
            Console.WriteLine("\n Green color Circles ");
            for (int i = 0; i < 3; i++) 
            {
                Circle circle = (Circle)ShapeFactory.GetShape("circle");
                circle.SetColor("Green");
                circle.Draw();
            }
            Console.WriteLine("\n Blue color Circles");
            for (int i = 0; i < 3; ++i)
            {
                Circle circle = (Circle)ShapeFactory.GetShape("circle");
                circle.SetColor("Green");
                circle.Draw();
            }
            Console.WriteLine("\n Orange color Circles");
            for (int i = 0; i < 3; ++i)
            {
                Circle circle = (Circle)ShapeFactory.GetShape("circle");
                circle.SetColor("Orange");
                circle.Draw();
            }
            Console.WriteLine("\n Black color Circles");
            for (int i = 0; i < 3; ++i)
            {
                Circle circle = (Circle)ShapeFactory.GetShape("circle");
                circle.SetColor("Black");
                circle.Draw();
            }
            Console.ReadKey();
        }
        //Flyweight interface
        public interface IShape
        {
            void Draw();
        }

        //Creating ConcreteFlyweight
        public class Circle : IShape
        {
            public string Color { get; set; }
            private int XCor = 10;
            private int YCor = 10;
            private int Radius = 30;
            public void SetColor(string Color)
            {
                this.Color = Color;
            }
            public void Draw()
            {
                Console.WriteLine(" Circle: Draw() [Color : " + Color + ", X Cor : " + XCor + ", YCor :" + YCor + ", Radius :"
                        + Radius);
            }
        }

        //create FlyWeight Factory
        public class ShapeFactory
        {
            private static Dictionary<string, IShape> shapeMap = new Dictionary<string, IShape>();
            public static IShape GetShape(string shapeType)
            {
                IShape shape = null;
                if (shapeType.Equals("circle", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (shapeMap.TryGetValue("circle", out shape))
                    {
                    }
                    else
                    {
                        shape = new Circle();
                        shapeMap.Add("circle", shape);
                        Console.WriteLine(" Creating circle object with out any color in shapefactory \n");
                    }
                }
                return shape;
            }
        }
    }
}
