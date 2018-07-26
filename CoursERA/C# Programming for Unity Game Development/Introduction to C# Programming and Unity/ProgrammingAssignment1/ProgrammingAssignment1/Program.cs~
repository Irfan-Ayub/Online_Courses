using System;

namespace ProgrammingAssignment1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("========= Welcome to Greek Universe =========");

            Console.WriteLine("Enter First x value : ");
            float point1X = float.Parse(Console.ReadLine());

            Console.WriteLine("Enter First y value : ");
            float point1Y = float.Parse(Console.ReadLine());

            Console.WriteLine("Enter Second x value : ");
            float point2X = float.Parse(Console.ReadLine());

            Console.WriteLine("Enter Second y value : ");
            float point2Y = float.Parse(Console.ReadLine());

            float deltaX = point1X - point2X;
            float deltaY = point1Y - point2Y;

            float distance = (float)(Math.Sqrt((Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2))));
            Console.WriteLine("Distance between the two points :" + distance);

            double angle = Math.Atan2(point1Y , point1X);

//            Console.WriteLine("Angle you have to move in " + angle);
            angle = angle * (180 / Math.PI);
            angle -= 180;

            Console.WriteLine("Angle you have to move in " + angle);

        }
    }
}
