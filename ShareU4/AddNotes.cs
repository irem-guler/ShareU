using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ShareU4
{
    public partial class AddNotes: Form
    {
        public AddNotes()
        {
            InitializeComponent();
        }
        public string NotesStudentNumber;
        private string _university;
        ConnectionLink db = new ConnectionLink();
        private void AddNotes_Load(object sender, EventArgs e)
        {

            cmbSubject.IntegralHeight = false;
            cmbSubject.MaxDropDownItems = 10;
            cmbSubject.SelectedIndex = 0;
            SqlCommand cmd = new SqlCommand("select FullName,University from Users where StudentNumber=@p1", db.GetConnection());
            cmd.Parameters.AddWithValue("@p1", NotesStudentNumber);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lblStudentName.Text = dr[0].ToString() + " (" + dr[1].ToString() + ")";
                _university = dr[1].ToString();
            }
            this.DoubleBuffered = true;
            EnableDoubleBuffer(panel1);
            EnableDoubleBuffer(panel2);
            currentC1 = Color.FromArgb(173, 216, 230);
            currentC2 = Color.FromArgb(72, 201, 176);

            targetC1 = currentC1;
            targetC2 = currentC2;

            colorTimer.Interval = 15;
            colorTimer.Tick += ColorTimer_Tick;
            db.GetConnection().Close();
            txtTitle.Text = "Enter note title";
            txtTitle.ForeColor = Color.Gray;
            cmbSubject.SelectedIndex = 0;
        }
        private void EnableDoubleBuffer(Control c)
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, c, new object[] { true });
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select a file to upload";
            ofd.Filter = "All Files|*.*|PDF Files|*.pdf|Word Files|*.docx";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string dosyaYolu = ofd.FileName;
                string dosyaAdi = Path.GetFileName(dosyaYolu);
                byte[] bytes = File.ReadAllBytes(dosyaYolu);

                
                int userId = -1; 
                SqlCommand cmd1 = new SqlCommand("SELECT UserID FROM Users WHERE StudentNumber = @no", db.GetConnection());
                cmd1.Parameters.AddWithValue("@no", NotesStudentNumber);

                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    userId = Convert.ToInt32(dr["UserID"]);
                }
                dr.Close();

                if (userId == -1)
                {
                    MessageBox.Show("User not found! Please check login.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.GetConnection().Close();
                    return; 
                }

                
                SqlCommand cmd = new SqlCommand(@"
            INSERT INTO Notes (UserID, University, Title, FileName, FileData, UploadDate,SubjectName)
            VALUES (@uid, @u, @t, @f, @d, @date,@s)", db.GetConnection());

                cmd.Parameters.AddWithValue("@uid", userId);
                cmd.Parameters.AddWithValue("@t", txtTitle.Text);
                cmd.Parameters.AddWithValue("@f", dosyaAdi);
                cmd.Parameters.Add("@d", SqlDbType.VarBinary).Value = bytes;
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@u", _university);
                cmd.Parameters.AddWithValue("@s", cmbSubject.Text);

                cmd.ExecuteNonQuery();
                db.GetConnection().Close();

                MessageBox.Show("Note uploaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
        }



        private void AddNotes_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(
            this.ClientRectangle,
            Color.FromArgb(173, 216, 230),
            Color.FromArgb(255, 253, 208), 90F);
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }
        Timer colorTimer = new Timer();
        Color currentC1, currentC2;
        Color targetC1, targetC2;
        Button activeButton;
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

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            activeButton = btnAdd;
            targetC1 = Color.FromArgb(173, 216, 230);
            targetC2 = Color.FromArgb(72, 201, 176);
            colorTimer.Start();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new LinearGradientBrush(
                panel2.ClientRectangle,
                Color.Aquamarine,
                Color.WhiteSmoke,
                LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(brush, panel2.ClientRectangle);
            }
            int cornerRadius = 10;
            System.Drawing.Drawing2D.GraphicsPath borderPath = new System.Drawing.Drawing2D.GraphicsPath();
            borderPath.StartFigure();
            borderPath.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            borderPath.AddArc(panel2.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            borderPath.AddArc(panel2.Width - cornerRadius, panel2.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            borderPath.AddArc(0, panel2.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            borderPath.CloseFigure();
            panel2.Region = new System.Drawing.Region(borderPath);
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.home__1__chill;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.home__1_;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int cornerRadius = 20;
            System.Drawing.Drawing2D.GraphicsPath borderPath = new System.Drawing.Drawing2D.GraphicsPath();
            borderPath.StartFigure();
            borderPath.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            borderPath.AddArc(panel1.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            borderPath.AddArc(panel1.Width - cornerRadius, panel1.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            borderPath.AddArc(0, panel1.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            borderPath.CloseFigure();
            panel1.Region = new System.Drawing.Region(borderPath);
        }
        private void comboBox1_Enter(object sender, EventArgs e)
        {
            if(cmbSubject.ForeColor == Color.Gray)
            {
                cmbSubject.ForeColor = Color.Black;
            }
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if(cmbSubject.ForeColor == Color.Black)
                            {
                cmbSubject.ForeColor = Color.Gray;
            }
        }

        private void txtTitle_Enter(object sender, EventArgs e)
        {
            if (txtTitle.Text == "Enter note title")
            {
                txtTitle.Text = "";
                txtTitle.ForeColor = Color.Black;
            }
        }

        private void txtTitle_Leave(object sender, EventArgs e)
        {
            if (txtTitle.Text == "")
            {
                txtTitle.Text = "Enter note title";
                txtTitle.ForeColor = Color.Gray;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainForm frm = new MainForm();
            frm.StudentNumber = NotesStudentNumber;
            this.Hide();
        }
        ToolTip toolTip1 = new ToolTip();   
        private void cmbSubject_MouseMove(object sender, MouseEventArgs e)
        {
            int index = cmbSubject.SelectedIndex;
            if (index >= 0)
            {
                string text = cmbSubject.Items[index].ToString();
                toolTip1.SetToolTip(cmbSubject, text);
            }
        }

        private void btnAdd_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(
            btnAdd.ClientRectangle, currentC1, currentC2,
            LinearGradientMode.Horizontal);
            e.Graphics.FillRectangle(brush, btnAdd.ClientRectangle);
            TextRenderer.DrawText(e.Graphics, btnAdd.Text, btnAdd.Font,
            btnAdd.ClientRectangle, Color.White,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int cornerRadius = 10;
            System.Drawing.Drawing2D.GraphicsPath borderPath = new System.Drawing.Drawing2D.GraphicsPath();
            borderPath.StartFigure();
            borderPath.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            borderPath.AddArc(btnAdd.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            borderPath.AddArc(btnAdd.Width - cornerRadius, btnAdd.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            borderPath.AddArc(0, btnAdd.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            borderPath.CloseFigure();
            btnAdd.Region = new System.Drawing.Region(borderPath);
        }

        private void btnAdd_MouseEnter(object sender, EventArgs e)
        {
            activeButton = btnAdd;
            targetC1 = Color.FromArgb(59, 130, 246);
            targetC2 = Color.FromArgb(34, 211, 238);
            colorTimer.Start();
        }
    }
}
