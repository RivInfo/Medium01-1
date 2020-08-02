using System;

namespace Task
{
    class Program
    {
        public static void Main()
        {
            Trajectory obg1 = new Trajectory(new Position(5,5), true);
            Trajectory obg2 = new Trajectory(new Position(10, 10), true);
            Trajectory obg3 = new Trajectory(new Position(15, 15), true);

            Position _obg1Pos = obg1.Position;
            Position _obg2Pos = obg2.Position;
            Position _obg3Pos = obg3.Position;

            Random random = new Random();

            while (true)
            {
                if (_obg1Pos.EqualsPosition(_obg2Pos))
                {
                    obg1.Isalive = false;
                    obg2.Isalive = false;
                }

                if (_obg1Pos.EqualsPosition(_obg3Pos))
                {
                    obg1.Isalive = false;
                    obg3.Isalive = false;
                }

                if (_obg2Pos.EqualsPosition(_obg3Pos))
                {
                    obg2.Isalive = false;
                    obg3.Isalive = false;
                }

                _obg1Pos.PlusAndPositiv(random.Next(-1, 1), random.Next(-1, 1));
                _obg2Pos.PlusAndPositiv(random.Next(-1, 1), random.Next(-1, 1));
                _obg3Pos.PlusAndPositiv(random.Next(-1, 1), random.Next(-1, 1));

                if (obg1.Isalive)
                {
                    obg1.SetCursor("1");
                }

                if (obg2.Isalive)
                {
                    obg2.SetCursor("2");
                }

                if (obg3.Isalive)
                {
                    obg3.SetCursor("3");
                }
            }
        }
    }

    class Position
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void PlusAndPositiv(int stepx, int stepy)
        {
            PlusStep(stepx, stepy);
            PositivePosition();
        }

        private void PlusStep(int stepx, int stepy)
        {
            X += stepx;
            Y += stepy;
        }

        private void PositivePosition()
        {
            if (X < 0)
                X = 0;

            if (Y < 0)
                Y = 0;
        }

        public bool EqualsPosition(Position other)
        {
            if (X == other.X && Y == other.Y)
                return true;
            else
                return false;
        }
    }

    class Trajectory
    {
        public Position Position { get; private set; }
        public bool Isalive { get; set; }

        public Trajectory(Position pos, bool isalive)
        {
            Position = pos;
            Isalive = isalive;
        }

        public void SetCursor(string Num)
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(Num);
        }
    }
}