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
    public partial class GameForm : Form
    {
        public static Colors currentColor;
        public static Button colorButton;
        PictureBox[][] resultPegs;
        public Colors[] guess = new Colors[5];
        public static bool[] guessSettings = new bool[5] {false, false, false, false, false};

        public GameForm()
        {
            InitializeComponent();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            resultPegs = new PictureBox[20][];
            for (int i = 0; i < 20; i++)
            {
                resultPegs[i] = new PictureBox[5];
            }

            resultPegs[0][0] = pictureBox1;
            resultPegs[0][1] = pictureBox2;
            resultPegs[0][2] = pictureBox3;
            resultPegs[0][3] = pictureBox4;
            resultPegs[0][4] = pictureBox5;

            resultPegs[1][0] = pictureBox10;
            resultPegs[1][1] = pictureBox9;
            resultPegs[1][2] = pictureBox8;
            resultPegs[1][3] = pictureBox7;
            resultPegs[1][4] = pictureBox6;

            resultPegs[2][0] = pictureBox15;
            resultPegs[2][1] = pictureBox14;
            resultPegs[2][2] = pictureBox13;
            resultPegs[2][3] = pictureBox12;
            resultPegs[2][4] = pictureBox11;

            resultPegs[3][0] = pictureBox20;
            resultPegs[3][1] = pictureBox19;
            resultPegs[3][2] = pictureBox18;
            resultPegs[3][3] = pictureBox17;
            resultPegs[3][4] = pictureBox16;

            resultPegs[4][0] = pictureBox25;
            resultPegs[4][1] = pictureBox24;
            resultPegs[4][2] = pictureBox23;
            resultPegs[4][3] = pictureBox22;
            resultPegs[4][4] = pictureBox21;

            resultPegs[5][0] = pictureBox30;
            resultPegs[5][1] = pictureBox29;
            resultPegs[5][2] = pictureBox28;
            resultPegs[5][3] = pictureBox27;
            resultPegs[5][4] = pictureBox26;

            resultPegs[6][0] = pictureBox35;
            resultPegs[6][1] = pictureBox34;
            resultPegs[6][2] = pictureBox33;
            resultPegs[6][3] = pictureBox32;
            resultPegs[6][4] = pictureBox31;

            resultPegs[7][0] = pictureBox40;
            resultPegs[7][1] = pictureBox39;
            resultPegs[7][2] = pictureBox38;
            resultPegs[7][3] = pictureBox37;
            resultPegs[7][4] = pictureBox36;

            resultPegs[8][0] = pictureBox45;
            resultPegs[8][1] = pictureBox34;
            resultPegs[8][2] = pictureBox33;
            resultPegs[8][3] = pictureBox32;
            resultPegs[8][4] = pictureBox31;

            resultPegs[9][0] = pictureBox50;
            resultPegs[9][1] = pictureBox49;
            resultPegs[9][2] = pictureBox48;
            resultPegs[9][3] = pictureBox47;
            resultPegs[9][4] = pictureBox46;

            resultPegs[10][0] = pictureBox55;
            resultPegs[10][1] = pictureBox54;
            resultPegs[10][2] = pictureBox53;
            resultPegs[10][3] = pictureBox52;
            resultPegs[10][4] = pictureBox51;

            resultPegs[11][0] = pictureBox60;
            resultPegs[11][1] = pictureBox59;
            resultPegs[11][2] = pictureBox58;
            resultPegs[11][3] = pictureBox57;
            resultPegs[11][4] = pictureBox56;

            resultPegs[12][0] = pictureBox65;
            resultPegs[12][1] = pictureBox64;
            resultPegs[12][2] = pictureBox63;
            resultPegs[12][3] = pictureBox62;
            resultPegs[12][4] = pictureBox61;

            resultPegs[13][0] = pictureBox100;
            resultPegs[13][1] = pictureBox99;
            resultPegs[13][2] = pictureBox98;
            resultPegs[13][3] = pictureBox97;
            resultPegs[13][4] = pictureBox96;

            resultPegs[14][0] = pictureBox95;
            resultPegs[14][1] = pictureBox94;
            resultPegs[14][2] = pictureBox93;
            resultPegs[14][3] = pictureBox92;
            resultPegs[14][4] = pictureBox91;

            resultPegs[15][0] = pictureBox90;
            resultPegs[15][1] = pictureBox89;
            resultPegs[15][2] = pictureBox88;
            resultPegs[15][3] = pictureBox87;
            resultPegs[15][4] = pictureBox86;

            resultPegs[16][0] = pictureBox85;
            resultPegs[16][1] = pictureBox84;
            resultPegs[16][2] = pictureBox83;
            resultPegs[16][3] = pictureBox82;
            resultPegs[16][4] = pictureBox81;

            resultPegs[17][0] = pictureBox80;
            resultPegs[17][1] = pictureBox79;
            resultPegs[17][2] = pictureBox78;
            resultPegs[17][3] = pictureBox77;
            resultPegs[17][4] = pictureBox76;

            resultPegs[18][0] = pictureBox75;
            resultPegs[18][1] = pictureBox74;
            resultPegs[18][2] = pictureBox73;
            resultPegs[18][3] = pictureBox72;
            resultPegs[18][4] = pictureBox71;

            resultPegs[19][0] = pictureBox70;
            resultPegs[19][1] = pictureBox69;
            resultPegs[19][2] = pictureBox68;
            resultPegs[19][3] = pictureBox67;
            resultPegs[19][4] = pictureBox66;

            /*
            PictureBox[] resultPegs = new PictureBox[5];
            resultPegs[0] = pictureBox1;
            resultPegs[1] = pictureBox2;
            resultPegs[2] = pictureBox3;
            resultPegs[3] = pictureBox4;
            resultPegs[4] = pictureBox5;
            */
        }


        private void PopupColorForm(object sender, EventArgs e)
        {
            Form2 popupform = new Form2();
            colorButton = (Button)sender;
            popupform.Show();
            
        }

        //submit button
        private void button1_Click(object sender, EventArgs e)
        {
            
            int[] pegs = new int[5];
            pegs[0] = 0;
            pegs[1] = 1;
            pegs[2] = 1;
            pegs[3] = 2;
            pegs[4] = 2;
            setResultPegColors(pegs, 0);
            
            Button b = (Button)sender;
            b.Enabled = false;
            button12.Enabled = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int[] pegs = new int[5];
            pegs[0] = 0;
            pegs[1] = 1;
            pegs[2] = 1;
            pegs[3] = 2;
            pegs[4] = 2;
            setResultPegColors(pegs, 1);
            
            Button b = (Button)sender;
            b.Enabled = false;
            button18.Enabled = true;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            button24.Enabled = true;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            button30.Enabled = true;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            button36.Enabled = true;
        }

        private void button36_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            button42.Enabled = true;
        }

        private void button42_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            button48.Enabled = true;
        }

        private void button48_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            button54.Enabled = true;
        }

        private void button54_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            button60.Enabled = true;
        }

        private void button60_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            button66.Enabled = true;
        }

        private void button66_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            button72.Enabled = true;
        }

        private void button72_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            button78.Enabled = true;
        }

        private void button78_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            button120.Enabled = true;
        }

        private void button120_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            button114.Enabled = true;
        }

        private void button114_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            button108.Enabled = true;
        }

        private void button108_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            button102.Enabled = true;
        }

        private void button102_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            button96.Enabled = true;
        }

        private void button96_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            button90.Enabled = true;
        }

        private void button90_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            button84.Enabled = true;
        }

        private void button84_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;

            Form3 gameEndForm = new Form3();
            gameEndForm.Show();
        }

        public void setResultPegColors(int[] pegNums, int rowNum)
        {
            for(int i = 0; i < 5; i++)
            {
                switch(pegNums[i])
                {
                    case 0:
                        //white
                        resultPegs[rowNum][i].Image = Image.FromFile("C:\\Users\\Benjamin\\Pictures\\WhitePeg.png");
                        break;
                    case 1:
                        //silver
                        resultPegs[rowNum][i].Image = Image.FromFile("C:\\Users\\Benjamin\\Pictures\\SilverPeg.png");
                        break;
                    case 2:
                        //black
                        resultPegs[rowNum][i].Image = Image.FromFile("C:\\Users\\Benjamin\\Pictures\\BlackPeg.png");
                        break;
                }
            }
        }
    }
}
