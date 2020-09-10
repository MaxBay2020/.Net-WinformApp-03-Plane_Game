using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaneGame.Properties;

namespace PlaneGame
{
    class EnemyExplosion : Explosion
    {
        public int Type { get; set; }

        private Image[] imgsSmall =
        {
            Resources.enemy1_down1,
            Resources.enemy1_down2,
            Resources.enemy1_down3,
            Resources.enemy1_down4,
        };

        private Image[] imgsMeidum =
        {
            Resources.enemy2_down1,
            Resources.enemy2_down2,
            Resources.enemy2_down3,
            Resources.enemy2_down4,
        };

        private Image[] imgsBig =
        {
            Resources.enemy3_down1,
            Resources.enemy3_down2,
            Resources.enemy3_down3,
            Resources.enemy3_down4,
            Resources.enemy3_down5,
            Resources.enemy3_down6,
        };

        public EnemyExplosion(int x, int y, int type)
            :base(x,y)
        {
            this.Type = type;
        }

        public override void Draw(Graphics g)
        {
            switch (this.Type)
            {
                case 1:
                    for (int i = 0; i < imgsSmall.Length; i++)
                    {
                        g.DrawImage(imgsSmall[i], this.X, this.Y);
                    }
                    break;
                case 2:
                    for (int i = 0; i < imgsMeidum.Length; i++)
                    {
                        g.DrawImage(imgsMeidum[i], this.X, this.Y);
                    }
                    break;
                case 3:
                    for (int i = 0; i < imgsBig.Length; i++)
                    {
                        g.DrawImage(imgsBig[i], this.X, this.Y);
                    }
                    break;
                default:
                    break;
            }

            //after playing images, remove images from the scene
            SingeOblect.GetSingle().RemoveGameObject(this);
        }

        /// <summary>
        /// no use
        /// </summary>
        public override void MoveToBorder()
        {
            throw new NotImplementedException();
        }
    }
}
