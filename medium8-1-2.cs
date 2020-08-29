using System;

namespace Task
{
    class Program
    {
        public static void Main()
        {
            Random random = new Random();

            RandomPath[] objs = new RandomPath[] 
            { 
                new RandomPath(5, 5, random, "1"),
                new RandomPath(10, 10, random, "2"),
                new RandomPath(15, 15, random, "3")
            };

            while (true)
            {
                for (int i = 0; i < objs.Length - 1; i++)
                {
                    for (int j = i + 1; j < objs.Length; j++)
                    {
                        if (objs[i].EqualsPosition(objs[j]))
                        {
                            objs[i].Die();
                            objs[j].Die();
                        }
                    }
                }

                foreach (var o in objs)
                {
                    o.RandomStepPosition();
                    o.MinPositionValue();
                    if (o.IsAlive)
                    {
                        Console.SetCursorPosition(o.X, o.Y);
                        Console.Write(o.Text);
                    }
                }
            }
        }
    }

    class RandomPath
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public bool IsAlive { get; private set; }
        public string Text { get; private set; }

        private Random _random;

        public RandomPath(int x, int y, Random random, string text, bool isAlive = true)
        {
            X = x;
            Y = y;
            _random = random;
            IsAlive = isAlive;
            Text = text;
        }

        public bool EqualsPosition(RandomPath position)
        {
            if (position.X == X && position.Y == Y)
                return true;
            else
                return false;
        }

        public void Die()
        {
            IsAlive = false;
        }

        public void RandomStepPosition()
        {
            X += _random.Next(-1, 1);
            Y += _random.Next(-1, 1);
        }

        public void MinPositionValue()
        {
            if (X < 0)
                X = 0;
            if (Y < 0)
                Y = 0;
        }
    }
}