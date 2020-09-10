using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlaneGame.Properties;

namespace PlaneGame
{
    /// <summary>
    /// player plane
    /// </summary>
    class Player : PlaneParent
    {

        private static Image imgPlayer = Resources.me1;

        public Player(int x, int y, int speed, int life, Direction dir)
            :base(x, y, imgPlayer, speed, life, dir)
        {

        }

        public override void Draw(Graphics g)
        {
            this.MoveToBorder();
            g.DrawImage(imgPlayer, this.X, this.Y, this.Width/2, this.Height/2);   
        }

        /// <summary>
        /// player fire
        /// </summary>
        public override void Fire()
        {
            SingeOblect.GetSingle().AddGameObjects(new BulletPlayer(this, 20, 1));
        }

        /// <summary>
        /// player die
        /// </summary>
        public override void IsOver()
        {
            SingeOblect.GetSingle().AddGameObjects(new PlayerExplosion(this.X, this.Y));
        }

        public void MouseDownLeft(MouseEventArgs e)
        {
            //left button down
            if (e.Button == MouseButtons.Left)
            {
                Fire();
            }
        }

        public override void MoveToBorder()
        {
            if (this.X <= 0)
            {
                this.X = 0;
            }

            if (this.Y <= 0)
            {
                this.Y = 0;
            }
            if (this.X >= (480-this.Width/2))
            {
                this.X = (480 - this.Width/2);
            }

            if (this.Y >= (850 - this.Height/2))
            {
                this.Y = (850 - this.Height/2);
            }
        }

        public void MoveWithMouse(MouseEventArgs e)
        {
            this.X = e.X-this.Width/4;
            this.Y = e.Y-this.Height/4;
        }
    }
}
