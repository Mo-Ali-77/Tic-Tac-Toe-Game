using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToeGameProject.Properties;

namespace TicTacToeGameProject
{
    public partial class frmTicTacToe : Form
    {
        public frmTicTacToe()
        {
            InitializeComponent();
        }

        bool IsPictureBoxChosed(PictureBox Pb)
        {
            return (Pb.Tag.ToString() == "O") || (Pb.Tag.ToString() == "X");
        }

        string CheckedWinnerXorO(PictureBox Pb1, PictureBox Pb2, PictureBox Pb3)
        {
            if ((Pb1.Tag.ToString() == "X") && (Pb2.Tag.ToString() == "X") && (Pb3.Tag.ToString() == "X"))
            {
                return "X";
            }

            if ((Pb1.Tag.ToString() == "O") && (Pb2.Tag.ToString() == "O") && (Pb3.Tag.ToString() == "O"))
            {
                return "O";
            }

            return "";
        }

        string WhoIsWinner()
        {
            if ((CheckedWinnerXorO(pictureBox1, pictureBox2, pictureBox3) == "X")
                || (CheckedWinnerXorO(pictureBox4, pictureBox5, pictureBox6) == "X")
                || (CheckedWinnerXorO(pictureBox7, pictureBox8, pictureBox9) == "X")
                || (CheckedWinnerXorO(pictureBox1, pictureBox4, pictureBox7) == "X")
                || (CheckedWinnerXorO(pictureBox2, pictureBox5, pictureBox8) == "X")
                || (CheckedWinnerXorO(pictureBox3, pictureBox6, pictureBox9) == "X")
                || (CheckedWinnerXorO(pictureBox1, pictureBox5, pictureBox9) == "X")
                || (CheckedWinnerXorO(pictureBox3, pictureBox5, pictureBox7) == "X"))
            {
                return "Player 1";
            }

            if ((CheckedWinnerXorO(pictureBox1, pictureBox2, pictureBox3) == "O")
                || (CheckedWinnerXorO(pictureBox4, pictureBox5, pictureBox6) == "O")
                || (CheckedWinnerXorO(pictureBox7, pictureBox8, pictureBox9) == "O")
                || (CheckedWinnerXorO(pictureBox1, pictureBox4, pictureBox7) == "O")
                || (CheckedWinnerXorO(pictureBox2, pictureBox5, pictureBox8) == "O")
                || (CheckedWinnerXorO(pictureBox3, pictureBox6, pictureBox9) == "O")
                || (CheckedWinnerXorO(pictureBox1, pictureBox5, pictureBox9) == "O")
                || (CheckedWinnerXorO(pictureBox3, pictureBox5, pictureBox7) == "O"))
            {
                return "Player 2";
            }

            return "";
        }

        void DisablePlay()
        {
            pictureBox1.Enabled = false;
            pictureBox2.Enabled = false;
            pictureBox3.Enabled = false;
            pictureBox4.Enabled = false;
            pictureBox5.Enabled = false;
            pictureBox6.Enabled = false;
            pictureBox7.Enabled = false;
            pictureBox8.Enabled = false;
            pictureBox9.Enabled = false;
        }

        void WhichPlayerChoseWhichPicture(PictureBox Pb,Label TurnPlayer)
        {
            if (TurnPlayer.Text == "Player 1")
            {
                if (IsPictureBoxChosed(Pb))
                {
                    MessageBox.Show("Wrong Choice", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Pb.Image = Resources.X;
                Pb.Tag = "X";

                // After each click, we check all possible winning options.
                if (WhoIsWinner() == "Player 1")
                {
                    labWhoWinner.Text = "Player 1";
                    labTurnPlayer.Text = "Game Over";

                    if(MessageBox.Show("Game Over", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
                    {
                        DisablePlay();
                        return;
                    }
                }



                labTurnPlayer.Text = "Player 2";
            }
            else
            {
                if (IsPictureBoxChosed(Pb))
                {
                    MessageBox.Show("Wrong Choice","Wrong",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Pb.Image = Resources.O;
                Pb.Tag = "O";

                // After each click, we check all possible winning options.
                if (WhoIsWinner() == "Player 2")
                {
                    labWhoWinner.Text = "Player 2";
                    labTurnPlayer.Text = "Game Over";

                    if (MessageBox.Show("Game Over", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
                    {
                        DisablePlay();
                        return;
                    }
                }

                labTurnPlayer.Text = "Player 1";
            }
        }

        void RestartGame()
        {
            pictureBox1.Image = Resources.question_mark_96;
            pictureBox2.Image = Resources.question_mark_96;
            pictureBox3.Image = Resources.question_mark_96;
            pictureBox4.Image = Resources.question_mark_96;
            pictureBox5.Image = Resources.question_mark_96;
            pictureBox6.Image = Resources.question_mark_96;
            pictureBox7.Image = Resources.question_mark_96;
            pictureBox8.Image = Resources.question_mark_96;
            pictureBox9.Image = Resources.question_mark_96;

            pictureBox1.Enabled = true;
            pictureBox2.Enabled = true;
            pictureBox3.Enabled = true;
            pictureBox4.Enabled = true;
            pictureBox5.Enabled = true;
            pictureBox6.Enabled = true;
            pictureBox7.Enabled = true;
            pictureBox8.Enabled = true;
            pictureBox9.Enabled = true;

            pictureBox1.Tag = "";
            pictureBox2.Tag = "";
            pictureBox3.Tag = "";
            pictureBox4.Tag = "";
            pictureBox5.Tag = "";
            pictureBox6.Tag = "";
            pictureBox7.Tag = "";
            pictureBox8.Tag = "";
            pictureBox9.Tag = "";

            labTurnPlayer.Text = "Player 1";
            labWhoWinner.Text = "In Progress";
        }

        private void frmTicTacToe_Paint(object sender, PaintEventArgs e)
        {
            Color Turquoise = Color.FromArgb(100, 255, 255, 255);
            Pen Pen = new Pen(Turquoise);
            Pen.Width = 10;

            Pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            Pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            //e.Graphics.DrawLine(Pen, 500, 100, 100, 200);
            // لتسهيل الكود، سنفترض أسماء المربعات كالتالي (تأكد من مطابقتها لأسماء عناصرك):
            // pictureBox1 (أعلى يسار)  -- pictureBox2 (أعلى وسط)
            // pictureBox4 (وسط يسار)
            // pictureBox7 (أسفل يسار)  -- pictureBox9 (أسفل يمين)

            // حساب بداية ونهاية الخطوط عمودياً وأفقياً
            int topY = pictureBox1.Top;
            int leftX = pictureBox1.Left;
            int bottomY = pictureBox7.Bottom;
            int rightX = pictureBox3.Right;

            // 2. رسم الخطوط العمودية
            // الخط العمودي الأول (بين العمود الأول والثاني)
            int vLine1_X = pictureBox1.Right + ((pictureBox2.Left - pictureBox1.Right) / 2);
            e.Graphics.DrawLine(Pen, vLine1_X, topY, vLine1_X, bottomY);

            // الخط العمودي الثاني (بين العمود الثاني والثالث)
            int vLine2_X = pictureBox2.Right + ((pictureBox3.Left - pictureBox2.Right) / 2);
            e.Graphics.DrawLine(Pen, vLine2_X, topY, vLine2_X, bottomY);

            // 3. رسم الخطوط الأفقية
            // الخط الأفقي الأول (بين الصف الأول والثاني)
            int hLine1_Y = pictureBox1.Bottom + ((pictureBox4.Top - pictureBox1.Bottom) / 2);
            e.Graphics.DrawLine(Pen, leftX, hLine1_Y, rightX, hLine1_Y);

            // الخط الأفقي الثاني (بين الصف الثاني والثالث)
            int hLine2_Y = pictureBox4.Bottom + ((pictureBox7.Top - pictureBox4.Bottom) / 2);
            e.Graphics.DrawLine(Pen, leftX, hLine2_Y, rightX, hLine2_Y);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            WhichPlayerChoseWhichPicture((PictureBox)sender, labTurnPlayer);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WhichPlayerChoseWhichPicture((PictureBox)sender, labTurnPlayer);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WhichPlayerChoseWhichPicture((PictureBox)sender, labTurnPlayer);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            WhichPlayerChoseWhichPicture((PictureBox)sender, labTurnPlayer);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            WhichPlayerChoseWhichPicture((PictureBox)sender, labTurnPlayer);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            WhichPlayerChoseWhichPicture((PictureBox)sender, labTurnPlayer);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            WhichPlayerChoseWhichPicture((PictureBox)sender, labTurnPlayer);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            WhichPlayerChoseWhichPicture((PictureBox)sender, labTurnPlayer);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            WhichPlayerChoseWhichPicture((PictureBox)sender, labTurnPlayer);
        }

        private void btnResatrtGame_Click(object sender, EventArgs e)
        {
            RestartGame();
        }
    }
}
