using System;

namespace Task
{
    class Program
    {
        public static void Main()
        {
            Trajectory obg1 = new Trajectory(5, 5, true);
            Trajectory obg2 = new Trajectory(10, 10, true);
            Trajectory obg3 = new Trajectory(15, 15, true);

            Random random = new Random();

            while (true)
            {
                if (obg1.EqualsTrajectory(obg2))
                {
                    obg1.Isalive = false;
                    obg2.Isalive = false;
                }

                if (obg1.EqualsTrajectory(obg3))
                {
                    obg1.Isalive = false;
                    obg3.Isalive = false;
                }

                if (obg2.EqualsTrajectory(obg3))
                {
                    obg2.Isalive = false;
                    obg3.Isalive = false;
                }

                obg1.PlusStep(random.Next(-1, 1), random.Next(-1, 1));
                obg2.PlusStep(random.Next(-1, 1), random.Next(-1, 1));
                obg3.PlusStep(random.Next(-1, 1), random.Next(-1, 1));

                obg1.PositivePosition();
                obg2.PositivePosition();
                obg3.PositivePosition();

                if (obg1.Isalive)
                {
                    Console.SetCursorPosition(obg1.X, obg1.Y);
                    Console.Write("1");
                }

                if (obg2.Isalive)
                {
                    Console.SetCursorPosition(obg2.X, obg2.Y);
                    Console.Write("2");
                }

                if (obg3.Isalive)
                {
                    Console.SetCursorPosition(obg3.X, obg3.Y);
                    Console.Write("3");
                }
            }
        }
    }

    class Trajectory
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public bool Isalive { get; set; }

        public Trajectory(int x, int y, bool isalive)
        {
            X = x;
            Y = y;
            Isalive = isalive;
        }

        public void PlusStep(int stepx, int stepy)
        {
            X += stepx;
            Y += stepy;
        }

        public void PositivePosition()
        {
            if (X < 0)
                X = 0;

            if (Y < 0)
                Y = 0;
        }

        public bool EqualsTrajectory(Trajectory other)
        {
            if (X == other.X && Y == other.Y)
                return true;
            else
                return false;
        }
    }
}