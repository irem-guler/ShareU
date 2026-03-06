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

namespace ShareU4
{
    public partial class NotesForm: Form
    {
        public NotesForm()
        {
            InitializeComponent();
        }
        ConnectionLink db = new ConnectionLink();
        private string selectedUniversity;
        public string NotesStudentNumber;
        private int _noteId;
        public NotesForm(string universityName)
        {
            InitializeComponent();
            selectedUniversity = universityName;
        }
        public NotesForm(int noteId)
        {
            InitializeComponent();
            _noteId = noteId;
        }
        private void NotesForm_Load(object sender, EventArgs e)
        {
            LoadNoteFile();
            this.DoubleBuffered = true;
            EnableDoubleBuffer(panel1);
            EnableDoubleBuffer(panel2);
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
        private void LoadNoteFile()
        {

            SqlCommand cmd = new SqlCommand(@"
        SELECT n.Title, n.FileName, n.FileData, u.FullName
        FROM Notes n
        INNER JOIN Users u ON n.UserID = u.UserID
        WHERE n.NoteID = @id", db.GetConnection());

            cmd.Parameters.AddWithValue("@id", _noteId);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                
                lblTitle.Text ="Title: " + dr.GetString(0);

                
                lblPublisher.Text = "Publisher: " + dr.GetString(3);

                
                string fileName = dr.IsDBNull(1) ? "" : dr.GetString(1);

                if (!dr.IsDBNull(2))
                {
                    byte[] fileBytes = (byte[])dr["FileData"];
                    string tempPath = Path.Combine(Application.StartupPath, "Temp", fileName);

                    Directory.CreateDirectory(Path.GetDirectoryName(tempPath));
                    File.WriteAllBytes(tempPath, fileBytes);

                    axAcroPDF1.LoadFile(tempPath);
                    axAcroPDF1.setView("Fit");
                    axAcroPDF1.setShowToolbar(false);
                    axAcroPDF1.setLayoutMode("SinglePage");
                }
                else
                {
                    MessageBox.Show("No file has been uploaded for this note.");
                }
            }

            dr.Close();
            db.GetConnection().Close();
        }


        private void NotesForm_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(
            this.ClientRectangle,
            Color.FromArgb(173, 216, 230),
            Color.FromArgb(255, 253, 208), 90F);
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ApplyRounded(panel1, 40);
        }
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.home__1__chill;
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.home__1_;
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            ApplyRounded(panel2, 10);
            using (var brush = new LinearGradientBrush(
                panel2.ClientRectangle,
                Color.Aquamarine,
                Color.WhiteSmoke,
                LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(brush, panel2.ClientRectangle);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainForm frm = new MainForm();
            frm.StudentNumber = NotesStudentNumber;
            frm.Show();
            this.Hide();
        }
    }
}
