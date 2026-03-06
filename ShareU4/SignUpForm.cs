using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;

namespace ShareU4
{
    public partial class SignUpForm: Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }
        ConnectionLink db = new ConnectionLink();
        private void SignUpForm_Load(object sender, EventArgs e)
        {
            cmbUniversity.IntegralHeight = false;
            cmbUniversity.MaxDropDownItems = 10;
            txtStudentNo.Text = "Student ID";
            txtStudentNo.ForeColor = Color.Gray;
            txtFullName.Text = "Full Name";
            txtFullName.ForeColor = Color.Gray;
            txtPassword.UseSystemPasswordChar = false;
            txtPassword.Text = "Password";
            txtPassword.ForeColor = Color.Gray;
            txtSafe.Text = "Safety Word";
            txtSafe.ForeColor = Color.Gray;
            cmbUniversity.SelectedIndex = 0;
            cmbUniversity.ForeColor = Color.Gray;
            currentC1 = Color.FromArgb(173, 216, 230);
            currentC2 = Color.FromArgb(72, 201, 176);

            targetC1 = currentC1;
            targetC2 = currentC2;

            colorTimer.Interval = 15;
            colorTimer.Tick += ColorTimer_Tick;
        }

        Timer colorTimer = new Timer();
        Color currentC1, currentC2;
        Color targetC1, targetC2;
        Button activeButton;
        ToolTip toolTip1 = new ToolTip();
        private void ColorTimer_Tick(object sender, EventArgs e)
        {
            currentC1 = Lerp(currentC1, targetC1);
            currentC2 = Lerp(currentC2, targetC2);

            activeButton.Invalidate();

            if (currentC1 == targetC1 && currentC2 == targetC2)
                colorTimer.Stop();
        }

        Color Lerp(Color from, Color to)
        {
            int r = from.R + (to.R - from.R) / 5;
            int g = from.G + (to.G - from.G) / 5;
            int b = from.B + (to.B - from.B) / 5;
            return Color.FromArgb(r, g, b);
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if(txtFullName.Text == "" || txtStudentNo.Text == "" || cmbUniversity.Text == "" || txtPassword.Text == "" || txtSafe.Text == "" || cmbUniversity.Text == "Please Choose a University...")
            {
                MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!txtStudentNo.Text.All(char.IsDigit))
            {
                MessageBox.Show("Student Number must contain only digits!",
                                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtStudentNo.Text.Length != 8)
            {
                MessageBox.Show("Student Number must be 8 characters long.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (txtPassword.Text.Length < 4)
            {
                MessageBox.Show("Password must be at least 4 characters long.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SqlCommand cmd1 = new SqlCommand("SELECT COUNT(*) FROM Users WHERE StudentNumber = @p", db.GetConnection());
            cmd1.Parameters.AddWithValue("@p", txtStudentNo.Text);
            int count = (int)cmd1.ExecuteScalar();
            if (count > 0)
                {
                    db.GetConnection().Close();
                    MessageBox.Show("This student number is already registered!",
                                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }
            SqlCommand cmd = new SqlCommand("insert into Users (FullName,StudentNumber,University,Password,SafeWord) values(@p1,@p2,@p3,@p4,@p5)", db.GetConnection());
            cmd.Parameters.AddWithValue("@p1", txtFullName.Text);
            cmd.Parameters.AddWithValue("@p2", txtStudentNo.Text);
            cmd.Parameters.AddWithValue("@p3", cmbUniversity.Text);
            cmd.Parameters.AddWithValue("@p4", txtPassword.Text);
            cmd.Parameters.AddWithValue("@p5", txtSafe.Text);
            cmd.ExecuteNonQuery();
            db.GetConnection().Close();
            MessageBox.Show("Registration Successful! You can now sign in.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SignInForm frm = new SignInForm();
            frm.Show();
            this.Hide();
        }


        private void cmbUniversity_MouseMove(object sender, MouseEventArgs e)
        {
            int index = cmbUniversity.SelectedIndex;
            if (index >= 0)
            {
                string text = cmbUniversity.Items[index].ToString();
                toolTip1.SetToolTip(cmbUniversity, text);
            }
        }

        private void SignUpForm_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(
            this.ClientRectangle,
            Color.FromArgb(173, 216, 230),
            Color.FromArgb(255, 253, 208), 90F);
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int radius = 40;

            System.Drawing.Drawing2D.GraphicsPath border = new System.Drawing.Drawing2D.GraphicsPath();
            border.StartFigure();

            border.AddArc(0, 0, radius, radius, 180, 90);
            border.AddArc(panel1.Width - radius, 0, radius, radius, 270, 90);
            border.AddArc(panel1.Width - radius, panel1.Height - radius, radius, radius, 0, 90);
            border.AddArc(0, panel1.Height - radius, radius, radius, 90, 90);

            border.CloseFigure();

            panel1.Region = new System.Drawing.Region(border);
        }

        private void btnSignUp_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(
            btnSignUp.ClientRectangle, currentC1, currentC2,
            LinearGradientMode.Horizontal);
            e.Graphics.FillRectangle(brush, btnSignUp.ClientRectangle);
            TextRenderer.DrawText(e.Graphics, btnSignUp.Text, btnSignUp.Font,
            btnSignUp.ClientRectangle, Color.White,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int cornerRadius = 10;
            System.Drawing.Drawing2D.GraphicsPath borderPath = new System.Drawing.Drawing2D.GraphicsPath();
            borderPath.StartFigure();
            borderPath.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            borderPath.AddArc(btnSignUp.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            borderPath.AddArc(btnSignUp.Width - cornerRadius, btnSignUp.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            borderPath.AddArc(0, btnSignUp.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            borderPath.CloseFigure();
            btnSignUp.Region = new System.Drawing.Region(borderPath);
        }



        private void txtStudentNo_Enter(object sender, EventArgs e)
        {
            if (txtStudentNo.Text == "Student ID")
            {
                txtStudentNo.Text = "";
                txtStudentNo.ForeColor = Color.Black;
            }
        }

        private void txtStudentNo_Leave(object sender, EventArgs e)
        {
            if (txtStudentNo.Text == "")
            {
                txtStudentNo.Text = "Student ID";
                txtStudentNo.ForeColor = Color.Gray;
            }
        }

        private void txtFullName_Enter(object sender, EventArgs e)
        {
            if (txtFullName.Text == "Full Name")
            {
                txtFullName.Text = "";
                txtFullName.ForeColor = Color.Black;
            }
        }

        private void txtFullName_Leave(object sender, EventArgs e)
        {
            if (txtFullName.Text == "")
            {
                txtFullName.Text = "Full Name";
                txtFullName.ForeColor = Color.Gray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.Gray;
            }
        }

        private void txtSafe_Enter(object sender, EventArgs e)
        {
            if (txtSafe.Text == "Safety Word")
            {
                txtSafe.Text = "";
                txtSafe.ForeColor = Color.Black;
            }
        }

        private void txtSafe_Leave(object sender, EventArgs e)
        {
            if (txtSafe.Text == "")
            {
                txtSafe.Text = "Safety Word";
                txtSafe.ForeColor = Color.Gray;
            }
        }

        private void btnSignUp_MouseEnter(object sender, EventArgs e)
        {
            activeButton = btnSignUp;
            targetC1 = Color.FromArgb(59, 130, 246);
            targetC2 = Color.FromArgb(34, 211, 238);
            colorTimer.Start();
        }

        private void btnSignUp_MouseLeave(object sender, EventArgs e)
        {
            activeButton = btnSignUp;
            targetC1 = Color.FromArgb(173, 216, 230);
            targetC2 = Color.FromArgb(72, 201, 176);
            colorTimer.Start();
        }

        private void btnSignIn_MouseEnter(object sender, EventArgs e)
        {
            activeButton = btnSignIn;
            targetC1 = Color.FromArgb(59, 130, 246);
            targetC2 = Color.FromArgb(34, 211, 238);
            colorTimer.Start();
        }

        private void btnSignIn_MouseLeave(object sender, EventArgs e)
        {
            activeButton = btnSignIn;
            targetC1 = Color.FromArgb(173, 216, 230);
            targetC2 = Color.FromArgb(72, 201, 176);
            colorTimer.Start();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            SignInForm frm = new SignInForm();
            frm.Show();
            this.Hide();
        }

        private void btnSignIn_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(
            btnSignIn.ClientRectangle, currentC1, currentC2,
            LinearGradientMode.Horizontal);
            e.Graphics.FillRectangle(brush, btnSignIn.ClientRectangle);
            TextRenderer.DrawText(e.Graphics, btnSignIn.Text, btnSignIn.Font,
            btnSignIn.ClientRectangle, Color.White,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int cornerRadius = 10;
            System.Drawing.Drawing2D.GraphicsPath borderPath = new System.Drawing.Drawing2D.GraphicsPath();
            borderPath.StartFigure();
            borderPath.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            borderPath.AddArc(btnSignIn.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            borderPath.AddArc(btnSignIn.Width - cornerRadius, btnSignIn.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            borderPath.AddArc(0, btnSignIn.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            borderPath.CloseFigure();
            btnSignIn.Region = new System.Drawing.Region(borderPath);
        }

        private void cmbUniversity_Enter(object sender, EventArgs e)
        {
            if (cmbUniversity.ForeColor == Color.Gray)
            {
                cmbUniversity.ForeColor = Color.Black;
            }
        }

        private void cmbUniversity_Leave(object sender, EventArgs e)
        {
            if (cmbUniversity.SelectedIndex == -1)
            {
                cmbUniversity.ForeColor = Color.Gray;
            }
        }
    }
}
