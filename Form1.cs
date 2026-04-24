using System;
using System.Drawing;
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

        enum enPlayer
        {
            player1, player2
        }

        enum enWinner
        {
            player1, player2, Draw,GameInProgress
        }

        struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public short PlayCount;
        }

        stGameStatus GameStatus;
        enPlayer PlayerTurn = enPlayer.player1;

        void EndGame()
        {

            labTurnPlayer.Text = "Game Over";
            switch (GameStatus.Winner)
            {

                case enWinner.player1:

                    labWhoWinner.Text = "Player1";
                    break;

                case enWinner.player2:

                    labWhoWinner.Text = "Player2";
                    break;

                default:

                    labWhoWinner.Text = "Draw";
                    break;

            }

            MessageBox.Show("GameOver", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DisablePlay();
        }

        bool CheckedWinnerXorO(PictureBox Pb1, PictureBox Pb2, PictureBox Pb3)
        {
            if (Pb1.Tag.ToString() != "?" && Pb1.Tag.ToString() == Pb2.Tag.ToString() && Pb1.Tag.ToString() == Pb3.Tag.ToString())
            {
                Pb1.BackColor = Color.DimGray;
                Pb2.BackColor = Color.DimGray;
                Pb3.BackColor = Color.DimGray;
                
                if(Pb1.Tag.ToString() == "X")
                {
                    GameStatus.Winner = enWinner.player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
                else
                {
                    GameStatus.Winner = enWinner.player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
            }

            GameStatus.GameOver = false;
            return false;
        }

        void WhoIsWinner()
        {
            if ((CheckedWinnerXorO(pictureBox1, pictureBox2, pictureBox3) )
                || (CheckedWinnerXorO(pictureBox4, pictureBox5, pictureBox6))
                || (CheckedWinnerXorO(pictureBox7, pictureBox8, pictureBox9))
                || (CheckedWinnerXorO(pictureBox1, pictureBox4, pictureBox7))
                || (CheckedWinnerXorO(pictureBox2, pictureBox5, pictureBox8))
                || (CheckedWinnerXorO(pictureBox3, pictureBox6, pictureBox9))
                || (CheckedWinnerXorO(pictureBox1, pictureBox5, pictureBox9))
                || (CheckedWinnerXorO(pictureBox3, pictureBox5, pictureBox7)))
            {
                return;
            }
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

        bool IsDraw()
        {
            if (GameStatus.PlayCount == 9 && GameStatus.Winner == enWinner.GameInProgress)
            {
                GameStatus.GameOver = true;
                GameStatus.Winner = enWinner.Draw;
                EndGame();
            }

            return false;
        }

        void WhichPlayerChoseWhichPicture(PictureBox Pb)
        {
            if (Pb.Tag.ToString() == "?")
            {
                switch(PlayerTurn)
                {
                    case enPlayer.player1:
                        Pb.Image = Resources.X;
                        PlayerTurn = enPlayer.player2;
                        labTurnPlayer.Text = "Player 2";
                        GameStatus.PlayCount++;
                        Pb.Tag = "X";
                        WhoIsWinner();
                        break;
                    case enPlayer.player2:
                        Pb.Image = Resources.O;
                        PlayerTurn = enPlayer.player1;
                        labTurnPlayer.Text = "Player 1";
                        GameStatus.PlayCount++;
                        Pb.Tag = "O";
                        WhoIsWinner();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Wrong Choice", "Worng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (IsDraw())
            {
                labWhoWinner.Text = "Draw";
                labTurnPlayer.Text = "Game Over";

                if (MessageBox.Show("Game Over", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    DisablePlay();
                    return;
                }
            }
        }

        void RestartPictureBox(PictureBox Pb)
        {
            Pb.Image = Resources.question_mark_96;
            Pb.Enabled = true;
            Pb.Tag = "?";
            Pb.BackColor = Color.Transparent;

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

        // All X and O controllers trigger a single event.
        private void pictureBoxs_Click(object sender, EventArgs e)
        {
            WhichPlayerChoseWhichPicture((PictureBox)sender);
        }

        void RestartGame()
        {
            RestartPictureBox(pictureBox1);
            RestartPictureBox(pictureBox2);
            RestartPictureBox(pictureBox3);
            RestartPictureBox(pictureBox4);
            RestartPictureBox(pictureBox5);
            RestartPictureBox(pictureBox6);
            RestartPictureBox(pictureBox7);
            RestartPictureBox(pictureBox8);
            RestartPictureBox(pictureBox9);

            PlayerTurn = enPlayer.player1;
            labTurnPlayer.Text = "Player 1";
            GameStatus.PlayCount = 0;
            GameStatus.GameOver = false;
            GameStatus.Winner = enWinner.GameInProgress;
            labWhoWinner.Text = "In Progress";
        }

        private void btnResatrtGame_Click(object sender, EventArgs e)
        {
            RestartGame();
        }
    }
}
