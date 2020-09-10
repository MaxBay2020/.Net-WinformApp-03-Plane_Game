using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneGame
{
    enum Direction
    {
        Up,
        Down,
        Right,
        Left
    }
    abstract class GameObject
    {
        #region properties
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Speed { get; set; }
        public int Life { get; set; }
        public Direction Dir { get; set; }
        #endregion

        #region constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="life"></param>
        /// <param name="dir"></param>
        public GameObject(int x, int y, int width, int height,int speed, int life, Direction dir)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.Speed = speed;
            this.Life = life;
            this.Dir = dir;
        }

        public GameObject(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        #endregion

        #region Methods
        //game object movement method
        public virtual void Move()
        {
            switch (this.Dir)
            {
                case Direction.Up:
                    this.Y -= this.Speed;
                    break;
                case Direction.Down:
                    this.Y += this.Speed;
                    break;
                case Direction.Right:
                    this.X += this.Speed;
                    break;
                case Direction.Left:
                    this.X -= this.Speed;
                    break;
                default:
                    break;
            }
        }

        //game object drawing
        public abstract void Draw(Graphics g);

        //when game object moves to border
        public abstract void MoveToBorder();

        //get game object rectangle for collision check
        public Rectangle GetRectangle()
        {
            return new Rectangle(this.X, this.Y, this.Width, this.Height);
        }
        #endregion
    }
}
