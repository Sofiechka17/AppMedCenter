namespace ConsoleApp19
    {
        internal class Sphere
        {
            public double volume; // объем
            public double radius; // радиус
            public double x; // координаты в декартовой системе
            public double y;
            public double z;

            public Sphere(double volume, double radius, double x, double y, double z)  // конструктор
            {
                this.volume = volume;
                this.radius = radius;
                this.x = x;
                this.y = y;
                this.z = z;


            }
            public double Volume()
            {
                return volume;
            }

            public double Radius()
            {
                return radius;
            }

            public static bool operator <(Sphere s1, Sphere s2)
            {
                return s1.Volume() < s2.Volume();
            }
            public static bool operator >(Sphere s1, Sphere s2)
            {
                return s1.Volume() < s2.Volume();
            }

        }
    }