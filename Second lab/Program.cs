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
			return 2 * Math.PI* Radius();
		}
        
        public new void Print()
        {
            if (is_circle) 
                Console.WriteLine("Радиус окружности R = {0:0.##}. Диаметр окружности C = {1:0.##}", Radius(), Diametr());
            else 
                Console.WriteLine("Точки не образуют окружность.");
        }
    }
	
	public class Fly
	{
		public string name;
		public Fly(string Name)
		{
			this.name = Name;
		}
	}
	
	public class BigFly : Fly 
	{
		public string type_dvig;
		public string type_corp;
		public int dlina;
		
		public BigFly(string Name,string Dvigatel, string Salon, int Dlina) : base(Name)
		{
			this.type_dvig = Dvigatel;
			this.type_corp = Salon;
			this.dlina = Dlina;
		}
		
		public void print()
		{
			Console.WriteLine("Название самолета: {0}\nТип двигателя: {1}\nТип салона: {2}\nДальность полета: {3} км/ч.", name, type_dvig, type_dvig, dlina);
		}
	}
	
	public class Deltaplan : Fly
	{
		public string model;
		public string construktor;
		
		public Deltaplan(string Name, string Model, string Constructor): base(Name)
		{
			
			this.model = Model;
			this.construktor = Constructor;
		}
		
		public void print()
		{
			Console.WriteLine("Название сдельтаплана: {0}\nМодель: {1}\nКонструктор: {2}", name, model, construktor);
		}
	}
	
	public class CosmoStar : Fly
	{
		public string type_cor;
		public double weight;
		
		public CosmoStar(string Name, string Corpus, double Weight) : base(Name)
		{
			this.type_cor = Corpus;
			this.weight = Weight;
		}
		
		public void print()
		{
			Console.WriteLine("Навзвание космического аппарата: {0}\nТип корпуса: {1}\nВес: {2}", name, type_cor, weight);
		}
	}
	
    class Program
    {
        static void Main(string[] args)
        {
			/*
			 *  Point p = new Point(2, 3);
			 *  p.Print();
			 *  
			 *  Segment sm = new Segment(2,3, 8, 10)
			 *  sm.Print();
			 * 
			 *	Circle sm = new Circle(-6, 3, -3, 2, 0, 3);
			 *	sm.Print();
			*/
			 
			BigFly bf = new BigFly("Туполев Ту-154", "Реактивный", "пассажирский ", 3800);
			Deltaplan delta = new Deltaplan("Target", "Cross-Country", "AEROS");
			CosmoStar cs = new CosmoStar("Восход", "орбитальный", 177.5);
			Deltaplan delta_1 = new Deltaplan("Stealth Combat GT 12,4", "Cross-Country", "AEROS");
			BigFly bf_1 = new BigFly("Туполев Ту-134", "Реактивный", "пассажирский ", 5100);
			
			Fly[] fl = new Fly[]
			{
				bf,
				delta,
				cs,
				delta_1,
				bf_1
			};
			
			for(int i = 0; i < fl.Length; i++)
			{
				Console.WriteLine("#{0} название летательного аппарата: {1}", i+1, fl[i].name);
			}
			
			Console.WriteLine();
			
			bf.print();
			delta.print();
			cs.print();
			delta_1.print();
			bf_1.print();
			
            Console.ReadKey();
        }
    }
}
