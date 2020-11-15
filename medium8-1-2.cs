using System;

namespace Task
{
    class Program
    {
        public static void Main()
        {
            Random random = new Random();

            GameObject[] objs = new GameObject[]
            {
                new GameObject(new Position(5, 5), new Renderer(true, "1")),
                new GameObject(new Position(10, 10), new Renderer(true, "2")),
                new GameObject(new Position(15, 15), new Renderer(true, "3"))
            };

            while (true)
            {
                if (objs.Length >= 2)
                {
                    for (int i = 0; i < objs.Length - 1; i++)
                    {
                        for (int j = i + 1; j < objs.Length; j++)
                        {
                            if (Position.IntersectPosition(objs[i].Position, objs[j].Position))
                            {
                                objs[i].Render.Eneble = false;
                                objs[j].Render.Eneble = false;
                            }
                        }
                    }
                }

                foreach (var o in objs)
                {
                    Move(o.Position, random);
                    if (o.Render.Eneble)
                        o.Render.Render();
                }
            }
        }

        public static void Move(Position position, Random random)
        {
            position.X += random.Next(-1, 1);
            position.Y += random.Next(-1, 1);

            if (position.X < 0)
                position.X = 0;
            if (position.Y < 0)
                position.Y = 0;
        }
    }

    class GameObject
    {
        public Position Position { get; }
        public Renderer Render { get; }

        public GameObject(Position position, Renderer render)
        {
            Position = position;
            Render = render;
            Position.SetGameObject(this);
            Render.SetGameObject(this);
        }
    }

    class Position
    {
        public int X;
        public int Y;

        public GameObject _gameObject;

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static bool IntersectPosition(Position position1, Position position2)
        {
            if (position1.X == position2.X && position1.Y == position2.Y)
                return true;
            else
                return false;
        }

        internal void SetGameObject(GameObject gameObject)
        {
            if (gameObject != null && gameObject.Position.Equals(this))
                _gameObject = gameObject;
        }
    }

    class Renderer
    {
        public bool Eneble;
        public string Text { get; private set; }

        private GameObject _gameObject;

        public Renderer(bool eneble, string text)
        {
            Eneble = eneble;
            Text = text;
        }

        public void Render()
        {
            Console.SetCursorPosition(_gameObject.Position.X, _gameObject.Position.Y);
            Console.Write(Text);
        }

        internal void SetGameObject(GameObject gameObject)
        {
            if (gameObject != null && gameObject.Render.Equals(this))
                _gameObject = gameObject;
        }
    }
}