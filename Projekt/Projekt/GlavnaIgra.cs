using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projekt;
using System.Xml.Linq;
using System.IO;

namespace Projekt
{
    public partial class GameWindow : Form
    {
        int potezii = 0;
        int hit = 0;
        Random lokacija = new Random();
        List<Point> points = new List<Point>();

        int High;
        PictureBox pendingImage1;
        PictureBox pendingImage2;


        
        public GameWindow()
        {
            InitializeComponent();
        }

        private void Kreni_Click(object sender, EventArgs e)
        {
            if (Ime.TextLength == 0)
            {
                MessageBox.Show("Niste unijeli ime!");
            }
            else
            {
                label2.Text = "5";
                foreach (PictureBox picture in CardsHolder.Controls)
                {
                    picture.Enabled = false;
                    points.Add(picture.Location);
                }
                foreach (PictureBox picture in CardsHolder.Controls)
                {
                    int next = lokacija.Next(points.Count);
                    Point p = points[next];
                    picture.Location = p;
                    points.Remove(p);
                }
                timer1.Start();
                timer2.Start();
            }
        }


        private void GameWindow_Load(object sender, EventArgs e)
        {
            

            if (!File.Exists("Vjezba.xml"))
            {
                XDocument docu = new XDocument(
                    new XDeclaration("1.0", "UTF-8", "yes"),
                    new XElement("Igraci"));
                docu.Save("Vjezba.xml");
               
            }
            
            High = Properties.Settings.Default.HighScore;
            Highscore.Text = Convert.ToString(High);

            foreach (PictureBox picture in CardsHolder.Controls)
            {
                picture.Image = Properties.Resources.cover;
                picture.Enabled = false;
            }

            card1.Image = Properties.Resources.Card1;
            dupcard1.Image = Properties.Resources.Card1;
            card2.Image = Properties.Resources.Card2;
            dupcard2.Image = Properties.Resources.Card2;
            card3.Image = Properties.Resources.Card3;
            dupcard3.Image = Properties.Resources.Card3;
            card4.Image = Properties.Resources.Card4;
            dupcard4.Image = Properties.Resources.Card4;
            card5.Image = Properties.Resources.Card5;
            dupcard5.Image = Properties.Resources.Card5;
            card6.Image = Properties.Resources.Card6;
            dupcard6.Image = Properties.Resources.Card6;
            card7.Image = Properties.Resources.Card7;
            dupcard7.Image = Properties.Resources.Card7;
            card8.Image = Properties.Resources.Card8;
            dupcard8.Image = Properties.Resources.Card8;
            card9.Image = Properties.Resources.Card9;
            dupcard9.Image = Properties.Resources.Card9;
            card10.Image = Properties.Resources.Card10;
            dupcard10.Image = Properties.Resources.Card10;
            card11.Image = Properties.Resources.Card11;
            dupcard11.Image = Properties.Resources.Card11;
            card12.Image = Properties.Resources.Card12;
            dupcard12.Image = Properties.Resources.Card12;


        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            foreach (PictureBox picture in CardsHolder.Controls)
            {
                picture.Enabled = true;
                picture.Cursor = Cursors.Hand;
                picture.Image = Properties.Resources.cover;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int timer = Convert.ToInt32(label2.Text);
            timer = timer-1;
            label2.Text = Convert.ToString(timer);
            if(timer== 0)
            {
                timer2.Stop();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Stop();
            pendingImage1.Image = Properties.Resources.cover;
            pendingImage2.Image = Properties.Resources.cover;
            pendingImage1 = null;
            pendingImage2 = null;
        }


        #region Cards

        private void card1_Click(object sender, EventArgs e)
        {
            card1.Image = Properties.Resources.Card1;
            if (pendingImage1 == null)
            {
                pendingImage1 = card1;
            }
            else if(pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = card1;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card1.Enabled = false;
                    dupcard1.Enabled = false;
                    hit = hit + 1;
                    potezii = potezii + 10;
                }
                else
                {
                    timer3.Start();
                    if (potezii > 0)
                    {
                        potezii = potezii - 5;
                    }

                }
            }
            Potezi.Text = Convert.ToString(potezii);
            CheckForWinner();
        }

        private void dupcard1_Click(object sender, EventArgs e)
        {
            dupcard1.Image = Properties.Resources.Card1;
            if (pendingImage1 == null)
            {
                pendingImage1 = dupcard1;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = dupcard1;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card1.Enabled = false;
                    dupcard1.Enabled = false;
                    hit = hit + 1;
                    potezii = potezii + 10;
                }
                else 
                {
                    timer3.Start();
                    if (potezii > 0)
                    {
                        potezii = potezii - 5;
                    }

                }
            }
            Potezi.Text = Convert.ToString(potezii);
            CheckForWinner();
        }

        private void card2_Click(object sender, EventArgs e)
        {
            card2.Image = Properties.Resources.Card2;
            if (pendingImage1 == null)
            {
                pendingImage1 = card2;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = card2;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card2.Enabled = false;
                    dupcard2.Enabled = false;
                    hit = hit + 1;
                    potezii = potezii + 10;
                }
                else
                {
                    timer3.Start();
                    if (potezii > 0)
                    {
                        potezii = potezii - 5;
                    }

                }
            }
            Potezi.Text = Convert.ToString(potezii);
            CheckForWinner();
        }

        private void dupcard2_Click(object sender, EventArgs e)
        {
            dupcard2.Image = Properties.Resources.Card2;

            if (pendingImage1 == null)
            {
                pendingImage1 = dupcard2;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = dupcard2;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card2.Enabled = false;
                    dupcard2.Enabled = false;
                    hit = hit + 1;
                    potezii = potezii + 10;
                }
                else
                {
                    timer3.Start();
                    if (potezii > 0)
                    {
                        potezii = potezii - 5;
                    }

                }
            }
            Potezi.Text = Convert.ToString(potezii);
            CheckForWinner();
        }

        private void card3_Click(object sender, EventArgs e)
        {
            card3.Image = Properties.Resources.Card3;
            if (pendingImage1 == null)
            {
                pendingImage1 = card3;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = card3;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card3.Enabled = false;
                    dupcard3.Enabled = false;
                    hit = hit + 1;
                    potezii = potezii + 10;
                }
                else
                {
                    timer3.Start();
                    if (potezii > 0)
                    {
                        potezii = potezii - 5;
                    }
                }
            }
            Potezi.Text = Convert.ToString(potezii);
            CheckForWinner();
        }

        private void dupcard3_Click(object sender, EventArgs e)
        {
            dupcard3.Image = Properties.Resources.Card3;
            if (pendingImage1 == null)
            {
                pendingImage1 = dupcard3;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = dupcard3;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card3.Enabled = false;
                    dupcard3.Enabled = false;
                    hit = hit + 1;
                    potezii = potezii + 10;
                }
                else
                {
                    timer3.Start();
                    if (potezii > 0)
                    {
                        potezii = potezii - 5;
                    }
                }
            }
            Potezi.Text = Convert.ToString(potezii);
            CheckForWinner();
        }

        private void card4_Click(object sender, EventArgs e)
        {
            card4.Image = Properties.Resources.Card4;
            if (pendingImage1 == null)
            {
                pendingImage1 = card4;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = card4;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card4.Enabled = false;
                    dupcard4.Enabled = false;
                    hit = hit + 1;
                    potezii = potezii + 10;
                }
                else 
                {
                    timer3.Start();
                    if (potezii > 0)
                    {
                        potezii = potezii - 5;
                    }
                }
            }
            Potezi.Text = Convert.ToString(potezii);
            CheckForWinner();

        }

        private void dupcard4_Click(object sender, EventArgs e)
        {
            dupcard4.Image = Properties.Resources.Card4;
            if (pendingImage1 == null)
            {
                pendingImage1 = dupcard4;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = dupcard4;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card4.Enabled = false;
                    dupcard4.Enabled = false;
                    hit = hit + 1;
                    potezii = potezii + 10;
                }
                else
                {
                    timer3.Start();
                    if (potezii > 0)
                    {
                        potezii = potezii - 5;
                    }
                }
            }
            Potezi.Text = Convert.ToString(potezii);
            CheckForWinner();
        }

        private void card5_Click(object sender, EventArgs e)
        {
            card5.Image = Properties.Resources.Card5;
            if (pendingImage1 == null)
            {
                pendingImage1 = card5;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = card5;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card5.Enabled = false;
                    dupcard5.Enabled = false;
                    hit = hit + 1;
                    potezii = potezii + 10;
                }
                else
                {
                    timer3.Start();
                    if (potezii > 0)
                    {
                        potezii = potezii - 5;
                    }
                }
            }
            Potezi.Text = Convert.ToString(potezii);
            CheckForWinner();
        }

        private void dupcard5_Click(object sender, EventArgs e)
        {
            dupcard5.Image = Properties.Resources.Card5;
            if (pendingImage1 == null)
            {
                pendingImage1 = dupcard5;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = dupcard5;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card5.Enabled = false;
                    dupcard5.Enabled = false;
                    hit = hit + 1;
                    potezii = potezii + 10;
                }
                else
                {
                    timer3.Start();
                    if (potezii > 0)
                    {
                        potezii = potezii - 5;
                    }
                }
            }
            Potezi.Text = Convert.ToString(potezii);
            CheckForWinner();
        }

        private void card6_Click(object sender, EventArgs e)
        {
            card6.Image = Properties.Resources.Card6;
            if (pendingImage1 == null)
            {
                pendingImage1 = card6;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = card6;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card6.Enabled = false;
                    dupcard6.Enabled = false;
                    hit = hit + 1;
                    potezii = potezii + 10;
                }
                else
                {
                    timer3.Start();
                    if (potezii > 0)
                    {
                        potezii = potezii - 5;
                    }
                }
            }
            Potezi.Text = Convert.ToString(potezii);
            CheckForWinner();
        }

        private void dupcard6_Click(object sender, EventArgs e)
        {
            dupcard6.Image = Properties.Resources.Card6;
            if (pendingImage1 == null)
            {
                pendingImage1 = dupcard6;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = dupcard6;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card6.Enabled = false;
                    dupcard6.Enabled = false;
                    hit = hit + 1;
                    potezii = potezii + 10;
                }
                else
                {
                    timer3.Start();
                    if (potezii > 0)
                    {
                        potezii = potezii - 5;
                    }
                }
            }
            Potezi.Text = Convert.ToString(potezii);
            CheckForWinner();
        }

        private void card7_Click(object sender, EventArgs e)
        {
            card7.Image = Properties.Resources.Card7;
            if (pendingImage1 == null)
            {
                pendingImage1 = card7;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = card7;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card7.Enabled = false;
                    dupcard7.Enabled = false;
                    hit = hit + 1;
                    potezii = potezii + 10;
                }
                else
                {
                    timer3.Start();
                    if (potezii > 0)
                    {
                        potezii = potezii - 5;
                    }
                }
            }
            Potezi.Text = Convert.ToString(potezii);
            CheckForWinner();
        }

        private void dupcard7_Click(object sender, EventArgs e)
        {
            dupcard7.Image = Properties.Resources.Card7;
            if (pendingImage1 == null)
            {
                pendingImage1 = dupcard7;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = dupcard7;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card7.Enabled = false;
                    dupcard7.Enabled = false;
                    hit = hit + 1;
                    potezii = potezii + 10;
                }
                else
                {
                    timer3.Start();
                    if (potezii > 0)
                    {
                        potezii = potezii - 5;
                    }
                }
            }
            Potezi.Text = Convert.ToString(potezii);
            CheckForWinner();
        }

        private void card8_Click(object sender, EventArgs e)
        {
            card8.Image = Properties.Resources.Card8;
            if (pendingImage1 == null)
            {
                pendingImage1 = card8;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = card8;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card8.Enabled = false;
                    dupcard8.Enabled = false;
                    hit = hit + 1;
                    potezii = potezii + 10;
                }
                else
                {
                    timer3.Start();
                    if (potezii > 0)
                    {
                        potezii = potezii - 5;
                    }
                }
            }
            Potezi.Text = Convert.ToString(potezii);
            CheckForWinner();
        }

        private void dupcard8_Click(object sender, EventArgs e)
        {
            dupcard8.Image = Properties.Resources.Card8;
            if (pendingImage1 == null)
            {
                pendingImage1 = dupcard8;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = dupcard8;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card8.Enabled = false;
                    dupcard8.Enabled = false;
                    hit = hit + 1;
                    potezii = potezii + 10;
                }
                else
                {
                    timer3.Start();
                    if (potezii > 0)
                    {
                        potezii = potezii - 5;
                    }
                }
            }
            Potezi.Text = Convert.ToString(potezii);
            CheckForWinner();
        }

        private void card9_Click(object sender, EventArgs e)
        {
            card9.Image = Properties.Resources.Card9;
            if (pendingImage1 == null)
            {
                pendingImage1 = card9;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = card9;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card9.Enabled = false;
                    dupcard9.Enabled = false;
                    hit = hit + 1;
                    potezii = potezii + 10;
                }
                else
                {
                    timer3.Start();
                    if (potezii > 0)
                    {
                        potezii = potezii - 5;
                    }
                }
            }
            Potezi.Text = Convert.ToString(potezii);
            CheckForWinner();
        }

        private void dupcard9_Click(object sender, EventArgs e)
        {
            dupcard9.Image = Properties.Resources.Card9;
            if (pendingImage1 == null)
            {
                pendingImage1 = dupcard9;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = dupcard9;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card9.Enabled = false;
                    dupcard9.Enabled = false;
                    hit = hit + 1;
                    potezii = potezii + 10;
                }
                else
                {
                    timer3.Start();
                    if (potezii > 0)
                    {
                        potezii = potezii - 5;
                    }
                }
            }
            Potezi.Text = Convert.ToString(potezii);
            CheckForWinner();
        }

        private void card10_Click(object sender, EventArgs e)
        {
            card10.Image = Properties.Resources.Card10;
            if (pendingImage1 == null)
            {
                pendingImage1 = card10;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = card10;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card10.Enabled = false;
                    dupcard10.Enabled = false;
                    hit = hit + 1;
                    potezii = potezii + 10;
                }
                else
                {
                    timer3.Start();
                    if (potezii > 0)
                    {
                        potezii = potezii - 5;
                    }
                }
            }
            Potezi.Text = Convert.ToString(potezii);
            CheckForWinner();
        }

        private void dupcard10_Click(object sender, EventArgs e)
        {
            dupcard10.Image = Properties.Resources.Card10;
            if (pendingImage1 == null)
            {
                pendingImage1 = dupcard10;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = dupcard10;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card10.Enabled = false;
                    dupcard10.Enabled = false;
                    hit = hit + 1;
                    potezii = potezii + 10;
                }
                else
                {
                    timer3.Start();
                    if (potezii > 0)
                    {
                        potezii = potezii - 5;
                    }
                }
            }
            Potezi.Text = Convert.ToString(potezii);
        }

        private void card11_Click(object sender, EventArgs e)
        {
            card11.Image = Properties.Resources.Card11;
            if (pendingImage1 == null)
            {
                pendingImage1 = card11;
                
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = card11;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card11.Enabled = false;
                    dupcard11.Enabled = false;
                    hit = hit + 1;
                    potezii = potezii + 10;
                }
                else
                {
                    timer3.Start();
                    if (potezii > 0)
                    {
                        potezii = potezii - 5;
                    }
                }
            }
            Potezi.Text = Convert.ToString(potezii);
            CheckForWinner();
        }

        private void dupcard11_Click(object sender, EventArgs e)
        {
            dupcard11.Image = Properties.Resources.Card11;
            if (pendingImage1 == null)
            {
                pendingImage1 = dupcard11;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = dupcard11;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card11.Enabled = false;
                    dupcard11.Enabled = false;
                    hit = hit + 1;
                    potezii = potezii + 10;
                }
                else
                {
                    timer3.Start();
                    if (potezii > 0)
                    {
                        potezii = potezii - 5;
                    }
                }
            }
            Potezi.Text = Convert.ToString(potezii);
            CheckForWinner();
        }

        private void card12_Click(object sender, EventArgs e)
        {
            card12.Image = Properties.Resources.Card12;
            if (pendingImage1 == null)
            {
                pendingImage1 = card12;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = card12;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card12.Enabled = false;
                    dupcard12.Enabled = false;
                    hit = hit + 1;
                    potezii = potezii + 10;
                }
                else
                {
                    timer3.Start();
                    if (potezii > 0)
                    {
                        potezii = potezii - 5;
                    }
                }
            }
            Potezi.Text = Convert.ToString(potezii);
            CheckForWinner();
        }

        private void dupcard12_Click(object sender, EventArgs e)
        {
            dupcard12.Image = Properties.Resources.Card12;
            if (pendingImage1 == null)
            {
                pendingImage1 = dupcard12;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = dupcard12;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card12.Enabled = false;
                    dupcard12.Enabled = false;
                    hit = hit + 1;
                    potezii = potezii + 10;
                }
                else
                {
                    timer3.Start();
                    if (potezii > 0)
                    {
                        potezii = potezii - 5;
                    }
                }
            }
            Potezi.Text = Convert.ToString(potezii);
            CheckForWinner();
        }
        #endregion



        private void CheckForWinner()
        {
            if (!File.Exists("Vjezba.xml"))
            {
                XDocument docu = new XDocument(
                    new XDeclaration("1.0", "UTF-8", "yes"),
                    new XElement("Igraci"));
                docu.Save("Vjezba.xml");

            }

            if (hit == 12)
            {
                MessageBox.Show(Ime.Text +" pobjedili ste i vaš rezultat je: " + potezii);
                XDocument doc = XDocument.Load("Vjezba.xml");
                XElement root = new XElement("Igrac");
                root.Add(new XElement("Ime", Ime.Text));
                root.Add(new XElement("Rezultat", potezii));
                doc.Element("Igraci").Add(root);
                doc.Save("Vjezba.xml");
                Close();
            }
        }

        private void GameWindow_FormClosing(object sender, FormClosingEventArgs e)
        {


            High = Properties.Settings.Default.HighScore;
            Rezultat spremi = new Rezultat(potezii,High);

            if (hit == 12)
            {
                spremi.spremiRez();
            }
        }

        private void postaviHighScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.HighScore = 0;
            Properties.Settings.Default.Save();
        }

        private void novaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameWindow_Load(sender, e);
            potezii = 0;
            hit = 0;
        }

        private void izlazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listaIgracaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists("Vjezba.xml"))
            {
                ListaIgraca forma = new ListaIgraca();
                forma.Visible = true;
            }
            else
            {
                MessageBox.Show("Datoteka ne postoji!");
            }

        }

        private void obirisiListuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.Delete("Vjezba.xml");
        }




    }
}
