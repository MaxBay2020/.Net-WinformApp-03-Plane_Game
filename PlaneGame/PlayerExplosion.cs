using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaneGame.Properties;

namespace PlaneGame
{
    class PlayerExplosion:Explosion
    {
        private Image[] imgsPlayer =
        {
            Resources.me_destroy_1,
            Resources.me_destroy_2,
            Resources.me_destroy_3,
            Resources.me_destroy_4
        };

        public PlayerExplosion(int x, int y) : base(x, y)
        {

        }

        public override void Draw(Graphics g)
        {
            for (int i = 0; i < imgsPlayer.Length; i++)
            {
                g.DrawImage(imgsPlayer[i], this.X, this.Y);
            }

            SingeOblect.GetSingle().RemoveGameObject(this);
        }

        public override void MoveToBorder()
        {
            throw new NotImplementedException();
        }
    }
}
