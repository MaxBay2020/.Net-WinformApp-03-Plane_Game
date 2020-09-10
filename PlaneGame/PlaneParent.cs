using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneGame
{
    abstract class PlaneParent:GameObject
    {
        private Image imgPlane;
        public PlaneParent(int x, int y, Image img, int speed, int life, Direction dir)
            :base(x, y, img.Width, img.Height, speed, life, dir)
        {
            this.imgPlane = img;
        }

        public abstract void Fire();

        //whether the plane is dead
        public abstract void IsOver();
    }
}
