namespace ShareU4
{
    partial class AddNotes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNotes));
            this.lblStudentName = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pbProfile = new System.Windows.Forms.PictureBox();
            this.cmbSubject = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfile)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStudentName
            // 
            this.lblStudentName.AutoSize = true;
            this.lblStudentName.BackColor = System.Drawing.Color.Transparent;
            this.lblStudentName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblStudentName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.lblStudentName.Location = new System.Drawing.Point(73, 25);
            this.lblStudentName.Name = "lblStudentName";
            this.lblStudentName.Size = new System.Drawing.Size(264, 21);
            this.lblStudentName.TabIndex = 2;
            this.lblStudentName.Text = "Student Name (University Name)";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(77, 72);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(210, 29);
            this.txtTitle.TabIndex = 56435;
            this.txtTitle.Enter += new System.EventHandler(this.txtTitle_Enter);
            this.txtTitle.Leave += new System.EventHandler(this.txtTitle_Leave);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnAdd.Location = new System.Drawing.Point(317, 106);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(112, 50);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add Notes";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnAdd.Paint += new System.Windows.Forms.PaintEventHandler(this.btnAdd_Paint);
            this.btnAdd.MouseEnter += new System.EventHandler(this.btnAdd_MouseEnter);
            this.btnAdd.MouseLeave += new System.EventHandler(this.btnAdd_MouseLeave);
            // 
            // pbProfile
            // 
            this.pbProfile.BackColor = System.Drawing.Color.Transparent;
            this.pbProfile.Image = ((System.Drawing.Image)(resources.GetObject("pbProfile.Image")));
            this.pbProfile.Location = new System.Drawing.Point(13, 8);
            this.pbProfile.Name = "pbProfile";
            this.pbProfile.Size = new System.Drawing.Size(50, 50);
            this.pbProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbProfile.TabIndex = 3;
            this.pbProfile.TabStop = false;
            // 
            // cmbSubject
            // 
            this.cmbSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubject.ForeColor = System.Drawing.Color.Gray;
            this.cmbSubject.FormattingEnabled = true;
            this.cmbSubject.Items.AddRange(new object[] {
            "Please Choose a Subject...",
            "Adli Tıp",
            "Ahlak Felsefesi",
            "Acil Tıp",
            "Akaid",
            "Akılcı İlaç Kullanımı",
            "Algoritmalar",
            "Alternatif Uyuşmazlık Çözümü",
            "Ambalaj Tasarımı",
            "Analitik Kimya",
            "Analiz",
            "Anatomi",
            "Anayasa",
            "Anayasa Hukuku",
            "Anesteziyoloji",
            "Anesteziyoloji ve Reanimasyon",
            "Anlambilim",
            "Antik Felsefe",
            "Arapça",
            "Arapça Gramer",
            "Araştırmacı Gazetecilik",
            "Atatürk İlke ve İnkilapları",
            "Avrupa Birliği Hukuku",
            "Avrupa Tarihi",
            "Ağız, Çene ve Yüz Cerrahisi",
            "Ağız, Çene ve Yüz Radyolojisi",
            "Basın Tarihi",
            "Belgesel Sinema",
            "Beden Eğitimi ve Spor Eğitimi",
            "Betonarme",
            "Beşeri Coğrafya",
            "Bilgi Güvenliği",
            "Bilgisayar Ağları",
            "Bilgisayar Destekli Tasarım",
            "Bilim Etiği",
            "Bilim Felsefesi",
            "Bilişim Hukuku",
            "Bina Fiziği",
            "Biyofarmasötik ve Farmakokinetik",
            "Biyofizik",
            "Biyogüvenlik",
            "Biyokimya",
            "Biyoloji",
            "Biyoistatistik",
            "Borçlar Hukuku",
            "Bulaşıcı Hastalıklar",
            "Bütçe Politikası",
            "Cam Sanatı",
            "Ceza Hukuku",
            "Ceza Muhakemesi Hukuku",
            "Cerrahi",
            "Coğrafya",
            "Çağdaş Dünya Tarihi",
            "Çağdaş Felsefe",
            "Çalışma Psikolojisi",
            "Çelik Yapılar",
            "Çevre Hukuku",
            "Çevre ve Mimarlık",
            "Çocuk Cerrahisi",
            "Çocuk Sağlığı ve Hastalıkları",
            "Dekor Tasarımı",
            "Deney Tasarımı",
            "Deneysel Resim",
            "Deprem Mühendisliği",
            "Desen",
            "Desen Tasarımı",
            "Devre Teorisi",
            "Diferansiyel Denklemler",
            "Dijital Gazetecilik",
            "Dijital Grafik",
            "Dijital İletişim",
            "Dijital Pazarlama",
            "Dijital Tasarım",
            "Din Eğitimi",
            "Din Felsefesi",
            "Din Hizmetleri",
            "Din Psikolojisi",
            "Din Sosyolojisi",
            "Din Öğretimi",
            "Dinler Tarihi",
            "Diş Hekimliği Etiği",
            "Diş Morfolojisi",
            "Dokuma Teknikleri",
            "Doğum ve Jinekoloji",
            "Dünya Edebiyatı",
            "Eczacılık Etiği",
            "Eczacılık Mevzuatı",
            "Eczacılık Stajı",
            "Eczane İşletmeciliği",
            "Edebî Metin İncelemesi",
            "Ekoloji",
            "Ekonomik Coğrafya",
            "Elektronik I",
            "Elektronik II",
            "Elektromanyetizma",
            "Endodonti",
            "Endokrinoloji",
            "Enerji Hukuku",
            "Enfeksiyon Hastalıkları",
            "Enfeksiyon Kontrolü",
            "Enstrüman Eğitimi",
            "Epidemiyoloji",
            "Estetik",
            "Et ve Süt Teknolojisi",
            "Evrim",
            "Farmakognozi",
            "Farmakoloji",
            "Farmakoterapi",
            "Farmasötik Kimya",
            "Farmasötik Teknoloji",
            "Fen Bilgisi Eğitimi",
            "Figüratif Resim",
            "Film Analizi",
            "Finans",
            "Finansal Piyasalar",
            "Finansal Yönetim",
            "Fizik I",
            "Fizik II",
            "Fiziki Coğrafya",
            "Fizikokimya",
            "Fizyoloji",
            "Fikri ve Sınai Mülkiyet Hukuku",
            "Felsefeye Giriş",
            "Genel Biyoloji",
            "Genel Cerrahi",
            "Genel Dilbilim",
            "Genel Fizik I",
            "Genel Fizik II",
            "Genel Kimya",
            "Genel Muhasebe",
            "Genetik",
            "Genetik ve Islah",
            "Girişimcilik",
            "Göğüs Hastalıkları",
            "Görsel Algı",
            "Görsel Efektler",
            "Görsel İletişim Tasarımı",
            "Göz Hastalıkları",
            "Haber Yazımı",
            "Hadis",
            "Halk Edebiyatı",
            "Halk Sağlığı",
            "Halkla İlişkilere Giriş",
            "Hematoloji",
            "Heykel",
            "Heykel Atölyesi",
            "Hidrolik",
            "Histoloji ve Embriyoloji",
            "Hukuka Giriş",
            "Hukuk Klinikleri",
            "Hukuk Metodolojisi",
            "Hukuk Tarihi",
            "Hücre Biyolojisi",
            "Isı Transferi",
            "İcra ve İflas Hukuku",
            "İktisada Giriş",
            "İktisat Teorisi",
            "İletişime Giriş",
            "İletişim Araştırmaları",
            "İletişim Etiği",
            "İletişim Kuramları",
            "İmalat Yöntemleri",
            "İmar Hukuku",
            "İmmünoloji",
            "İnsan Faktörleri Mühendisliği",
            "İnsan Hakları Hukuku",
            "İnsan Kaynakları Yönetimi",
            "İstatistik",
            "İstatistiğe Giriş",
            "İslam Felsefesi",
            "İslam Hukuku",
            "İslam Medeniyeti Tarihi",
            "İslam Sanatları",
            "İslam Tarihi",
            "İş Hukuku",
            "İş Sağlığı ve Güvenliği",
            "İşletme Matematiği",
            "İşletme İstatistiği",
            "İşletmeye Giriş",
            "İşletim Sistemleri",
            "İç Hastalıkları",
            "İçerik Üretimi",
            "Kadın Hastalıkları ve Doğum",
            "Kalite Güvence Sistemleri",
            "Kalite Kontrol",
            "Kalite Yönetimi",
            "Kalp ve Damar Cerrahisi",
            "Karar Destek Sistemleri",
            "Karşılaştırmalı Edebiyat",
            "Karşılaştırmalı Siyaset",
            "Kardiyoloji",
            "Katı Hal Fiziği",
            "Kelam",
            "Kentsel Planlama",
            "Kentsel Tasarım",
            "Kimya",
            "Kitle İletişimi",
            "Klasik Mekanik",
            "Klasik Metin Okumaları",
            "Klinik Eczacılık",
            "Klinik Tanı Yöntemleri",
            "Klinik Yönetimi",
            "Kontrol Sistemleri",
            "Koruyucu Diş Hekimliği",
            "Koro",
            "Kostüm Tasarımı",
            "Kriptografi",
            "Kuantum Mekaniği",
            "Kültür Sosyolojisi",
            "Kumaş Analizi",
            "Kulak Burun Boğaz",
            "Kur’an-ı Kerim Okuma ve Tecvit",
            "Kur’an-ı Kerim Tefsiri",
            "Kurumsal İletişim",
            "Lojistik Yönetimi",
            "Makine Elemanları",
            "Makine Öğrenmesi",
            "Makroiktisat",
            "Mantık",
            "Marka Yönetimi",
            "Matematik I",
            "Matematik II",
            "Matematik Eğitimi",
            "Medeni Hukuk",
            "Medeni Usul Hukuku",
            "Medya Araştırmaları",
            "Medya Okuryazarlığı",
            "Medya ve Toplum",
            "Meslek Etiği",
            "Mesleki Uygulama",
            "Mikrobiyoloji",
            "Mikroiktisat",
            "Mikroişlemciler",
            "Mimari Anlatım Teknikleri",
            "Mimari Görselleştirme",
            "Mimari Tasarım I",
            "Mimari Tasarım II",
            "Mimari Tasarım III",
            "Mimari Tasarım IV",
            "Mimarlık Tarihi",
            "Mimarlıkta Meslek Etiği",
            "Modelaj",
            "Modelleme Teknikleri",
            "Moda Tasarımı",
            "Modern Fizik",
            "Mukavemet",
            "Müzik Teorisi",
            "Nefroloji",
            "Nesne Yönelimli Programlama",
            "Nöroloji",
            "Nükleer Fizik",
            "Nükleer Tıp",
            "Oklüzyon",
            "Okul Deneyimi",
            "Okul Öncesi Eğitimi",
            "Operasyon Yönetimi",
            "Oral Diagnoz",
            "Orkestra",
            "Organik Kimya",
            "Orta Çağ Felsefesi",
            "Ortopedi ve Travmatoloji",
            "Osmanlı Tarihi",
            "Osmanlı Türkçesi",
            "Olasılık ve İstatistik",
            "Olasılık Teorisi",
            "Öğrenme ve Öğretme Kuramları",
            "Öğretim İlke ve Yöntemleri",
            "Öğretim Teknolojileri",
            "Öğretmenlik Uygulaması",
            "Örgütsel Davranış",
            "Özel Eğitim",
            "Özel Öğretim Yöntemleri",
            "Parazitoloji",
            "Patoloji",
            "Pazarlama",
            "Pazarlama Araştırmaları",
            "Pazarlama İletişimi",
            "Pedodonti",
            "Performans Yönetimi",
            "Periodontoloji",
            "Plastik ve Rekonstrüktif Cerrahi",
            "Polimer Kimyası",
            "Preklinik Protez",
            "Preklinik Restoratif Diş Tedavisi",
            "Program Geliştirme",
            "Programlamaya Giriş",
            "Protetik Diş Tedavisi",
            "Psikiyatri",
            "Psikolojiye Giriş",
            "Radyo Programcılığı",
            "Radyo ve Televizyona Giriş",
            "Radyofarmasi",
            "Radyoloji",
            "Rehberlik ve Psikolojik Danışmanlık",
            "Reklam Yazarlığı",
            "Reklamcılığa Giriş",
            "Resim",
            "Restoratif Diş Tedavisi",
            "Roma Hukuku",
            "Sahne Performansı",
            "Sahne Tasarımı",
            "Sanat Kuramları",
            "Sanat Tarihi",
            "Sanat Yönetimi",
            "Sayısal Analiz",
            "Seramik",
            "Seramik Atölyesi",
            "Seramik Tasarımı",
            "Ses Bilgisi",
            "Sigorta Hukuku",
            "Sinema Tarihi",
            "Sinyaller ve Sistemler",
            "Sistem Analizi ",
            "Sosyal Bilgiler Eğitimi",
            "Sosyal Medya Yönetimi",
            "Sosyal Psikoloji",
            "Sosyolojiye Giriş",
            "Spor Hekimliği",
            "Statik",
            "Stratejik Yönetim",
            "Sınıf Yönetimi",
            "Söz Dizimi",
            "Şantiye Yönetimi",
            "Şehircilik",
            "Tarih I",
            "Tarih II",
            "Taşıyıcı Sistemler",
            "Tasavvuf",
            "Teknik Çizim",
            "Tekstil Tasarımı",
            "Televizyon Programcılığı",
            "Termodinamik",
            "Tıbbi Biyoloji",
            "Tıbbi Genetik",
            "Tipografi",
            "Toksikoloji",
            "Toplum Ağız ve Diş Sağlığı",
            "Toplumsal Yapılar",
            "Türkiye Coğrafyası",
            "Türkiye Ekonomisi",
            "Türkiye Tarihi",
            "Türk Dili ve Edebiyatı",
            "Türk Eğitim Sistemi",
            "Türk İslam Tarihi",
            "Türk Siyasal Hayatı",
            "Türkçe Eğitimi",
            "Uluslararası Finans",
            "Uluslararası Hukuk",
            "Uluslararası İktisat",
            "Uluslararası İlişkilere Giriş",
            "Uluslararası Örgütler",
            "Uluslararası Özel Hukuk",
            "Ulaştırma Mühendisliği",
            "Vaaz ve Hitabet",
            "Veri Analizi",
            "Veri Yapıları",
            "Veritabanı Sistemleri",
            "Vergi Hukuku",
            "Veteriner Halk Sağlığı",
            "Veteriner Mevzuatı",
            "Web Programlama",
            "Yağlıboya",
            "Yabancı Dil Eğitimi",
            "Yapay Zeka",
            "Yapı Bilgisi I",
            "Yapı Bilgisi II",
            "Yapı Malzemeleri",
            "Yapı Statiği",
            "Yapım Yönetimi",
            "Yatırım Analizi",
            "Yeni Medya",
            "Yeni Türk Edebiyatı",
            "Yeni Çağ Felsefesi",
            "Yem Bilgisi",
            "Yerleşme Analizi",
            "Yönetim Bilişim Sistemleri",
            "Yönetim ve Organizasyon",
            "Yöneylem Araştırması",
            "Üretim Planlama",
            "Üretim Yönetimi",
            "Üroloji",
            "Üç Boyutlu Tasarım"});
            this.cmbSubject.Location = new System.Drawing.Point(77, 106);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(210, 29);
            this.cmbSubject.TabIndex = 10;
            this.cmbSubject.Enter += new System.EventHandler(this.comboBox1_Enter);
            this.cmbSubject.Leave += new System.EventHandler(this.comboBox1_Leave);
            this.cmbSubject.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cmbSubject_MouseMove);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.cmbSubject);
            this.panel1.Controls.Add(this.pbProfile);
            this.panel1.Controls.Add(this.txtTitle);
            this.panel1.Controls.Add(this.lblStudentName);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(20, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 170);
            this.panel1.TabIndex = 16;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(401, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(42, 42);
            this.panel2.TabIndex = 17;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // AddNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 198);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(505, 237);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(505, 237);
            this.Name = "AddNotes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Notes";
            this.Load += new System.EventHandler(this.AddNotes_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AddNotes_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pbProfile)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblStudentName;
        private System.Windows.Forms.PictureBox pbProfile;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cmbSubject;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}