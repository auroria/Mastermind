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
    public partial class MastermindBoardForm : Form
    {

        ButtonRow[] rows = new ButtonRow[20];
        Button[] colorBtns = new Button[10];
        Button currentBtn = new Button();
        public bool[] colorButtonSettings = new bool[5] { false, false, false, false, false };
        public Colors[] guess = new Colors[5];
        Mastermind.Mastermind mastermind = new Mastermind.Mastermind();

        Form colorSelectForm = new Form();

        public class ButtonRow
        {
            public Button submitBtn;
            public Button[] colorBtns = new Button[5];
            public PictureBox[] pegs = new PictureBox[5];


            public ButtonRow(int rowNum, int xpos, int ypos, string name, EventHandler submitCallback, EventHandler colorCallback)
            {
                submitBtn = new Button();
                submitBtn.Text = "Submit";
                submitBtn.Location = new Point(xpos + 10, ypos + 10);
                submitBtn.Size = new Size(80, 40);
                submitBtn.Enabled = false;
                submitBtn.Click += submitCallback;
                submitBtn.Name = name;

                for (int i = 0; i < 5; i++)
                {
                    colorBtns[i] = new Button();
                    colorBtns[i].Size = new Size(40, 40);
                    colorBtns[i].Image = Properties.Resources.EmptyButton30;
                    colorBtns[i].ImageAlign = ContentAlignment.MiddleCenter;
                    colorBtns[i].Name = (rowNum * 10 + i).ToString();
                    colorBtns[i].Enabled = false;

                    colorBtns[i].Location = new Point(submitBtn.Location.X + submitBtn.Width + 10 + (i * (40 + 10)), ypos + 10);
                    colorBtns[i].Click += colorCallback;
                }

                for (int i = 0; i < 5; i++)
                {
                    pegs[i] = new PictureBox();
                    pegs[i].Size = new Size(25, 25);
                    pegs[i].Image = Properties.Resources.EmptyButton20;
                    pegs[i].Location = new Point(colorBtns[4].Location.X + colorBtns[4].Width + 10 + (i * (20 + 10)), ypos + 20);
                }
            }


            public void addControls(Form form)
            {
                form.Controls.Add(submitBtn);
                for (int i = 0; i < 5; i++)
                {
                    form.Controls.Add(colorBtns[i]);
                }

                for (int i = 0; i < 5; i++)
                {
                    form.Controls.Add(pegs[i]);
                }
            }
        }

        //------------------------------------------------------------
        public MastermindBoardForm()
        {
            InitializeComponent();
            this.Size = new Size(600, 800);
            this.AutoScroll = true;
        }

        private void MastermindBoardForm_Load(object sender, EventArgs e)
        {
            //Initialize Mastermind game
            mastermind.SetColorSelection();

            //add button rows to form
            for (int i = 0; i < 20; i++)
            {
                rows[i] = new ButtonRow(i, 10, 10 + (i * 70), i.ToString(), submitBtnClick, colorBtnClick);
                rows[i].addControls(this);
            }

            rows[0].submitBtn.Enabled = true;

            for (int i = 0; i < 5; i++)
            {
                rows[0].colorBtns[i].Enabled = true;
            }

            //add color buttons to popup form
            colorSelectForm.Size = new Size(540, 140);

            for (int i = 0; i < 10; i++)
            {
                colorBtns[i] = new Button();
                colorBtns[i].Size = new Size(40, 40);
                switch (i)
                {
                    case 0:
                        colorBtns[i].Image = Properties.Resources.RedButton30;
                        break;
                    case 1:
                        colorBtns[i].Image = Properties.Resources.BlueButton30;
                        break;
                    case 2:
                        colorBtns[i].Image = Properties.Resources.YellowButton30;
                        break;
                    case 3:
                        colorBtns[i].Image = Properties.Resources.GreenButton30;
                        break;
                    case 4:
                        colorBtns[i].Image = Properties.Resources.PurpleButton30;
                        break;
                    case 5:
                        colorBtns[i].Image = Properties.Resources.OrangeButton30;
                        break;
                    case 6:
                        colorBtns[i].Image = Properties.Resources.PinkButton30;
                        break;
                    case 7:
                        colorBtns[i].Image = Properties.Resources.BlackButton30;
                        break;
                    case 8:
                        colorBtns[i].Image = Properties.Resources.WhiteButton30;
                        break;
                    case 9:
                        colorBtns[i].Image = Properties.Resources.GreyButton30;
                        break;
                }

                colorBtns[i].Name = i.ToString();
                colorBtns[i].Location = new Point(10 + i * (40 + 10), 10);
                colorBtns[i].Click += colorSelectionClick;
                colorSelectForm.Controls.Add(colorBtns[i]);


            }

            //Add Done Button to Color Selector
            Button doneBtn = new Button();
            doneBtn.Text = "Done";
            doneBtn.Location = new Point(400, 60);
            doneBtn.Click += doneBtnClick;
            colorSelectForm.Controls.Add(doneBtn);
        }

        void doneBtnClick(Object sender, EventArgs e)
        {
            colorSelectForm.Hide();
        }


        void submitBtnClick(Object sender, EventArgs e)
        {
            Response[] response;
            bool fiveColors = true;

            //make sure user has to pick five colors
            for (int i = 0; i < 5 && fiveColors; i++)
            {
                if (colorButtonSettings[i] == false)
                {
                    fiveColors = false;
                }
            }
            if (fiveColors == true)
            {
                Button clickedButton = (Button)sender;
                clickedButton.Enabled = false;

                // get the row that was clicked
                int rowNum = Convert.ToInt32(clickedButton.Name);

                for (int i = 0; i < 5; i++)
                {
                    rows[rowNum].colorBtns[i].Click -= colorBtnClick;
                }

                //submit the guess
                response = mastermind.Guess(guess);

                //check the answer
                bool gameOver = true;

                for (int i = 0; i < 5 && gameOver; i++)
                {
                    if(response[i] != Response.MATCH_POSITION)
                    {
                        gameOver = false;
                    }
                }

                if (gameOver == false)
                {
                    int[] pegs = new int[5];
                    
                    //set the pegs
                    for(int i = 0; i < 5; i++)
                    {
                        switch(response[i])
                        {
                            case Response.NO_MATCH:
                                pegs[i] = 0;
                                break;
                            case Response.MATCH_COLOR:
                                pegs[i] = 1;
                                break;
                            case Response.MATCH_POSITION:
                                pegs[i] = 2;
                                break;
                        }
                    }
                    setPegs(rowNum, pegs);
                    
                    //go to the next row
                    rowNum++;

                    // enable the next row buttons
                    if (rowNum < 20)
                    {
                        rows[rowNum].submitBtn.Enabled = true;

                        for (int i = 0; i < 5; i++)
                        {
                            rows[rowNum].colorBtns[i].Enabled = true;
                        }

                        //clear the color button settings
                        for (int i = 0; i < 5; i++)
                        {
                            colorButtonSettings[i] = false;
                        }
                    }
                    else
                    {
                        String message = "You lost - you can try again by hitting the start button";

                        DialogResult result = MessageBox.Show(message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                {
                    String message = "You won!";

                    DialogResult result = MessageBox.Show(message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                String message = "You must make 5 color selections before submitting your guess";

                DialogResult result = MessageBox.Show(message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        void colorBtnClick(Object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            // get the color button that was clicked
            int colorNum = Convert.ToInt32(clickedButton.Name);

            //set the current button to the button that was clicked
            currentBtn = clickedButton;

            //popup the color selector
            colorSelectForm.Show();

        }
        void colorSelectionClick(Object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            // get the color button that was clicked
            int colorNum = Convert.ToInt32(clickedButton.Name);
            currentBtn.Image = null;

            //get the current button number
            int colorButtonNum = Convert.ToInt32(currentBtn.Name);
            colorButtonNum = colorButtonNum % 10;
            colorButtonSettings[colorButtonNum] = true;

            //set the current button to the color
            switch (colorNum)
            {
                case 0:
                    currentBtn.Image = Properties.Resources.RedButton30;
                    break;
                case 1:
                    currentBtn.Image = Properties.Resources.BlueButton30;
                    break;
                case 2:
                    currentBtn.Image = Properties.Resources.YellowButton30;
                    break;
                case 3:
                    currentBtn.Image = Properties.Resources.GreenButton30;
                    break;
                case 4:
                    currentBtn.Image = Properties.Resources.PurpleButton30;
                    break;
                case 5:
                    currentBtn.Image = Properties.Resources.OrangeButton30;
                    break;
                case 6:
                    currentBtn.Image = Properties.Resources.PinkButton30;
                    break;
                case 7:
                    currentBtn.Image = Properties.Resources.BlackButton30;
                    break;
                case 8:
                    currentBtn.Image = Properties.Resources.WhiteButton30;
                    break;
                case 9:
                    currentBtn.Image = Properties.Resources.GreyButton30;
                    break;
            }

            //set the guess
            guess[colorButtonNum] = (Colors)colorNum;
        }

        void setPegs(int row, int[] pegSettings)
        {
            Array.Sort(pegSettings);
            for (int i = 0; i < 5; i++)
            {
                switch (pegSettings[i])
                {
                    case 0:
                        rows[row].pegs[i].Image = Properties.Resources.WhiteButton20;
                        break;
                    case 1:
                        rows[row].pegs[i].Image = Properties.Resources.SilverButton20;
                        break;
                    case 2:
                        rows[row].pegs[i].Image = Properties.Resources.BlackButton20;
                        break;
                }
            }
        }

    }
}
