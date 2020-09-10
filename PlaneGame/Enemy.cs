using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaneGame.Properties;

namespace PlaneGame
{
    /// <summary>
    /// enemy planes
    /// </summary>
    class Enemy : PlaneParent
    {
        private static Image img1 = Resources.enemy1;
        private static Image img2 = Resources.enemy2;
        private static Image img3 = Resources.enemy3_n1;
        public int EnemyType { get; set; }


        public Enemy(int x, int y, int type) 
            : base(x, y, GetImageWithType(type), GetSpeedWithType(type), GetLifeWithType(type), Direction.Down)
        {
            this.EnemyType = type;
        }



        /// <summary>
        /// based on the type of plane, return different image
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Image GetImageWithType(int type)
        {
            switch (type)
            {
                case 1:
                    return img1;
                case 2:
                    return img2;
                case 3:
                    return img3;
                default:
                    break;
            }
            return null;
        }

        /// <summary>
        /// based on the type of plane, return different life
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int GetLifeWithType(int type)
        {
            switch (type)
            {
                case 1:
                    return 1;
                case 2:
                    return 2;
                case 3:
                    return 3;
                default:
                    break;
            }
            return 0;
        }

        /// <summary>
        /// based on the type of plane, return different speed
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int GetSpeedWithType(int type)
        {
            switch (type)
            {
                case 1:
                    return 10;
                case 2:
                    return 8;
                case 3:
                    return 4;
                default:
                    break;
            }
            return 0;
        }


        /// <summary>
        /// draw on screen
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            //enemy move
            base.Move();

            MoveToBorder();

            //based on plane type, draw enemy plane
            switch (this.EnemyType)
            {
                case 1:
                    g.DrawImage(img1, this.X, this.Y);
                    break;
                case 2:
                    g.DrawImage(img2, this.X, this.Y);
                    break;
                case 3:
                    g.DrawImage(img3, this.X, this.Y);
                    break;
                default:
                    break;
            }

            //odd to shoot
            if (r.Next(1, 101) > 95)
            {
                //enemy fire
                Fire();
            }
        }

        Random r = new Random();
        /// <summary>
        /// border collision detect
        /// </summary>
        public override void MoveToBorder()
        {
            if (this.Y >= 900)
            {
                //remove enemy game object;
                SingeOblect.GetSingle().RemoveGameObject(this);
            }
            //if small plane's y >= 200
            if (this.EnemyType == 1 && this.Y>=200)
            {
                //small is on the left
                if(this.X>=0 && this.X <= 240)
                {
                    this.X += r.Next(0, 50);
                }
                else
                {
                    //small is on the right
                    this.X -= r.Next(0, 50);
                }
            }else
            {
                //medium and big plan accelerate
                this.Speed+=1;
            }
        }

        /// <summary>
        /// enemy fire
        /// </summary>
        public override void Fire()
        {
            SingeOblect.GetSingle().AddGameObjects(new BulletEnemy(this, this.EnemyType));
        }

        /// <summary>
        /// enemy die
        /// </summary>
        public override void IsOver()
        {
            if (this.Life <= 0)
            {
                //explosion effect
                SingeOblect.GetSingle().AddGameObjects(new EnemyExplosion(this.X, this.X, this.EnemyType));

                //remove enemy plane
                SingeOblect.GetSingle().RemoveGameObject(this);

            }
        }
    }
}
