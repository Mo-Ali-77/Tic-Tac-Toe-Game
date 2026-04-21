using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeGameProject
{
    public partial class frmTicTacToe : Form
    {
        public frmTicTacToe()
        {
            InitializeComponent();
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
    }
}
