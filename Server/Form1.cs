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

namespace Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txt_getready_Click(object sender, EventArgs e)
        {
            //create a socket listener
            Socket socketListener = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);

            //set ip and port
            IPAddress ip = IPAddress.Parse(txt_ip.Text);
            IPEndPoint port = new IPEndPoint(ip, int.Parse(txt_port.Text));

            //start listening
            socketListener.Bind(port);

            //set listening queue
            socketListener.Listen(10);

            //show message
            ShowMsg("Waiting for clients to enter...");

            //thread call
            Thread th = new Thread(Listen);
            th.IsBackground = true;
            th.Start(socketListener);
        }

        //save client ip and communicating socket
        Dictionary<string, Socket> dicSocket = new Dictionary<string, Socket>();

        //save client ip and score
        Dictionary<string, int> dicScore = new Dictionary<string, int>();

        /// <summary>
        /// receive client connection
        /// </summary>
        /// <param name="o"></param>
        public void Listen(Object o)
        {
            Socket socketListener = o as Socket;

            try
            {
                while (true)
                {
                    //socket listener accept connection of client, return communicating socket
                    Socket socketSend = socketListener.Accept();

                    //save client ip and its connecting socket into dictionary
                    dicSocket.Add(socketSend.RemoteEndPoint.ToString(), socketSend);

                    //get client ip and port, show msg on textbox;
                    ShowMsg(socketSend.RemoteEndPoint.ToString() + " enters game!");

                    //receive client msg
                    Thread th2 = new Thread(Rec);
                    th2.IsBackground = true;
                    th2.Start(socketSend);

                }
            }
            catch (Exception)
            {

                
            }


        }

        //receive msg from client
        public void Rec(Object o)
        {
            Socket socketSend = o as Socket;
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[1024 * 1024 * 5];

                    int r = socketSend.Receive(buffer);

                    //turn score byte to string
                    string scoreStr = Encoding.Default.GetString(buffer, 0, r);

                    int score = Convert.ToInt32(scoreStr);

                    //add score into dicScore
                    dicScore.Add(socketSend.RemoteEndPoint.ToString(), score);

                    //descend for dicScore
                    Compare();
                }
            }
            catch (Exception)
            {

                
            }
        }

        public void Compare()
        {
            //descend for dicScore
            List<KeyValuePair<string, int>> list = dicScore.OrderByDescending(n => n.Value).ToList();

            //send result to each client
            for (int i = 0; i < list.Count; i++)
            {
                string result = "You are No. " + (i + 1) +
                    ". \r\n Your score is " + list[i].Value;
                byte[] buffer = Encoding.Default.GetBytes(result);

                List<byte> listByte = new List<byte>();

                listByte.Add(2);
                listByte.AddRange(buffer);

                byte[] newBuffer = listByte.ToArray();

                dicSocket[list[i].Key].Send(newBuffer);

                //Console.WriteLine(result);
            }
        }

        public void ShowMsg(string msg)
        {
            txt_msg.AppendText(msg + "\r\n");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            byte[] buffer = new byte[1];
            buffer[0] = 1;

            //server send start info to client
            foreach (KeyValuePair<string, Socket> kv in dicSocket)
            {
                kv.Value.Send(buffer);
            }
        }
    }
}
