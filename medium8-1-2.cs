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
                                objs[i].SetRenderEneble(false);
                                objs[j].SetRenderEneble(false);
                            }
                        }
                    }
                }

                foreach (var o in objs)
                {
                    Move(o, random);
                    if (o.Render.Eneble)
                        o.Render.Render();
                }
            }
        }

        public static void Move(GameObject go, Random random)
        {
            int _x = go.Position.X + random.Next(-1, 1);
            int _y = go.Position.Y + random.Next(-1, 1);

            if (_x < 0)
                _x = 0;
            if (_y < 0)
                _y = 0;
            go.Translate(_x, _y);
        }
    }

    class GameObject
    {
        public Position Position { get; private set; }
        public Renderer Render { get; }

        public GameObject(Position position, Renderer render)
        {
            Position = position;
            Render = render;
            Render.SetPosition(position);
        }

        public void SetRenderEneble(bool eneble)
        {
            Render.Eneble = eneble;
        }

        public void Translate(int x, int y)
        {
            Position = new Position(x, y);
            Render.SetPosition(Position);
        }
    }

    struct Position
    {
        public int X;
        public int Y;

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
    }

    class Renderer
    {
        public bool Eneble;
        public string RenderObject { get; private set; }

        private Position _position;

        public Renderer(bool eneble, string text)
        {
            Eneble = eneble;
            RenderObject = text;
        }

        public void Render()
        {
            Console.SetCursorPosition(_position.X, _position.Y);
            Console.Write(RenderObject);
        }

        internal void SetPosition(Position position)
        {
            _position = position;
        }
    }
}