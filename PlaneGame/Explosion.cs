using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneGame
{
    abstract class Explosion:GameObject
    {
        public Explosion(int x, int y)
            :base(x, y)
        {

        }
    }
}
