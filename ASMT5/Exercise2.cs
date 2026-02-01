namespace Exercise2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter the radius of Circle A (ra):");
            double ra = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please Enter the central coordinate(xa,ya)");
            double xa = Convert.ToDouble(Console.ReadLine());
            double ya = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please Enter the radius of Circle B (rb):");
            double rb = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please Enter the central coordinate(xb,yb)");
            double xb = Convert.ToDouble(Console.ReadLine());
            double yb = Convert.ToDouble(Console.ReadLine());
            double distance = Math.Sqrt(Math.Pow((xb - xa), 2) + Math.Pow((yb - ya), 2));
            if (distance + rb < ra)
            {
                Console.WriteLine("Circle B is inside Circle A");
            }
            else if (distance + ra < rb)
            {
                Console.WriteLine("Circle A is inside Circle B");

            }
            else if (Math.Abs(ra-rb)<=distance && distance<=ra+rb)
            {
                Console.WriteLine("Circle A and Circle B are intersecting");
            }
            else
            {
                Console.WriteLine("Circle A and Circle B are not intersecting");
            }
        }
    }
}
