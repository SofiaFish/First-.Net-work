using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp5
{
    class GameLogic
    {
        const int MOVE_SIZE = 5;
        Timer t = new Timer();
        public List<Coordinate> Snake = new List<Coordinate>();
        public Coordinate food = new Coordinate();
        public int max_pos_x;
        public int max_pos_y;
        Random rand = new Random();



        public GameLogic(int width, int height)
        {
            max_pos_x = width;
            max_pos_y = height;
            t.Interval = 50;
            t.Tick += (ob, args) => Move();
            t.Start();
        }



        public void Move()
        {
            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Settings.direction)
                    {
                        case Direction.up:
                            Snake[i].pos_y-= MOVE_SIZE;
                            break;
                        case Direction.down:
                            Snake[i].pos_y += MOVE_SIZE;
                            break;
                        case Direction.left:
                            Snake[i].pos_x -= MOVE_SIZE;
                            break;
                        case Direction.right:
                            Snake[i].pos_x += MOVE_SIZE;
                            break;
                        default:
                            break;
                    }
                }

                //int max_pos_x = Background.Size.Width;
                //int max_pos_y = Background.Size.Height;

                if (Snake[i].pos_x < 0 || Snake[i].pos_y < 0 || Snake[i].pos_x > max_pos_x || Snake[i].pos_y > max_pos_y)
                    Die();

                for (int j = 1; j < Snake.Count; j++)
                {
                    if (Snake[i].pos_x == Snake[j].pos_x || Snake[i].pos_y == Snake[j].pos_y)
                        Die();
                }

                if (Snake[i].pos_x >= food.pos_x- Settings.Width && Snake[i].pos_x <= food.pos_x + Settings.Width
                    && Snake[i].pos_y >= food.pos_y - Settings.Height && Snake[i].pos_y <= food.pos_y + Settings.Height)
                    Eat();
                else
                {
                    Snake[i].pos_x = Snake[i].pos_x;
                    Snake[i].pos_y = Snake[i].pos_y;
                }
            }
        }

        public void Die()
        {
            Settings.GameOwer = true;
        }
        public void Eat()
        {
            Coordinate body = new Coordinate
            {
                pos_x = Snake[Snake.Count - 1].pos_x,
                pos_y = Snake[Snake.Count - 1].pos_y
            };
            Snake.Add(body);
            Settings.Score += Settings.Points;
            GenerateFood();
        }

        public void GenerateFood()
        {
            food = new Coordinate
            {
                pos_x = rand.Next(0, max_pos_x),
                pos_y = rand.Next(0, max_pos_y)
            };
        }
        public void StartGame(int startX = 150, int startY = 50)
        {
            // Form1.label1.Visible = false;
            //   new Settings();
            Snake.Clear();
            Coordinate head = new Coordinate { pos_x = startX, pos_y = startY };
            Snake.Add(head);
            GenerateFood();

        }
    }
}
