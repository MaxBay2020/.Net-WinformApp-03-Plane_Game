using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneGame
{
    class BulletParent:GameObject
    {
        private Image imgBullet;
        public int Power { get; set; }


        public BulletParent(PlaneParent pp, int power, Image img, int x, int y, int speed) 
            : base(x,y,img.Width, img.Height, speed,0,pp.Dir)
        {
            this.imgBullet = img;
            this.Power = power;
        }

        public override void Draw(Graphics g)
        {
            base.Move();
            g.DrawImage(imgBullet, this.X, this.Y);
        }

        public override void MoveToBorder()
        {
            if(this.Y<=0|| this.Y >= 850)
            {
                //remove bullet object
                SingeOblect.GetSingle().RemoveGameObject(this);
            }
        }
    }
}
