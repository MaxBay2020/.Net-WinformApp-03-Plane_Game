using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaneGame.Properties;

namespace PlaneGame
{
    class BulletPlayer:BulletParent
    {
        private static Image imgPlayerBullet = Resources.bullet1;
        public BulletPlayer(PlaneParent pp, int speed, int power)
            :base(pp,power, imgPlayerBullet, pp.X + pp.Width / 4, pp.Y, speed)
        {

        }
        
    }
}
