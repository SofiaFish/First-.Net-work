using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.ComponentModel;
//using System.Threading.Tasks;

namespace ConsoleApp5
{
    public partial class Form1 : Form
    {
        GameLogic logic;
        Timer invalidate = new Timer();


        public Form1()
        {
            InitializeComponent();
            logic = new GameLogic(Background.Size.Width, Background.Size.Height);
            logic.StartGame();
            invalidate.Tick += (x, y) => this.Invalidate(true);
            invalidate.Interval = 100;
            invalidate.Start();


        }


        private void Graphics(object sender, PaintEventArgs e)
        {
            Graphics background = e.Graphics;

            background.FillEllipse(Brushes.Coral, logic.Snake[0].pos_x, logic.Snake[0].pos_y, Settings.Width, Settings.Height);
            for (int i = 1; i < logic.Snake.Count; i++)
            {
                background.FillEllipse(Brushes.DarkRed, new Rectangle(logic.Snake[i].pos_x, logic.Snake[i].pos_y, Settings.Width, Settings.Height));
            }
            background.FillEllipse(Brushes.Yellow, new Rectangle(logic.food.pos_x, logic.food.pos_y, Settings.Width, Settings.Height));
        }

        //        public void Screen(object sender, EventArgs e)
        //        {
        //            if (Settings.GameOwer == true)
        //            {
        //                if (Input.Press(Keys.Enter))
        //                    logic.StartGame();
        //            }
        //            else
        //            {
        //                if (Input.Press(Keys.Right))
        //                    Settings.direction = Direction.right;
        //                if (Input.Press(Keys.Left))
        //                    Settings.direction = Direction.left;
        //                if (Input.Press(Keys.Up))
        //                    Settings.direction = Direction.up;
        //                if (Input.Press(Keys.Down))
        //                    Settings.direction = Direction.down;
        //#warning нельзя привязывать передвижение к скорости обновления экрана
        //                logic.Move();
        //            }

        //        }

        public void keydown(object sender, KeyEventArgs e)
        {
        //    Input.ChangeState(e.KeyCode, true);
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    logic.StartGame();
                    break;
                case Keys.Left:
                    Settings.direction = Direction.left;
                    break;
                case Keys.Up:
                    Settings.direction = Direction.up;
                    break;
                case Keys.Right:
                    Settings.direction = Direction.right;
                    break;
                case Keys.Down:
                    Settings.direction = Direction.down;
                    break;
            }
        }

    }
}
