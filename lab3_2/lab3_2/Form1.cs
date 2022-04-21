using lab3_2.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3_2
{
    public partial class Form1 : Form
    {
        public struct Cards
        {
            public int Card;
            public string Suit;
        }
        public Cards[] cards = new Cards[36];
        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            int num = 1;
            for (int i = 0; i < cards.Length; i += 4)
            {
                if (num <= 9)
                {
                   cards[i].Card = num;
                    cards[i].Suit = "Clubs";
                    cards[i + 1].Card = num;
                    cards[i + 1].Suit = "Diamonds";
                    cards[i + 2].Card = num;
                    cards[i + 2].Suit = "Hearts";
                    cards[i + 3].Card = num;
                    cards[i + 3].Suit = "Spades";
                    num++;
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
        public void RotatableImage()
        {
            DoubleBuffered = true; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private Point MouseDownLocation;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                pictureBox1.Left = e.X + pictureBox1.Left - MouseDownLocation.X;
                pictureBox1.Top = e.Y + pictureBox1.Top - MouseDownLocation.Y;
            }
        }
        public int[] Tmp = new int[36];
        public int tmpNumber = 0;
        public PictureBox[] Pb = new PictureBox[3];
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Pb[0] = pictureBox1;
            Pb[1] = pictureBox2;
            Random rand = new Random();
            float Ang = rand.Next(-30, 30);
            int number = rand.Next(1, 36);
            if (RandomTest(number, Tmp) == 1)
            {
                WhichCard(cards, number - 1, e, this,Ang);
            }
            else
            {
                while (RandomTest(number, Tmp) == -1)
                {
                    number = rand.Next(1, 36);                   
                }
                WhichCard(cards, number - 1, e, this,Ang);
            }
            Tmp[tmpNumber] = number;
            ++tmpNumber;                        

            pictureBox1.Location = pictureBox2.Location;
            if (Tmp[Tmp.Length - 1] != 0)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
            }
        }
        public static void WhichCard(Cards[]S,int number,MouseEventArgs e,Form main,float Ang)
        {
            PictureBox picture = new PictureBox();
            picture.Location = MousePosition;
            picture.Name = "";
            picture.Size = new Size(172, 252);
            picture.SizeMode = PictureBoxSizeMode.StretchImage;

                if (S[number].Card == 1)
                {
                    if (S[number].Suit == "Clubs") picture.Image = Resources._6Clubs;
                    if (S[number].Suit == "Diamonds") picture.Image = Resources._6Diamonds;
                    if (S[number].Suit == "Hearts") picture.Image = Resources._6Hearts;
                    if (S[number].Suit == "Spades") picture.Image = Resources._6Spades;
                }
                if (S[number].Card == 2)
                {
                    if (S[number].Suit == "Clubs") picture.Image = Resources._7Clubs;
                    if (S[number].Suit == "Diamonds") picture.Image = Resources._7Diamonds;
                    if (S[number].Suit == "Hearts") picture.Image = Resources._7Hearts;
                    if (S[number].Suit == "Spades") picture.Image = Resources._7Spades;
                }
                if (S[number].Card == 3)
                {
                    if (S[number].Suit == "Clubs") picture.Image = Resources._8Clubs;
                    if (S[number].Suit == "Diamonds") picture.Image = Resources._8Diamonds;
                    if (S[number].Suit == "Hearts") picture.Image = Resources._8Hearts;
                    if (S[number].Suit == "Spades") picture.Image = Resources._8Spades;
                }
                if (S[number].Card == 4)
                {
                    if (S[number].Suit == "Clubs") picture.Image = Resources._9Clubs;
                    if (S[number].Suit == "Diamonds") picture.Image = Resources._9Diamonds;
                    if (S[number].Suit == "Hearts") picture.Image = Resources._9Hearts;
                    if (S[number].Suit == "Spades") picture.Image = Resources._9Spades;
                }
                if (S[number].Card == 5)
                {
                    if (S[number].Suit == "Clubs") picture.Image = Resources._10Clubs;
                    if (S[number].Suit == "Diamonds") picture.Image = Resources._10Diamonds;
                    if (S[number].Suit == "Hearts") picture.Image = Resources._10Hearts;
                    if (S[number].Suit == "Spades") picture.Image = Resources._10Spades;
                }
                if (S[number].Card == 6)
                {
                    if (S[number].Suit == "Clubs") picture.Image = Resources.JClubs;
                    if (S[number].Suit == "Diamonds") picture.Image = Resources.JDiamonds;
                    if (S[number].Suit == "Hearts") picture.Image = Resources.JHearts;
                    if (S[number].Suit == "Spades") picture.Image = Resources.JSpades;
                }
                if (S[number].Card == 7)
                {
                    if (S[number].Suit == "Clubs") picture.Image = Resources.QClubs;
                    if (S[number].Suit == "Diamonds") picture.Image = Resources.QDiamonds;
                    if (S[number].Suit == "Hearts") picture.Image = Resources.QHearts;
                    if (S[number].Suit == "Spades") picture.Image = Resources.QSpades;
                }
                if (S[number].Card == 8)
                {
                    if (S[number].Suit == "Clubs") picture.Image = Resources.KClubs;
                    if (S[number].Suit == "Diamonds") picture.Image = Resources.KDiamonds;
                    if (S[number].Suit == "Hearts") picture.Image = Resources.KHearts;
                    if (S[number].Suit == "Spades") picture.Image = Resources.KSpades;
                }
                if (S[number].Card == 9)
                {
                    if (S[number].Suit == "Clubs") picture.Image = Resources.AClubs;
                    if (S[number].Suit == "Diamonds") picture.Image = Resources.ADiamonds;
                    if (S[number].Suit == "Hearts") picture.Image = Resources.AHearts;
                    if (S[number].Suit == "Spades") picture.Image = Resources.ASpades;
                }
            main.Controls.Add(picture);            
        }
        public static int RandomTest(int number, int[] Tmp)
        {
            if (Tmp.Contains(number)) return -1;
            else { return 1; }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.F2)
            {
                this.Controls.Clear();
                this.Controls.Add(Pb[0]);
                Pb[0].Visible = true;
                Pb[1].Visible = true;
                this.Controls.Add(Pb[1]);
                Array.Clear(Tmp, 0, Tmp.Length);
                tmpNumber = 0;
            }
        }
    }
}
