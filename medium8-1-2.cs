using System;

namespace Task
{
    class Program
    {
        public static void Main()
        {
            Random random = new Random();

            Trajectory obg1 = new Trajectory(5, 5, random, true, "1");
            Trajectory obg2 = new Trajectory(10, 10, random, true, "2");
            Trajectory obg3 = new Trajectory(15, 15, random, true, "3");

            while (true)
            {
                obg1.EqualsPosition(obg2);
                obg1.EqualsPosition(obg3);
                obg2.EqualsPosition(obg3);

                obg1.RandomStepPositionAndPositiv();
                obg2.RandomStepPositionAndPositiv();
                obg3.RandomStepPositionAndPositiv();

                obg1.WriteAliveTextInPosition();
                obg2.WriteAliveTextInPosition();
                obg3.WriteAliveTextInPosition();
            }
        }
    }

    class Trajectory
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public bool IsAlive { get; private set; }
        public string Text { get; private set; }

        private Random _random;

        public Trajectory(int x, int y, Random random, bool isAlive, string text)
        {
            X = x;
            Y = y;
            _random = random;
            IsAlive = isAlive;
            Text = text;
        }

        public void EqualsPosition(Trajectory trajectory)
        {
            if (trajectory.X == X && trajectory.Y == Y)
            {
                trajectory.Die();
                Die();
            }
        }

        public void Die()
        {
            IsAlive = false;
        }

        public void RandomStepPositionAndPositiv()
        {
            X += _random.Next(-1, 1);
            Y += _random.Next(-1, 1);
            if (X < 0)
                X = 0;
            if (Y < 0)
                Y = 0;
        }

        public void WriteAliveTextInPosition()
        {
            if (IsAlive)
            {
                Console.SetCursorPosition(X, Y);
                Console.Write(Text);
            }
        }
    }
}