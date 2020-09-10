using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaneGame.Properties;

namespace PlaneGame
{
    class BulletEnemy : BulletParent
    {
        private static Image imgPlayerBullet = Resources.bullet2;

        //enemy plane description
        public int Type { get; set; }

        public BulletEnemy(PlaneParent pp, int type)
            : base(pp, GetPowerWithType(type), imgPlayerBullet, pp.X + pp.Width / 2, pp.Y + pp.Height, GetBulletSpeedWithType(type))
        {
            this.Type = type;
        }


        /// <summary>
        ///  based on the type of plane, return different bullet power
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int GetPowerWithType(int type)
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
        ///  based on the type of plane, return different bullet speed
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int GetBulletSpeedWithType(int type)
        {
            switch (type)
            {
                case 1:
                    return 20;
                case 2:
                    return 10;
                case 3:
                    return 5;
                default:
                    break;
            }
            return 0;
        }
    }
}
