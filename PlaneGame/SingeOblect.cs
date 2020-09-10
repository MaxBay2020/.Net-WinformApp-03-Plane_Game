using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneGame
{
    class SingeOblect
    {
        #region single instance
        private SingeOblect()
        {

        }

        private static SingeOblect _single = null;

        public static SingeOblect GetSingle()
        {
            if (_single == null)
            {
                _single = new SingeOblect();
            }
            return _single;
        }
        #endregion

        //store background objects
        public Background BG { get; set; }
        public Player Player { get; set; }

        //enemy plane list
        public List<Enemy> enemyList = new List<Enemy>();

        //player bullets
        private List<BulletPlayer> playerBulletList = new List<BulletPlayer>();

        //enemy bullets
        private List<BulletEnemy> enemyBulletList = new List<BulletEnemy>();

        //enemy explosion
        private List<EnemyExplosion> enemyExplosionList = new List<EnemyExplosion>();

        //player explosion
        private List<PlayerExplosion> playerExplosionList = new List<PlayerExplosion>();

        //stores
        public int Score { get; set; }

        //method: add game objects to scene;
        public void AddGameObjects(GameObject go)
        {
            if(go is Background)
            {
                //if go is Background object;
                this.BG = go as Background;
            }else if(go is Player)
            {
                //if go is Player object;
                this.Player = go as Player;
            }else if(go is Enemy)
            {
                this.enemyList.Add(go as Enemy);
            }else if(go is BulletPlayer)
            {
                this.playerBulletList.Add(go as BulletPlayer);
            }else if(go is BulletEnemy)
            {
                this.enemyBulletList.Add(go as BulletEnemy);
            }else if(go is EnemyExplosion)
            {
                this.enemyExplosionList.Add(go as EnemyExplosion);
            }else if(go is PlayerExplosion)
            {
                this.playerExplosionList.Add(go as PlayerExplosion);

                //score - 100
                Score -= 100;

                //score cannot be less than 0
                if (Score <= 0)
                {
                    Score = 0;
                }
            }
        }

        /// <summary>
        /// remove game object
        /// </summary>
        /// <param name="go"></param>
        public void RemoveGameObject(GameObject go)
        {
            if(go is Enemy)
            {
                //remove enemy plane from the list
                enemyList.Remove(go as Enemy);
            }else if(go is BulletPlayer)
            {
                //remove player bullet from the list
                playerBulletList.Remove(go as BulletPlayer);

            }else if(go is BulletEnemy)
            {
                //remove enemy bullet from the list

                enemyBulletList.Remove(go as BulletEnemy);
            }
            else if (go is EnemyExplosion)
            {
                this.enemyExplosionList.Remove(go as EnemyExplosion);
            }
            else if (go is PlayerExplosion)
            {
                this.playerExplosionList.Remove(go as PlayerExplosion);
            }
        }

        /// <summary>
        /// draw game objects on screen
        /// </summary>
        /// <param name="g"></param>
        public void DrawGameObject(Graphics g)
        {
            //draw game objects on window
            //background
            //this.BG.Draw(g);

            //player
            this.Player.Draw(g);

            //enemies
            for (int i = 0; i < enemyList.Count; i++)
            {
                enemyList[i].Draw(g);
            }

            //player bullet
            for (int i = 0; i < playerBulletList.Count; i++)
            {
                playerBulletList[i].Draw(g);
            }

            //enemy bullet
            for (int i = 0; i < enemyBulletList.Count; i++)
            {
                enemyBulletList[i].Draw(g);
            }

            //enemy explosion
            for (int i = 0; i < enemyExplosionList.Count; i++)
            {
                enemyExplosionList[i].Draw(g);
            }

            //player explosion
            for (int i = 0; i < playerExplosionList.Count; i++)
            {
                playerExplosionList[i].Draw(g);
            }
        }


        /// <summary>
        /// collision check
        /// </summary>
        public void Collision()
        {
            #region player bullet hit enemy
            for (int i = 0; i < playerBulletList.Count; i++)
            {
                for (int j = 0; j < enemyList.Count; j++)
                {
                    if (playerBulletList[i].GetRectangle().IntersectsWith(enemyList[j].GetRectangle()))
                    {
                        //player bullet hit enemy
                        //enemy life decrese
                        enemyList[j].Life -= playerBulletList[i].Power;

                        //whether enemy life is 0
                        if (enemyList[j].Life == 0)
                        {
                            CountScore(j);

                        }

                        enemyList[j].IsOver();

                        //remove player bullet
                        playerBulletList.Remove(playerBulletList[i]);
                        break;
                    }
                }
            }

            #endregion

            #region enemy bullet hit player
            for (int i = 0; i < enemyBulletList.Count; i++)
            {
                if (enemyBulletList[i].GetRectangle().IntersectsWith(this.Player.GetRectangle()))
                {
                    this.Player.IsOver();

                    //remove enemy bullet
                    enemyBulletList.Remove(enemyBulletList[i]);
                }
            }


            #endregion

            #region player hit enemy
            for (int i = 0; i < enemyList.Count; i++)
            {
                if (enemyList[i].GetRectangle().IntersectsWith(this.Player.GetRectangle()))
                {
                    enemyList[i].Life = 0;
                    //score up
                    CountScore(i);

                    enemyList[i].IsOver();
                    this.Player.IsOver();
                }
            }
            #endregion

            #region player bullet hit enemy bullet
            for (int i = 0; i < enemyBulletList.Count; i++)
            {
                for (int j = 0; j < playerBulletList.Count; j++)
                {
                    if (enemyBulletList[i].GetRectangle().IntersectsWith(playerBulletList[j].GetRectangle()))
                    {
                        //remove enemy bullet
                        this.enemyBulletList.Remove(enemyBulletList[i]);

                        //remove player bullet
                        this.playerBulletList.Remove(playerBulletList[j]);

                        break;
                    }
                }
            }
            #endregion
        }

        private void CountScore(int j)
        {
            //scores based on enemy type
            switch (enemyList[j].EnemyType)
            {
                case 1:
                    Score += 100;
                    break;
                case 2:
                    Score += 200;
                    break;
                case 3:
                    Score += 300;
                    break;
                default:
                    break;
            }
        }
    }
}
