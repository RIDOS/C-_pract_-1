using System;

namespace lab_2
{
    public class Point
    {
        public int a { get; set; }
        public int b { get; set; }

        public Point()
        {
            a = 0;
            b = 0;
        }

        public Point(int A_coord, int B_coord)
        {
            this.a = A_coord;
            this.b = B_coord;
        }

        public void Print()
        {
            Console.WriteLine("Дана точка с координатами ({0}; {1})", a, b);
        }
    }

    public class Segment : Point
    {
        public int c { get; set; }
        public int d { get; set; }

        public Segment(int A_coord, int B_coord, int C_coord, int D_coord) : base(A_coord, B_coord)
        {
            this.c = C_coord;
            this.d = D_coord;
        }

        public double Dlina()
        {
            return Math.Sqrt((c - a) * (c - a) + (b - d) * (b - d));
        }

        public new void Print()
        {
            Console.WriteLine("Дана отрезок с началом " +
                "координат ({0}; {1}) и концом ({2}; {3}).\n" +
                "Длинна отрезка |CD| = {4}.", a, b, c, d, Dlina());
        }
    }

    public class Circle : Segment
    {
        public int x { get; set; }
        public int y { get; set; }

        double A, B, C, D, E, F, G;
        bool is_circle = true;

        public Circle(int a, int b, int c, int d, int X, int Y): base(a, b, c, d)
        {
            // Центр окружности.
            this.x = X;
            this.y = Y;

            A = c - a;
            B = d - b;
            C = x - a;
            D = y - b;
            E = A * (a + c) + B * (b + d);
            F = C * (a + x) + D * (b + y);
            G = 2 * (A * (y + d) + B * (x + c));

            if (G == 0)
            {
                Console.WriteLine("Точки лежат на одной линии.");
                is_circle = false;
            }
        }


        public double Radius()
        {
            double Cx, Cy;
            Cx = (D * E - B * F) / G;
            Cy = (A * F - C * E) / G;

            return Math.Sqrt(Math.Pow(a - Cx, 2) + Math.Pow(b - Cy, 2));
        }
		
		public double Diametr()
		{
			return 2 * Math.PI* Radius()
		}
        
        public new void Print()
        {
            if (is_circle) 
                Console.WriteLine("Радиус окружности R = {0:0.##}. Диаметр окружности C = {1:0.##}", Radius(), Diametr());
            else 
                Console.WriteLine("Точки не образуют окружность.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Circle sm = new Circle(-6, 3, -3, 2, 0, 3);
            sm.Print();
            Console.WriteLine();
        }
    }
}
