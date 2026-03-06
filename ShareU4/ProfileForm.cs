using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

namespace ShareU4
{
    public partial class ProfileForm : Form
    {
        public ProfileForm()
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

        public string ProfileStudentNumber;
        ConnectionLink db = new ConnectionLink();

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            LoadMyNotes();


            using (SqlCommand cmd = new SqlCommand(
                "select FullName,University from Users where StudentNumber=@p1", db.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@p1", ProfileStudentNumber);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                        lblStudentName.Text = dr[0].ToString() + " (" + dr[1].ToString() + ")";
                }
            }
            db.GetConnection().Close();
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

        private void LoadMyNotes()
        {
            flp.SuspendLayout();
            flp.Controls.Clear();


            using (SqlCommand cmd = new SqlCommand(@"
                SELECT NoteID, Title, FileName, UploadDate
                FROM Notes n
                INNER JOIN Users u ON n.UserID = u.UserID
                WHERE u.StudentNumber = @num
                ORDER BY n.UploadDate DESC", db.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@num", ProfileStudentNumber);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int noteId = dr.GetInt32(0);
                        string title = dr.GetString(1);
                        string fileName = dr.IsDBNull(2) ? "File not found" : dr.GetString(2);
                        DateTime date = dr.GetDateTime(3);

                        var normalColor = Color.FromArgb(230, 255, 255, 255);
                        var hoverColor = Color.FromArgb(255, 235, 245, 255);

                        Panel pnl = new Panel
                        {
                            Width = 622,
                            Height = 45,
                            Margin = new Padding(10, 8, 10, 0),
                            BackColor = normalColor
                        };

                        ApplyRounded(pnl, 12);
                        pnl.SizeChanged += (s, e) => ApplyRounded(pnl, 12);

                        pnl.MouseEnter += (s, e) => pnl.BackColor = hoverColor;
                        pnl.MouseLeave += (s, e) => pnl.BackColor = normalColor;

                        Label lbl = new Label
                        {
                            Text = $"{title} ({date:dd.MM.yyyy}) - {fileName}",
                            Dock = DockStyle.Fill,
                            AutoEllipsis = true,
                            TextAlign = ContentAlignment.MiddleLeft,
                            Padding = new Padding(12, 0, 0, 0),
                            Font = new Font("Segoe UI", 10),
                            BackColor = normalColor
                        };
                        lbl.MouseEnter += (s, e) => pnl.BackColor = hoverColor;
                        lbl.MouseLeave += (s, e) => pnl.BackColor = normalColor;

                        Button btnShow = new Button
                        {
                            Text = "Show",
                            Width = 70,
                            Height = 30,
                            FlatStyle = FlatStyle.Flat,
                            BackColor = Color.FromArgb(230, 240, 240, 240),
                            ForeColor = Color.Black,
                            Cursor = Cursors.Hand,
                            Tag = noteId
                        };
                        btnShow.FlatAppearance.BorderSize = 0;
                        btnShow.HandleCreated += (s, e) => ApplyRounded(btnShow, 10);
                        btnShow.SizeChanged += (s, e) => ApplyRounded(btnShow, 10);
                        btnShow.Click += (s, e) =>
                        {
                            int id = (int)((Button)s).Tag;
                            var frm = new NotesForm(id);
                            frm.NotesStudentNumber = ProfileStudentNumber;
                            frm.Show();
                            this.Hide();
                        };

                        Button btnDelete = new Button
                        {
                            Text = "Delete",
                            Width = 80,
                            Height = 30,
                            FlatStyle = FlatStyle.Flat,
                            BackColor = Color.FromArgb(230, 240, 240, 240),
                            ForeColor = Color.Black,
                            Cursor = Cursors.Hand,
                            Tag = noteId
                        };
                        btnDelete.FlatAppearance.BorderSize = 0;
                        btnDelete.HandleCreated += (s, e) => ApplyRounded(btnDelete, 10);
                        btnDelete.SizeChanged += (s, e) => ApplyRounded(btnDelete, 10);
                        btnDelete.Click += (s, e) =>
                        {
                            int id = (int)((Button)s).Tag;
                            DeleteNote(id);
                            LoadMyNotes();
                        };

                        FlowLayoutPanel btnPanel = new FlowLayoutPanel
                        {
                            AutoSize = true,
                            WrapContents = false,
                            FlowDirection = FlowDirection.LeftToRight,
                            BackColor = normalColor,
                            Margin = new Padding(0),
                            Padding = new Padding(0)
                        };
                        btnPanel.Controls.Add(btnShow);
                        btnPanel.Controls.Add(btnDelete);

                        pnl.Controls.Add(btnPanel);
                        pnl.Controls.Add(lbl);

                        pnl.Layout += (s, e) =>
                        {
                            btnPanel.Location = new Point(pnl.ClientSize.Width - btnPanel.Width - 10, 7);
                        };

                        flp.Controls.Add(pnl);
                    }
                }
            }
            db.GetConnection().Close();

            flp.ResumeLayout();
        }

        private void DeleteNote(int noteId)
        {
            var confirm = MessageBox.Show("Are you sure you want to delete this note?",
                                          "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;


            using (SqlCommand cmd = new SqlCommand("DELETE FROM Notes WHERE NoteID=@id", db.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@id", noteId);
                cmd.ExecuteNonQuery();
            }
            db.GetConnection().Close();
                
            MessageBox.Show("The note has been deleted successfully.", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnSignOut_Click(object sender, EventArgs e)
        {
            SignInForm frm = new SignInForm();
            frm.Show();
            this.Hide();
        }

        private void ProfileForm_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(173, 216, 230),
                Color.FromArgb(255, 253, 208),
                90f))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new LinearGradientBrush(
                panel2.ClientRectangle,
                Color.Aquamarine,
                Color.WhiteSmoke,
                LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainForm frm = new MainForm();
            frm.StudentNumber = ProfileStudentNumber;
            frm.Show();
            this.Hide();
        }


    }
    }
