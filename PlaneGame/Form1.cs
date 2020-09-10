using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlaneGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random r = new Random();
        /// <summary>
        /// initialize game
        /// </summary>
        private void InitialGame()
        {
            //initialize Background object
            SingeOblect.GetSingle().AddGameObjects(new Background(0, -850, 20));

            //initialize Player object
            SingeOblect.GetSingle().AddGameObjects(new Player(200, 200, 20, 1, Direction.Up));
            
            //initialize enemy object
            InitializeEnemyPlane();

        }
        /// <summary>
        /// initialize enemy plane
        /// </summary>
        private void InitializeEnemyPlane()
        {
            for (int i = 0; i < 4; i++)
            {
                SingeOblect.GetSingle().AddGameObjects(new Enemy(r.Next(0, this.Width), -200, r.Next(1, 3)));
            }

            //10% boss plan appears
            if (r.Next(1, 101) > 90)
            {
                SingeOblect.GetSingle().AddGameObjects(new Enemy(r.Next(0, this.Width), -200, 3));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitialGame();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        //whether the game starts
        bool isStart = false;

        //save play time
        int playTime = 0;

        //save client score
        string result = "";

        //whether the game is over
        bool isGameOver = false;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //draw background
            SingeOblect.GetSingle().BG.Draw(e.Graphics);

            if (isStart)
            {
                //draw other game objects
                SingeOblect.GetSingle().DrawGameObject(e.Graphics);

                //draw score
                String score = SingeOblect.GetSingle().Score.ToString();
                e.Graphics.DrawString(score, new Font("微软雅黑", 20, FontStyle.Bold), Brushes.Red, new Point(10, 10));

            }

            if (isGameOver)
            {
                //draw result
                e.Graphics.DrawString(result, new Font("微软雅黑", 20, FontStyle.Bold), Brushes.Red, new Point(100, this.Height / 2 - 100));
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //window continue redraw
            this.Invalidate();

            //check the number of enemy plane
            if (SingeOblect.GetSingle().enemyList.Count < 2)
            {
                //re-initialize enemy
                InitializeEnemyPlane();
            }

            //collision check
            SingeOblect.GetSingle().Collision();
        }

        /// <summary>
        /// give the x and y of cursor to x and y of player
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            SingeOblect.GetSingle().Player.MoveWithMouse(e);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //player shoot
            SingeOblect.GetSingle().Player.MouseDownLeft(e);
        }

        Socket socket;
        /// <summary>
        /// client enter game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_getready_Click(object sender, EventArgs e)
        {
            //create connecting socket
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //get server ip
            IPAddress ip = IPAddress.Parse(txt_ip.Text);

            //get server app port
            IPEndPoint port = new IPEndPoint(ip, int.Parse(txt_port.Text));

            try
            {
                //connect to server
                socket.Connect(port);
            }
            catch (Exception)
            {
                return;
            }

            //accept info from server
            Thread th = new Thread(Rec);
            th.IsBackground = true;
            th.Start();

            //cannot click
            txt_getready.Enabled = false;

        }

        /// <summary>
        /// receive message from server
        /// </summary>
        public void Rec()
        {
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[1024 * 1024 * 5];

                    int r = socket.Receive(buffer);

                    if (buffer[0] == 1)
                    {
                        //it is start game info, game start
                        isStart = true;

                        //hide tools
                        txt_ip.Visible = false;
                        txt_port.Visible = false;
                        txt_getready.Visible = false;
                        lb_ip.Visible = false;
                        lb_port.Visible = false;

                    }
                    else if (buffer[0] == 2)
                    {
                        //it is result info
                        //get result from server
                        //result = Encoding.Default.GetString(buffer, 0, r);
                        result = Encoding.Default.GetString(buffer, 0, r);

                        //draw result in Paint event
                        isGameOver = true;
                    }
                }
            }
            catch (Exception)
            {

            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (isStart)
            {
                //if game starts
                playTime++;
                if (playTime == 20)
                {
                    //time end, stop game
                    isStart = false;

                    //send result to server
                    //transfer score to byte, send to server
                    byte[] buffer = Encoding.Default.GetBytes(SingeOblect.GetSingle().Score.ToString());

                    socket.Send(buffer);
                }
            }
        }
    }
}
