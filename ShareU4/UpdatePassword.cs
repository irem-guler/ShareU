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
    public partial class UpdatePassword: Form
    {
        public UpdatePassword()
        {
            InitializeComponent();
        }

        ConnectionLink db = new ConnectionLink();
        private void UpdatePassword_Load(object sender, EventArgs e)
        {
            txtID.Text = "Student ID";
            txtID.ForeColor = Color.Gray;
            txtSafeWord.Text = "Safety Word";
            txtSafeWord.ForeColor = Color.Gray;
            txtNewPassword.UseSystemPasswordChar = false;
            txtNewPassword.Text = "New Password";
            txtNewPassword.ForeColor = Color.Gray;

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

        private void txtID_Enter(object sender, EventArgs e)
        {
            if(txtID.Text == "Student ID")
            {
                txtID.Text = "";
                txtID.ForeColor = Color.Black;
            }
        }

        private void txtSafeWord_Enter(object sender, EventArgs e)
        {
            if (txtSafeWord.Text == "Safety Word")
            {
                txtSafeWord.Text = "";
                txtSafeWord.ForeColor = Color.Black;
            }
        }

        private void txtNewPassword_Enter(object sender, EventArgs e)
        {
            if (txtNewPassword.Text == "New Password")
            {
                txtNewPassword.Text = "";
                txtNewPassword.ForeColor = Color.Black;
                txtNewPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                txtID.Text = "Student ID";
                txtID.ForeColor = Color.Gray;
            }
        }

        private void txtSafeWord_Leave(object sender, EventArgs e)
        {
            if (txtSafeWord.Text == "")
            {
                txtSafeWord.Text = "Safety Word";
                txtSafeWord.ForeColor = Color.Gray;
            }
        }

        private void txtNewPassword_Leave(object sender, EventArgs e)
        {
            if (txtNewPassword.Text == "")
            {
                txtNewPassword.UseSystemPasswordChar = false;
                txtNewPassword.Text = "New Password";
                txtNewPassword.ForeColor = Color.Gray;
            }
        }

        private void btnReset_MouseEnter(object sender, EventArgs e)
        {
            activeButton = btnReset;
            targetC1 = Color.FromArgb(59, 130, 246);
            targetC2 = Color.FromArgb(34, 211, 238);
            colorTimer.Start();
        }

        private void btnReset_MouseLeave(object sender, EventArgs e)
        {
            activeButton = btnReset;
            targetC1 = Color.FromArgb(173, 216, 230);
            targetC2 = Color.FromArgb(72, 201, 176);
            colorTimer.Start();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "Student ID" || txtSafeWord.Text == "Safety Word" || txtNewPassword.Text == "New Password" || txtID.Text == "" || txtSafeWord.Text == "" || txtNewPassword.Text == "")
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!txtID.Text.All(char.IsDigit))
            {
                MessageBox.Show("Student Number must contain only digits!",
                                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtNewPassword.Text.Length < 4)
            {
                MessageBox.Show("New Password must be at least 4 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SqlCommand cmd = new SqlCommand("select * from Users where StudentNumber=@p1 and SafeWord=@p2", db.GetConnection());
            cmd.Parameters.AddWithValue("@p1", txtID.Text);
            cmd.Parameters.AddWithValue("@p2", txtSafeWord.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                dr.Close();
                SqlCommand updateCmd = new SqlCommand("update Users set Password=@p3 where StudentNumber=@p1 and SafeWord=@p2", db.GetConnection());
                updateCmd.Parameters.AddWithValue("@p1", txtID.Text);
                updateCmd.Parameters.AddWithValue("@p2", txtSafeWord.Text);
                updateCmd.Parameters.AddWithValue("@p3", txtNewPassword.Text);
                updateCmd.ExecuteNonQuery();
                MessageBox.Show("Password has been successfully updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Student ID or Safe Word. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            db.GetConnection().Close();
        }

        private void UpdatePassword_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(
            this.ClientRectangle,
            Color.FromArgb(173, 216, 230),
            Color.FromArgb(255, 253, 208), 90F);
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }

        private void btnReset_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(
            btnReset.ClientRectangle, currentC1, currentC2,
            LinearGradientMode.Horizontal);
            e.Graphics.FillRectangle(brush, btnReset.ClientRectangle);
            TextRenderer.DrawText(e.Graphics, btnReset.Text, btnReset.Font,
            btnReset.ClientRectangle, Color.White,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int cornerRadius = 10;
            System.Drawing.Drawing2D.GraphicsPath borderPath = new System.Drawing.Drawing2D.GraphicsPath();
            borderPath.StartFigure();
            borderPath.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            borderPath.AddArc(btnReset.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            borderPath.AddArc(btnReset.Width - cornerRadius, btnReset.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            borderPath.AddArc(0, btnReset.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            borderPath.CloseFigure();
            btnReset.Region = new System.Drawing.Region(borderPath);
        }
    }
}
