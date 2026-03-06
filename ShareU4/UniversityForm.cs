using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShareU4
{
    public partial class UniversityForm: Form
    {
        public UniversityForm()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            EnableDoubleBuffer(panel1);
            EnableDoubleBuffer(panel2);
            EnableDoubleBuffer(flp);

            flp.FlowDirection = FlowDirection.TopDown;
            flp.WrapContents = false;
            flp.AutoScroll = true;

            flp.BackColor = Color.FromArgb(245, 245, 245);

            panel1.SizeChanged += (s, e) => ApplyRounded(panel1, 35);
            panel2.SizeChanged += (s, e) => ApplyRounded(panel2, 18);
        }
        public string UniversityStudentNumber;
        ConnectionLink db = new ConnectionLink();

        private string selectedUniversity;

        public UniversityForm(string universityName)
        {
            InitializeComponent();
            selectedUniversity = universityName;
        }
        private void UniversityForm_Load(object sender, EventArgs e)
        {
            lblUniversityName.Text = selectedUniversity;
            LoadNotes();
            this.DoubleBuffered = true;
            EnableDoubleBuffer(flp);
            EnableDoubleBuffer(panel1);
            EnableDoubleBuffer(panel2);

            flp.FlowDirection = FlowDirection.TopDown;
            flp.WrapContents = false;
            flp.AutoScroll = true;
            ApplyRounded(panel1, 35);
            ApplyRounded(panel2, 18);
            ApplyRounded(flp, 25);

        }
        private void EnableDoubleBuffer(Control c)
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, c, new object[] { true });
        }
        private void ApplyRounded(Control control, int radius)
        {
            if (control.Width <= 0 || control.Height <= 0) return;

            int d = radius * 2;
            using (GraphicsPath path = new GraphicsPath())
            {
                path.StartFigure();
                path.AddArc(0, 0, d, d, 180, 90);
                path.AddArc(control.Width - d, 0, d, d, 270, 90);
                path.AddArc(control.Width - d, control.Height - d, d, d, 0, 90);
                path.AddArc(0, control.Height - d, d, d, 90, 90);
                path.CloseFigure();

                control.Region?.Dispose();
                control.Region = new Region(path);
            }
        }
        private void LoadNotes(string searchText = null)
        {
            flp.Controls.Clear();

            if (db.GetConnection().State == ConnectionState.Open) db.GetConnection().Close();

            string sql = @"
SELECT 
    n.NoteID,
    n.Title,
    n.SubjectName,
    n.UploadDate,
    u.FullName
FROM Notes n
INNER JOIN Users u ON n.UserID = u.UserID
WHERE n.University = @u
  AND (
        @s IS NULL OR @s = ''
        OR n.Title LIKE '%' + @s + '%'
        OR n.SubjectName LIKE '%' + @s + '%'
        OR u.FullName LIKE '%' + @s + '%'
      )
ORDER BY n.UploadDate DESC";


            using (SqlCommand cmd = new SqlCommand(sql, db.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@u", selectedUniversity);

                string s = string.IsNullOrWhiteSpace(searchText) ? null : searchText.Trim();
                cmd.Parameters.AddWithValue("@s", (object)s ?? DBNull.Value);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    bool any = false;

                    while (dr.Read())
                    {
                        any = true;

                        int noteId = dr.GetInt32(0);
                        string title = dr.GetString(1);
                        string subject = dr.IsDBNull(2) ? "General" : dr.GetString(2);
                        DateTime date = dr.GetDateTime(3);
                        string publisher = dr.IsDBNull(4) ? "Unknown" : dr.GetString(4);

                        Color normalColor = Color.FromArgb(100, 240, 240, 240);
                        Color hoverColor = Color.FromArgb(160, 220, 235, 245);

                        Panel pnl = new Panel
                        {
                            Width = 622,
                            Height = 70,
                            BackColor = normalColor,
                            BorderStyle = BorderStyle.None,
                            Margin = new Padding(6, 6, 6, 0),
                            Padding = new Padding(10, 8, 10, 8),
                            Cursor = Cursors.Hand
                        };

                        // Rounded köşe (sağlam)
                        pnl.SizeChanged += (s1, e1) => ApplyRounded(pnl, 12);

                        Label lblDate = new Label
                        {
                            Text = date.ToString("dd.MM.yyyy"),
                            AutoSize = false,
                            Dock = DockStyle.Right,
                            Width = 110,
                            TextAlign = ContentAlignment.MiddleRight,
                            Font = new Font("Segoe UI", 9),
                            ForeColor = Color.DimGray,
                            Cursor = Cursors.Hand
                        };

                        Panel left = new Panel
                        {
                            Dock = DockStyle.Fill,
                            BackColor = Color.Transparent
                        };

                        Panel rightPanel = new Panel
                        {
                            Dock = DockStyle.Right,
                            Width = 260,
                            BackColor = Color.Transparent
                        };
                        Panel metaRow = new Panel
                        {
                            Dock = DockStyle.Top,
                            Height = 20,
                            BackColor = Color.Transparent,

                            Margin = new Padding(0, 9, 0, 0)
                        };

                        Label lblSubject = new Label
                        {
                            Text = subject,
                            AutoSize = false,
                            Dock = DockStyle.Top,
                            Height = 18,
                            Font = new Font("Segoe UI", 9, FontStyle.Bold),
                            ForeColor = Color.FromArgb(30, 90, 160),
                            Cursor = Cursors.Hand
                        };

                        Label lblTitle = new Label
                        {
                            Text = title,
                            AutoSize = false,
                            Dock = DockStyle.Top,
                            Height = 22,
                            Font = new Font("Segoe UI", 10, FontStyle.Regular),
                            ForeColor = Color.FromArgb(35, 35, 35),
                            Cursor = Cursors.Hand
                        };

                        Label lblPublisher = new Label
                        {
                            Text = publisher,
                            AutoSize = false,
                            Dock = DockStyle.Fill, 
                            TextAlign = ContentAlignment.MiddleLeft,
                            Font = new Font("Segoe UI", 9, FontStyle.Italic),
                            ForeColor = Color.DimGray,
                            Cursor = Cursors.Hand
                        };

                        left.Controls.Add(lblPublisher);
                        left.Controls.Add(lblTitle);
                        left.Controls.Add(lblSubject);
                        rightPanel.Controls.Add(lblDate);
                        rightPanel.Controls.Add(lblPublisher);

                        pnl.Controls.Add(left);
                        pnl.Controls.Add(rightPanel);

                        flp.Controls.Add(pnl);

                        void OpenNote()
                        {
                            var frm = new NotesForm(noteId);
                            frm.NotesStudentNumber = UniversityStudentNumber;
                            frm.Show();
                            this.Hide();
                        }

                        EventHandler clickHandler = (x, y) => OpenNote();

                        pnl.Click += clickHandler;
                        left.Click += clickHandler;
                        lblSubject.Click += clickHandler;
                        lblTitle.Click += clickHandler;
                        lblPublisher.Click += clickHandler;
                        lblDate.Click += clickHandler;

                        void SetHover(bool on) => pnl.BackColor = on ? hoverColor : normalColor;

                        pnl.MouseEnter += (x, y) => SetHover(true);
                        pnl.MouseLeave += (x, y) => SetHover(false);

                        left.MouseEnter += (x, y) => SetHover(true);
                        left.MouseLeave += (x, y) => SetHover(false);

                        lblSubject.MouseEnter += (x, y) => SetHover(true);
                        lblSubject.MouseLeave += (x, y) => SetHover(false);

                        lblTitle.MouseEnter += (x, y) => SetHover(true);
                        lblTitle.MouseLeave += (x, y) => SetHover(false);

                        lblPublisher.MouseEnter += (x, y) => SetHover(true);
                        lblPublisher.MouseLeave += (x, y) => SetHover(false);

                        lblDate.MouseEnter += (x, y) => SetHover(true);
                        lblDate.MouseLeave += (x, y) => SetHover(false);
                    }

                    dr.Close();
                    db.GetConnection().Close();

                    if (!any)
                        MessageBox.Show("No results found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.home__1__chill;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.home__1_;
        }

        private void UniversityForm_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(
            this.ClientRectangle,
            Color.FromArgb(173, 216, 230),
            Color.FromArgb(255, 253, 208), 90F);
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            ApplyRounded(panel2, 18);
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            int cornerRadius = 10;
            System.Drawing.Drawing2D.GraphicsPath borderPath = new System.Drawing.Drawing2D.GraphicsPath();
            borderPath.StartFigure();
            borderPath.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            borderPath.AddArc(panel3.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            borderPath.AddArc(panel3.Width - cornerRadius, panel3.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            borderPath.AddArc(0, panel3.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            borderPath.CloseFigure();
            panel3.Region = new System.Drawing.Region(borderPath);

            using (var brush = new LinearGradientBrush(
                panel3.ClientRectangle,
                Color.Aquamarine,
                Color.WhiteSmoke,
                LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(brush, panel3.ClientRectangle);
            }
        }
        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.magnifying_glass_chill;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.magnifying_glass;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainForm frm = new MainForm();  
            frm.StudentNumber = UniversityStudentNumber;
            frm.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LoadNotes(txtSearch.Text);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
