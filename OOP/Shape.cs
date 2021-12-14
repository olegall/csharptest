using System;

namespace OOP
{
    public class Shape
    {
        public const double PI = Math.PI;
        protected double _x, _y;

        public Shape() // не нужен
        {
        }

        public Shape(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public virtual double Area()
        {
            return _x * _y;
        }
    }

    public class Circle : Shape
    {
        public Circle(double r) : base(r, 0)
        {
        }

        // без override или с new вызовется virtual double Area(). площадь будет 0, тк 1 параметр не передастся
        // отличие new и просто public double Area()?
        public override double Area()
        // public double Area()
        // public new double Area()
        {
            return PI * _x * _x;
        }
    }

    public class Sphere : Shape
    {
        public Sphere(double r) : base(r, 0)
        {
        }

        public override double Area()
        {
            return 4 * PI * _x * _x;
        }
    }

    public class Cylinder : Shape
    {
        public Cylinder(double r, double h) : base(r, h)
        {
        }

        public override double Area()
        {
            return 2 * PI * _x * _x + 2 * PI * _x * _y;
        }
    }
}
