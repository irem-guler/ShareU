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
    public partial class SignInForm: Form
    {
        public SignInForm()
        {
            InitializeComponent();
        }
        ConnectionLink db = new ConnectionLink();
        private void SignInForm_Load(object sender, EventArgs e)
        {
            txtStudentNo.Text = "Student ID";
            txtStudentNo.ForeColor = Color.Gray;
            txtPassword.UseSystemPasswordChar = false;
            txtPassword.Text = "Password";
            txtPassword.ForeColor = Color.Gray;
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
        private void ColorTimer_Tick(object sender, EventArgs e)
        {
            currentC1 = Lerp(currentC1, targetC1);
            currentC2 = Lerp(currentC2, targetC2);

            activeButton.Refresh();

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
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Users where StudentNumber=@p1 and Password=@p2", db.GetConnection());
            cmd.Parameters.AddWithValue("@p1", txtStudentNo.Text);
            cmd.Parameters.AddWithValue("@p2", txtPassword.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                if (dr.Read())
                {
                    MainForm frm = new MainForm();
                    frm.StudentNumber = txtStudentNo.Text;
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Student Number or Password. Please try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }   
                db.GetConnection().Close();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void lnkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUpForm frm = new SignUpForm();
            frm.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
        private void SignInForm_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(
            this.ClientRectangle,
            Color.FromArgb(173,216,230), 
            Color.FromArgb(255,253,208),90F);                     
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
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

        private void lnkSignUp_MouseEnter(object sender, EventArgs e)
        {
            lnkSignUp.LinkColor = Color.DeepSkyBlue;
            lnkSignUp.ActiveLinkColor = Color.FromArgb(72, 201, 176);
        }

        private void lnkSignUp_MouseLeave(object sender, EventArgs e)
        {
            lnkSignUp.LinkColor = Color.FromArgb(72, 201, 176);
            lnkSignUp.ActiveLinkColor = Color.DeepSkyBlue;

        }

        private void lnkForgot_MouseEnter(object sender, EventArgs e)
        {
            lnkForgot.LinkColor = Color.DeepSkyBlue;
            lnkForgot.ActiveLinkColor = Color.Gray;
        }

        private void lnkForgot_MouseLeave(object sender, EventArgs e)
        {
            lnkForgot.LinkColor = Color.Gray;
            lnkForgot.ActiveLinkColor = Color.DeepSkyBlue;
        }

        private void lnkForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lnkForgot.Enabled = false;
            UpdatePassword frm = new UpdatePassword();
            frm.FormClosed += (s, args) =>
            {
                lnkForgot.Enabled = true;
            };
            frm.Show();
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
    }
}
