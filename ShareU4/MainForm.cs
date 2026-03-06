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
using System.IO;
using System.Drawing.Drawing2D;

namespace ShareU4
{
    public partial class MainForm: Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        Timer colorTimer = new Timer();
        Color currentC1, currentC2;
        Color targetC1, targetC2;
        Button activeButton;
        public string StudentNumber;
        ConnectionLink db = new ConnectionLink();
        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshUniversitySections();
            SqlCommand cmd = new SqlCommand("select FullName from Users where StudentNumber=@p1", db.GetConnection());
            cmd.Parameters.AddWithValue("@p1", StudentNumber);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lblName.Text = dr[0].ToString();
                lblName2.Text = dr[0].ToString();
            }
            db.GetConnection().Close();
            currentC1 = Color.FromArgb(173, 216, 230);
            currentC2 = Color.FromArgb(72, 201, 176);

            targetC1 = currentC1;
            targetC2 = currentC2;

            colorTimer.Interval = 15;
            colorTimer.Tick += ColorTimer_Tick;

        }
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

        private void SetRoundedCorners(Control control, int radius)
        {
            var path = new GraphicsPath();
            int d = radius * 2;

            path.AddArc(0, 0, d, d, 180, 90);
            path.AddArc(control.Width - d, 0, d, d, 270, 90);
            path.AddArc(control.Width - d, control.Height - d, d, d, 0, 90);
            path.AddArc(0, control.Height - d, d, d, 90, 90);
            path.CloseFigure();

            control.Region = new Region(path);
        }
        private void btnSignOut_Click(object sender, EventArgs e)
        {
            SignInForm frm = new SignInForm();
            frm.Show();
            this.Hide();
        }

        private void RefreshUniversitySections(string search = null)
        {
            

            uniPanels.SuspendLayout();
            uniPanels.Controls.Clear();
            using (var cmd = new SqlCommand(@"
        SELECT University, COUNT(*) AS NoteCount
        FROM Notes
        WHERE University IS NOT NULL
        AND (@q IS NULL OR University LIKE '%' + @q + '%')
        GROUP BY University
        ORDER BY University;", db.GetConnection()))
            {
                object q = string.IsNullOrWhiteSpace(search) ? DBNull.Value : (object)search.Trim();
                cmd.Parameters.AddWithValue("@q", q);

                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        string uni = rd.GetString(0);
                        int count = rd.GetInt32(1);
                        var row = CreateUniRow(uni, count);
                        uniPanels.Controls.Add(row);
                    }
                }
            }
            db.GetConnection().Close();

            uniPanels.ResumeLayout();
        }
        private Control CreateUniRow(string uni, int count)
        {

            var pnl = new Panel
            {
                Height = 50,
                Width = uniPanels.ClientSize.Width - 12,
                BackColor = Color.FromArgb(100, 240, 240, 240),
                Margin = new Padding(4, 4, 4, 0),
            };
            Color normalColor = Color.FromArgb(100, 240, 240, 240);
            Color hoverColor = Color.FromArgb(160, 220, 235, 245);

            pnl.BackColor = normalColor;

            pnl.MouseEnter += (s, e) =>
            {
                pnl.BackColor = hoverColor;
            };

            pnl.MouseLeave += (s, e) =>
            {
                pnl.BackColor = normalColor;
            };
            pnl.Resize += (s, e) =>
            {
                SetRoundedCorners(pnl, 10);
            };

            SetRoundedCorners(pnl, 10);

            var lblName = new Label
            {
                Text = uni,
                AutoSize = false,
                Dock = DockStyle.Left,
                Width = (int)(pnl.Width * 0.70),
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.Gray
            };
            lblName.MouseEnter += (s, e) => pnl.BackColor = hoverColor;
            lblName.MouseLeave += (s, e) => pnl.BackColor = normalColor;

            var lblCount = new Label
            {
                Text = count.ToString() + " notes recorded",
                AutoSize = false,
                Dock = DockStyle.Fill, 
                TextAlign = ContentAlignment.MiddleRight,
                ForeColor = Color.DimGray,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            lblCount.MouseEnter += (s, e) => pnl.BackColor = hoverColor;
            lblCount.MouseLeave += (s, e) => pnl.BackColor = normalColor;
            pnl.Tag = uni;
            pnl.Cursor = Cursors.Hand;

            EventHandler openFormEvent = (s, e) =>
            {
                var form = new UniversityForm((string)pnl.Tag);
                form.UniversityStudentNumber = StudentNumber;
                form.Show();
                this.Hide();
            };

            pnl.Click += openFormEvent;
            lblName.Click += openFormEvent;
            lblCount.Click += openFormEvent;

            pnl.Controls.Add(lblCount);
            pnl.Controls.Add(lblName);
            return pnl;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNotes frm = new AddNotes();
            frm.NotesStudentNumber = StudentNumber;
            frm.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(
            this.ClientRectangle,
            Color.FromArgb(173, 216, 230),
            Color.FromArgb(255, 253, 208), 90F);
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            int radius = 20;

            System.Drawing.Drawing2D.GraphicsPath border = new System.Drawing.Drawing2D.GraphicsPath();
            border.StartFigure();

            border.AddArc(0, 0, radius, radius, 180, 90);
            border.AddArc(panel2.Width - radius, 0, radius, radius, 270, 90);
            border.AddArc(panel2.Width - radius, panel2.Height - radius, radius, radius, 0, 90);
            border.AddArc(0, panel2.Height - radius, radius, radius, 90, 90);

            border.CloseFigure();

            panel2.Region = new System.Drawing.Region(border);
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            int radius = 20;

            System.Drawing.Drawing2D.GraphicsPath border = new System.Drawing.Drawing2D.GraphicsPath();
            border.StartFigure();

            border.AddArc(0, 0, radius, radius, 180, 90);
            border.AddArc(panel5.Width - radius, 0, radius, radius, 270, 90);
            border.AddArc(panel5.Width - radius, panel5.Height - radius, radius, radius, 0, 90);
            border.AddArc(0, panel5.Height - radius, radius, radius, 90, 90);

            border.CloseFigure();

            panel5.Region = new System.Drawing.Region(border);
        }



        private void btnMynotes_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new LinearGradientBrush(
            btnMynotes.ClientRectangle, currentC1, currentC2,
            LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(brush, btnMynotes.ClientRectangle);
            }

            TextRenderer.DrawText(e.Graphics, btnMynotes.Text, btnMynotes.Font,
                btnMynotes.ClientRectangle, Color.White,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);


            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            int cornerRadius = 10;
            using (var borderPath = new GraphicsPath())
            {
                borderPath.StartFigure();
                borderPath.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
                borderPath.AddArc(btnMynotes.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
                borderPath.AddArc(btnMynotes.Width - cornerRadius, btnMynotes.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
                borderPath.AddArc(0, btnMynotes.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
                borderPath.CloseFigure();
                btnMynotes.Region = new Region(borderPath);
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            int radius = 20;

            System.Drawing.Drawing2D.GraphicsPath border = new System.Drawing.Drawing2D.GraphicsPath();
            border.StartFigure();

            border.AddArc(0, 0, radius, radius, 180, 90);
            border.AddArc(panel6.Width - radius, 0, radius, radius, 270, 90);
            border.AddArc(panel6.Width - radius, panel6.Height - radius, radius, radius, 0, 90);
            border.AddArc(0, panel6.Height - radius, radius, radius, 90, 90);

            border.CloseFigure();

            panel6.Region = new System.Drawing.Region(border);
        }

        private void btnSignOut_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(
            btnSignOut.ClientRectangle, currentC1, currentC2,
            LinearGradientMode.Horizontal);
            e.Graphics.FillRectangle(brush, btnSignOut.ClientRectangle);
            TextRenderer.DrawText(e.Graphics, btnSignOut.Text, btnSignOut.Font,
            btnSignOut.ClientRectangle, Color.White,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int cornerRadius = 10;
            System.Drawing.Drawing2D.GraphicsPath borderPath = new System.Drawing.Drawing2D.GraphicsPath();
            borderPath.StartFigure();
            borderPath.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            borderPath.AddArc(btnSignOut.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            borderPath.AddArc(btnSignOut.Width - cornerRadius, btnSignOut.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            borderPath.AddArc(0, btnSignOut.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            borderPath.CloseFigure();
            btnSignOut.Region = new System.Drawing.Region(borderPath);
        }

        private void btnSignOut_MouseEnter(object sender, EventArgs e)
        {
            activeButton = btnSignOut;
            targetC1 = Color.FromArgb(59, 130, 246);
            targetC2 = Color.FromArgb(34, 211, 238);
            colorTimer.Start();
        }

        private void btnSignOut_MouseLeave(object sender, EventArgs e)
        {
            activeButton = btnSignOut;
            targetC1 = Color.FromArgb(173, 216, 230);
            targetC2 = Color.FromArgb(72, 201, 176);
            colorTimer.Start();
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.magnifying_glass_chill;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.magnifying_glass;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.files_chill;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.files;
        }

        private void pbProfile_MouseEnter(object sender, EventArgs e)
        {
            pbProfile.Image = Properties.Resources.user__1__chill;
        }

        private void pbProfile_MouseLeave(object sender, EventArgs e)
        {
            pbProfile.Image = Properties.Resources.user__1_;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            RefreshUniversitySections(txtSearch.Text);
        }

        private void btnMynotes_Click(object sender, EventArgs e)
        {
            ProfileForm frm = new ProfileForm();
            frm.ProfileStudentNumber = StudentNumber;
            frm.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //pictureBox3.Enabled = false;
            AddNotes frm = new AddNotes();
            frm.NotesStudentNumber = StudentNumber;
            //frm.FormClosed += (s, args) =>
            //{
              //  pictureBox3.Enabled = true;
            //};
            frm.Show();
        }

        private void pbProfile_Click(object sender, EventArgs e)
        {
            ProfileForm frm = new ProfileForm();
            frm.ProfileStudentNumber = StudentNumber;
            frm.Show();
            this.Hide();
        }

        private void btnMynotes_MouseEnter(object sender, EventArgs e)
        {
            activeButton = btnMynotes;
            targetC1 = Color.FromArgb(59, 130, 246);
            targetC2 = Color.FromArgb(34, 211, 238);
            colorTimer.Start();
        }

        private void btnMynotes_MouseLeave(object sender, EventArgs e)
        {
            activeButton = btnMynotes;
            targetC1 = Color.FromArgb(173, 216, 230);
            targetC2 = Color.FromArgb(72, 201, 176);
            colorTimer.Start();
        }
    }
}
