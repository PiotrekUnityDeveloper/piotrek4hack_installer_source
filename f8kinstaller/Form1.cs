using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace f8kinstaller
{
    public partial class Form1 : Form
    {
        public bool canshowpromo = true;

        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        public bool canload;
        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Show();
            canload = true;
            exitbtn.Hide();
        }

        Random rnd = new Random();

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(canload == true)
            {
                if(progressBar1.Value < 1000)
                {
                    progressBar1.Value += rnd.Next(1, 11);
                    timer1.Interval = rnd.Next(457, 999);

                    if(progressBar1.Value > 400 && progressBar1.Value < 950)
                    {
                        if(canshowpromo == true)
                        {
                            panel1.Show();
                        }
                        
                    }
                    else
                    {
                        panel1.Hide();
                    }
                }
                else
                {
                    label2.Show();
                    button1.Hide();
                    progressBar1.Hide();
                    messageloader.Start();
                    panel1.Hide();
                    dismissthanks();
                    canload = false;
                }
            }
        }

        int resizetimes = 100;

        private void messageloader_Tick(object sender, EventArgs e)
        {
            if(resizetimes > 0)
            {
                //modify the window size
                this.Width += 2;

                resizetimes--;
            }
            else
            {
                messageloader.Stop();
                lablhider.Start();
                //download();
                //seconddownload();
                //HttpDownloadFileAsync(new HttpClient(), "", "");
                //download();  
            }
        }

        public int velocity = 1;

        private void lablhider_Tick(object sender, EventArgs e)
        {
            label1.Left -= velocity;
            label2.Left -= velocity;

            velocity = ((velocity * 2) - (int)(velocity/2)) - (int)(velocity / 3);

            if(velocity >= 400)
            {
                lablhider.Stop();
                imgshow.Start();
            }
        }

        public int picvel = 1; //picture velocity

        private void imgshow_Tick(object sender, EventArgs e)
        {
            if(pictureBox1.Left < 65)
            {
                pictureBox1.Left += picvel;
                picvel = ((picvel * 2) - (int)(picvel / 2)) - (int)(picvel / 3);
            }
            else
            {
                
                imgshow.Stop(); //done!
                seconddownload();

            }

            //Console.WriteLine("siema: " + pictureBox1.Left + ";       picvel = " + picvel);
            
        }

        private void download()
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://piotrekunitydeveloper.github.io/piotrek4.hack/testfile.txt", System.Environment.SpecialFolder.MyDocuments + "\\piotrek4hack.txt");
                }

                MessageBox.Show("Client Downloaded!");
            }
            catch
            {
                MessageBox.Show("ERROR: couldnt download file package from the server. Make sure you have internet access", "DOWNLOADING ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
            thankyou();
        }

        private void thankyou()
        {
            panel1.Hide();
            canshowpromo = false;
            thanks.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dismissthanks();
        }

        private void dismissthanks()
        {
            panel1.Hide();
            canshowpromo = false;
            thanks.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void seconddownload()
        {
            System.Diagnostics.Process.Start("https://drive.google.com/uc?export=download&id=1YIUg4ocj-2riN1VWtWQBsXlphPlgGGnq");
        }

        static public async Task HttpDownloadFileAsync(HttpClient httpClient, string url, string fileToWriteTo)
        {
            
        }
    }
}
