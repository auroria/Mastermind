using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mastermind;


namespace WindowsFormsApplication1
{
    //public enum colors { Red, Blue, Yellow, Green, Pink, Orange, Purple, Gray, White, Black };
    
    public partial class Form2 : Form
    {
        
        public Colors currentColor;
        public bool apply;
        

        public Form2()
        {
            InitializeComponent();
            currentColor = new Colors();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            currentColor = Colors.Orange;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            currentColor = Colors.Pink;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            GameForm.currentColor = currentColor;
            apply = true;

            //set the button color
            switch(currentColor)
            {
                case Colors.Red:
                    GameForm.colorButton.Image = Image.FromFile("C:\\Users\\Benjamin\\Pictures\\RedBall.png");
                    break;

                case Colors.Blue:
                    GameForm.colorButton.Image = Image.FromFile("C:\\Users\\Benjamin\\Pictures\\BlueBall.png");
                    break;

                case Colors.Yellow:
                    GameForm.colorButton.Image = Image.FromFile("C:\\Users\\Benjamin\\Pictures\\YellowBall.png");
                    break;

                case Colors.Green:
                    GameForm.colorButton.Image = Image.FromFile("C:\\Users\\Benjamin\\Pictures\\GreenBall.png");
                    break;

                case Colors.Pink:
                    GameForm.colorButton.Image = Image.FromFile("C:\\Users\\Benjamin\\Pictures\\PinkBall.png");
                    break;

                case Colors.Orange:
                    GameForm.colorButton.Image = Image.FromFile("C:\\Users\\Benjamin\\Pictures\\OrangeBall.png");
                    break;

                case Colors.Purple:
                    GameForm.colorButton.Image = Image.FromFile("C:\\Users\\Benjamin\\Pictures\\PurpleBall.png");
                    break;

                case Colors.Gray:
                    GameForm.colorButton.Image = Image.FromFile("C:\\Users\\Benjamin\\Pictures\\GrayBall.png");
                    break;

                case Colors.White:
                    GameForm.colorButton.Image = Image.FromFile("C:\\Users\\Benjamin\\Pictures\\WhiteBall.png");
                    break;

                case Colors.Black:
                    GameForm.colorButton.Image = Image.FromFile("C:\\Users\\Benjamin\\Pictures\\BlackBall.png");
                    break;
            }

            //GameForm.guessSettings[]

            this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            apply = false;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentColor = Colors.Red;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            currentColor = Colors.Blue;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            currentColor = Colors.Yellow;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            currentColor = Colors.Green;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            currentColor = Colors.Gray;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            currentColor = Colors.Purple;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            currentColor = Colors.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentColor = Colors.Black;
        }


    }
}
