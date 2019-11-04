using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Brejkaut
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Cursor.Hide();
            InitializeComponent();
        }
        void noviNivo() 
        {
            StreamReader sr = new StreamReader("C:/Users/ajovicic/Desktop/Brejkaut/Brejkaut/bin/Debug/lvl" + lvl + ".txt");
            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 12; i++)
                {
                    string line = sr.ReadLine();

                    if (line == "1"||line=="2"||line=="3")
                    {
                        cike++;
                        hp[j,i]=int.Parse(line);
                        var picture = new PictureBox
                        {
                            Name = "blok" + i + j,
                            Size = new Size(40, 30),
                            BackColor = Color.Transparent,
                            Image = Image.FromFile("blok"+line+".png"),
                            Location = new Point(40 + 60 * i, 30 + 35 * j),
                            SizeMode = PictureBoxSizeMode.StretchImage
                        };
                        Controls.Add(picture);
                        
                    }

                }
            }
            if (lvl == 4) 
            {
                cike++;
                int i = 0;
                int j = 0;
                var picture = new PictureBox
                {
                    Name = "blok"+i+j,
                    Size = new Size(200, 160),
                    BackColor = Color.Transparent,
                    Image = Image.FromFile("boss.png"),
                    Location = new Point(300, 30),
                    SizeMode = PictureBoxSizeMode.StretchImage
                 };
                 Controls.Add(picture);
                 var label = new Label();
                 label.Name = "label";
                 label.Location = new Point(380, 10);
                 label.Text = "Helt: " + (bosshp-1);
                 label.ForeColor = Color.White;
                 label.Size = new Size(50, 50);
                 Controls.Add(label);
                 
                 
                    
                

            }
            sr.Close();
            int x = rand.Next(0, 750);
            int y = rand.Next(200, 300);
            lopta.Location = new Point(x,y);
            timer.Stop();
            if (lvl < 4)
                MessageBox.Show("Nivo " + lvl+"\nZa pocetak kliknuti mis, za pauzu P");
            if (lvl == 4) 
            {
                MessageBox.Show("Boss nivo");
                MessageBox.Show("Boss ima stit kojeg moras udariti 50 puta da bi dosao do njega");
            }
            brzinaY = 2;
            brzinaX = 4;
            brzinaY = Math.Abs(brzinaY);
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            noviNivo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        Random rand = new Random();
        int brzinaX = 4;
        int brzinaY = 2;
        int brojac = 0;
        int lvl = 4;
        int cike = 0;
        int[,] hp=new int[5,12];
        int nt = 0;
        int bosshp = 51;
        
        private void timer_Tick(object sender, EventArgs e)
        {
            int posX = PointToClient(Cursor.Position).X - igrac.Width / 2;
            
            if (posX <= 0)
                posX = 0;

            if (posX + igrac.Width >= ClientRectangle.Width)
                posX = ClientRectangle.Width - igrac.Width;

            igrac.Left = posX;

            lopta.Left += brzinaX;
            lopta.Top += brzinaY;

            if (lopta.Top < 0)
                brzinaY = Math.Abs(brzinaY);

            if (lopta.Bottom > ClientRectangle.Height)
            {
                MessageBox.Show("Kraj");
                Close();
            }

            if (lopta.Left < 0)
                brzinaX = Math.Abs(brzinaX);

            if (lopta.Right > ClientRectangle.Width)
                brzinaX = -Math.Abs(brzinaX);

            if (Math.Abs(lopta.Bottom - igrac.Top) < Math.Abs(brzinaY) && lopta.Right > igrac.Left && lopta.Left < igrac.Right)
            {
                brzinaY = -Math.Abs(brzinaY);
                /*double vt = Math.Sqrt(brzinaX * brzinaX + brzinaY * brzinaY);
                double xl = (lopta.Left * 1.0 + lopta.Right) / 2;
                double koef = 1 - (xl - igrac.Left) / igrac.Width;
                double minUgao = Math.PI / 5;
                double maxUgao = 4 * Math.PI / 5;
                double ugao = minUgao + (maxUgao - minUgao) * koef;
                double k = Math.Tan(ugao);
                brzinaX = (int)Math.Ceiling(Math.Sign(0.5-koef) * Math.Sqrt(vt * vt / (1 + k * k)));
                brzinaY = -(int)Math.Ceiling(Math.Sqrt(vt * vt * k * k / (1 + k * k)));*/
            }

            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 12; i++)
                {
                    Control[] k = Controls.Find("blok" + i + j, false);
                    if (k.Length == 0)
                    {
                        continue;
                    }

                    PictureBox blok = (PictureBox)k[0];
                    if (Math.Abs(blok.Right - lopta.Left) < Math.Abs(brzinaX) && blok.Bottom > lopta.Top && blok.Top < lopta.Bottom)
                    {
                        brzinaX = Math.Abs(brzinaX);
                        hp[j, i]--;
                        if (lvl == 4)
                            bosshp--;
                        if (bosshp == 1)
                        {
                            blok.Size = new Size(40, 30);
                            blok.Image = Image.FromFile("bosshit.png");
                            blok.Location = new Point(380, 50);
                            timer.Stop();
                            timer2.Stop();
                            int x = rand.Next(0, 750);
                            int y = rand.Next(200, 300);
                            lopta.Location = new Point(x, y);
                            brzinaY = Math.Abs(brzinaY);
                            MessageBox.Show("Iskoristio je svu svoju energiju na stit, DOVRSI GA!");
                        }
                        if (bosshp == 0)
                        {
                            Controls.RemoveByKey("blok" + i + j);
                            brojac++;
                        }
                        if (hp[j, i] == 2)
                            blok.Image = Image.FromFile("blok2.png");
                        if (hp[j, i] == 1)
                            blok.Image = Image.FromFile("blok1.png");
                        if (hp[j, i] == 0)
                        {
                            Controls.RemoveByKey("blok" + i + j);
                            brojac++;
                        }
                    }

                    if (Math.Abs(blok.Bottom - lopta.Top)<Math.Abs(brzinaY) && blok.Left < lopta.Right && blok.Right > lopta.Left)
                    {
                        brzinaY = Math.Abs(brzinaY);
                        hp[j, i]--;
                        if (lvl == 4)
                            bosshp--;
                        if (bosshp == 1)
                        {
                            blok.Size = new Size(40, 30);
                            blok.Image = Image.FromFile("bosshit.png");
                            blok.Location = new Point(380, 50);
                            timer.Stop();
                            timer2.Stop();
                            int x = rand.Next(0, 750);
                            int y = rand.Next(200, 300);
                            lopta.Location = new Point(x, y);
                            brzinaY = Math.Abs(brzinaY);
                            MessageBox.Show("Iskoristio je svu svoju energiju na stit , DOVRSI GA!");
                        }
                        if (bosshp == 0)
                        {
                            Controls.RemoveByKey("blok" + i + j);
                            brojac++;
                        }
                        if (hp[j, i] == 2)
                            blok.Image = Image.FromFile("blok2.png");
                        if (hp[j, i] == 1)
                            blok.Image = Image.FromFile("blok1.png");
                        if (hp[j, i] == 0)
                        {
                            Controls.RemoveByKey("blok" + i + j);
                            brojac++;
                        }
                    }

                    if (Math.Abs(blok.Left - lopta.Right)<Math.Abs(brzinaX) && blok.Bottom > lopta.Top && blok.Top < lopta.Bottom)
                    {
                        brzinaX = -Math.Abs(brzinaX);
                        hp[j, i]--;
                        if (lvl == 4)
                            bosshp--;
                        if (bosshp == 1)
                        {
                            blok.Size = new Size(40, 30);
                            blok.Image = Image.FromFile("bosshit.png");
                            blok.Location = new Point(380, 50);
                            timer.Stop();
                            timer2.Stop();
                            int x = rand.Next(0, 750);
                            int y = rand.Next(200, 300);
                            lopta.Location = new Point(x, y);
                            brzinaY = Math.Abs(brzinaY);
                            MessageBox.Show("Iskoristio je svu svoju energiju na stit , DOVRSI GA!");
                        }
                        if (bosshp == 0)
                        {
                            Controls.RemoveByKey("blok" + i + j);
                            brojac++;
                        }
                        if (hp[j, i] == 2)
                            blok.Image = Image.FromFile("blok2.png");
                        if (hp[j, i] == 1)
                            blok.Image = Image.FromFile("blok1.png");
                        if (hp[j, i] == 0)
                        {
                            Controls.RemoveByKey("blok" + i + j);
                            brojac++;
                        }
                    }

                    if (Math.Abs(blok.Top - lopta.Bottom)<Math.Abs(brzinaY) && blok.Right > lopta.Left && blok.Left < lopta.Right)
                    {
                        brzinaY = -Math.Abs(brzinaY);
                        hp[j, i]--;
                        if (lvl == 4)
                            bosshp--;
                        if (bosshp == 1)
                        {
                            blok.Size = new Size(40, 30);
                            blok.Image = Image.FromFile("bosshit.png");
                            blok.Location = new Point(380, 50);
                            timer.Stop();
                            timer2.Stop();
                            int x = rand.Next(0, 750);
                            int y = rand.Next(200, 300);
                            lopta.Location = new Point(x, y);
                            brzinaY = Math.Abs(brzinaY);
                            MessageBox.Show("Iskoristio je svu svoju energiju na stit , DOVRSI GA!");
                        }
                        if (bosshp == 0)
                        {
                            Controls.RemoveByKey("blok" + i + j);
                            brojac++;
                        }
                        if (hp[j, i] == 2)
                            blok.Image = Image.FromFile("blok2.png");
                        if (hp[j, i] == 1)
                            blok.Image = Image.FromFile("blok1.png");
                        if (hp[j, i] == 0)
                        {
                            Controls.RemoveByKey("blok" + i + j);
                            brojac++;
                        }
                    }
                    if (brojac == cike)
                    {
                        lvl++;
                        cike = 0;
                        brojac = 0;
                        if (lvl > 4)
                        {
                            timer.Stop();
                            timer2.Stop();
                            MessageBox.Show("Bravo,pobedio si bossa");
                            Close();
                        }
                        else
                            noviNivo();
                        
                    }
                    if (nt > 5) 
                    {
                        timer.Stop();
                        timer2.Stop();
                        MessageBox.Show("aj nemoj 5 puta pauzirati, idiote");
                        nt = 0;
                    } 
                }
            }

            foreach (Control c in Controls)
                if (c is Label && c.Name == "label")
                    (c as Label).Text = "Helt: " + (bosshp-1);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            timer.Start();
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (brzinaX < 0)
                brzinaX--;
            if (brzinaX > 0)
                brzinaX++;
            if (brzinaY < 0)
                brzinaY--;
            if (brzinaY > 0)
                brzinaY++;
        }


        private void Form1_Load_1(object sender, EventArgs e)
        {

        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P)
            {
                timer.Stop();
                timer2.Stop();
                nt++;
            }
        }
    }
}
