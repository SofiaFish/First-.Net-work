using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ConsoleApp5
{
    public enum Direction
    {
        up,down,left,right
    }
    class Settings
    {
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static int Speed { get; set; }
        public static int Score { get; set; }
        public static int Points { get; set; }
        public static bool GameOwer { get; set; }
        public static Direction direction { get; set; }

        

        

        static Settings()
        {
            Width = 16;
            Height = 16;
            Speed = 20;
            Score = 0;
            Points = 100;
            GameOwer = false;
            direction = Direction.down;
        }



    }

    
}
