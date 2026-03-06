namespace ShareU4
{
    partial class SignUpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUpForm));
            this.txtStudentNo = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.cmbUniversity = new System.Windows.Forms.ComboBox();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.txtSafe = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStudentNo
            // 
            this.txtStudentNo.Location = new System.Drawing.Point(209, 105);
            this.txtStudentNo.Name = "txtStudentNo";
            this.txtStudentNo.Size = new System.Drawing.Size(298, 29);
            this.txtStudentNo.TabIndex = 5027;
            this.txtStudentNo.Enter += new System.EventHandler(this.txtStudentNo_Enter);
            this.txtStudentNo.Leave += new System.EventHandler(this.txtStudentNo_Leave);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(209, 183);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(298, 29);
            this.txtPassword.TabIndex = 61471;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(209, 144);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(298, 29);
            this.txtFullName.TabIndex = 7252;
            this.txtFullName.Enter += new System.EventHandler(this.txtFullName_Enter);
            this.txtFullName.Leave += new System.EventHandler(this.txtFullName_Leave);
            // 
            // cmbUniversity
            // 
            this.cmbUniversity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbUniversity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUniversity.FormattingEnabled = true;
            this.cmbUniversity.Items.AddRange(new object[] {
            "Please Choose a University...",
            "ABDULLAH GÜL ÜNİVERSİTESİ",
            "ACIBADEM MEHMET ALİ AYDINLAR ÜNİVERSİTESİ",
            "ADANA ALPARSLAN TÜRKEŞ BİLİM VE TEKNOLOJİ ÜNİVERSİTESİ",
            "ADIYAMAN ÜNİVERSİTESİ",
            "AFYON KOCATEPE ÜNİVERSİTESİ",
            "AFYONKARAHİSAR SAĞLIK BİLİMLERİ ÜNİVERSİTESİ",
            "AĞRI İBRAHİM ÇEÇEN ÜNİVERSİTESİ",
            "AKDENİZ ÜNİVERSİTESİ",
            "AKSARAY ÜNİVERSİTESİ",
            "ALANYA ALAADDİN KEYKUBAT ÜNİVERSİTESİ",
            "ALANYA ÜNİVERSİTESİ",
            "ALTINBAŞ ÜNİVERSİTESİ",
            "AMASYA ÜNİVERSİTESİ",
            "ANADOLU ÜNİVERSİTESİ",
            "ANKA TEKNOLOJİ ÜNİVERSİTESİ",
            "ANKARA BİLİM ÜNİVERSİTESİ",
            "ANKARA HACI BAYRAM VELİ ÜNİVERSİTESİ",
            "ANKARA MEDİPOL ÜNİVERSİTESİ",
            "ANKARA MÜZİK VE GÜZEL SANATLAR ÜNİVERSİTESİ",
            "ANKARA SOSYAL BİLİMLER ÜNİVERSİTESİ",
            "ANKARA ÜNİVERSİTESİ",
            "ANKARA YILDIRIM BEYAZIT ÜNİVERSİTESİ",
            "ANTALYA BELEK ÜNİVERSİTESİ",
            "ANTALYA BİLİM ÜNİVERSİTESİ",
            "ARDAHAN ÜNİVERSİTESİ",
            "ARTVİN ÇORUH ÜNİVERSİTESİ",
            "ATAŞEHİR ADIGÜZEL MESLEK YÜKSEKOKULU",
            "ATATÜRK ÜNİVERSİTESİ",
            "ATILIM ÜNİVERSİTESİ",
            "AVRASYA ÜNİVERSİTESİ",
            "AYDIN ADNAN MENDERES ÜNİVERSİTESİ",
            "BAHÇEŞEHİR ÜNİVERSİTESİ",
            "BALIKESİR ÜNİVERSİTESİ",
            "BANDIRMA ONYEDİ EYLÜL ÜNİVERSİTESİ",
            "BARTIN ÜNİVERSİTESİ",
            "BAŞKENT ÜNİVERSİTESİ",
            "BATMAN ÜNİVERSİTESİ",
            "BAYBURT ÜNİVERSİTESİ",
            "BEYKOZ ÜNİVERSİTESİ",
            "BEZM-İ ÂLEM VAKIF ÜNİVERSİTESİ",
            "BİLECİK ŞEYH EDEBALİ ÜNİVERSİTESİ",
            "BİNGÖL ÜNİVERSİTESİ",
            "BİRUNİ ÜNİVERSİTESİ",
            "BİTLİS EREN ÜNİVERSİTESİ",
            "BOĞAZİÇİ ÜNİVERSİTESİ",
            "BOLU ABANT İZZET BAYSAL ÜNİVERSİTESİ",
            "BURDUR MEHMET AKİF ERSOY ÜNİVERSİTESİ",
            "BURSA TEKNİK ÜNİVERSİTESİ",
            "BURSA ULUDAĞ ÜNİVERSİTESİ",
            "ÇAĞ ÜNİVERSİTESİ",
            "ÇANAKKALE ONSEKİZ MART ÜNİVERSİTESİ",
            "ÇANKAYA ÜNİVERSİTESİ",
            "ÇANKIRI KARATEKİN ÜNİVERSİTESİ",
            "ÇUKUROVA ÜNİVERSİTESİ",
            "DEMİROĞLU BİLİM ÜNİVERSİTESİ",
            "DİCLE ÜNİVERSİTESİ",
            "DOĞUŞ ÜNİVERSİTESİ",
            "DOKUZ EYLÜL ÜNİVERSİTESİ",
            "DÜZCE ÜNİVERSİTESİ",
            "EGE ÜNİVERSİTESİ",
            "ERCİYES ÜNİVERSİTESİ",
            "ERZİNCAN BİNALİ YILDIRIM ÜNİVERSİTESİ",
            "ERZURUM TEKNİK ÜNİVERSİTESİ",
            "ESKİŞEHİR OSMANGAZİ ÜNİVERSİTESİ",
            "ESKİŞEHİR TEKNİK ÜNİVERSİTESİ",
            "FATİH SULTAN MEHMET VAKIF ÜNİVERSİTESİ",
            "FENERBAHÇE ÜNİVERSİTESİ",
            "FIRAT ÜNİVERSİTESİ",
            "GALATASARAY ÜNİVERSİTESİ",
            "GAZİ ÜNİVERSİTESİ",
            "GAZİANTEP İSLAM BİLİM VE TEKNOLOJİ ÜNİVERSİTESİ",
            "GAZİANTEP ÜNİVERSİTESİ",
            "GEBZE TEKNİK ÜNİVERSİTESİ",
            "GİRESUN ÜNİVERSİTESİ",
            "GÜMÜŞHANE ÜNİVERSİTESİ",
            "HACETTEPE ÜNİVERSİTESİ",
            "HAKKARİ ÜNİVERSİTESİ",
            "HALİÇ ÜNİVERSİTESİ",
            "HARRAN ÜNİVERSİTESİ",
            "HASAN KALYONCU ÜNİVERSİTESİ",
            "HATAY MUSTAFA KEMAL ÜNİVERSİTESİ",
            "HİTİT ÜNİVERSİTESİ",
            "IĞDIR ÜNİVERSİTESİ",
            "ISPARTA UYGULAMALI BİLİMLER ÜNİVERSİTESİ",
            "IŞIK ÜNİVERSİTESİ",
            "İBN HALDUN ÜNİVERSİTESİ",
            "İHSAN DOĞRAMACI BİLKENT ÜNİVERSİTESİ",
            "İNÖNÜ ÜNİVERSİTESİ",
            "İSKENDERUN TEKNİK ÜNİVERSİTESİ",
            "İSTANBUL AREL ÜNİVERSİTESİ",
            "İSTANBUL ATLAS ÜNİVERSİTESİ",
            "İSTANBUL AYDIN ÜNİVERSİTESİ",
            "İSTANBUL BEYKENT ÜNİVERSİTESİ",
            "İSTANBUL BİLGİ ÜNİVERSİTESİ",
            "İSTANBUL ESENYURT ÜNİVERSİTESİ",
            "İSTANBUL GALATA ÜNİVERSİTESİ",
            "İSTANBUL GEDİK ÜNİVERSİTESİ",
            "İSTANBUL GELİŞİM ÜNİVERSİTESİ",
            "İSTANBUL KENT ÜNİVERSİTESİ",
            "İSTANBUL KÜLTÜR ÜNİVERSİTESİ",
            "İSTANBUL MEDENİYET ÜNİVERSİTESİ",
            "İSTANBUL MEDİPOL ÜNİVERSİTESİ",
            "İSTANBUL NİŞANTAŞI ÜNİVERSİTESİ",
            "İSTANBUL OKAN ÜNİVERSİTESİ",
            "İSTANBUL RUMELİ ÜNİVERSİTESİ",
            "İSTANBUL SABAHATTİN ZAİM ÜNİVERSİTESİ",
            "İSTANBUL SAĞLIK VE SOSYAL BİLİMLER MESLEK YÜKSEKOKULU",
            "İSTANBUL SAĞLIK VE TEKNOLOJİ ÜNİVERSİTESİ",
            "İSTANBUL ŞİŞLİ MESLEK YÜKSEKOKULU",
            "İSTANBUL TEKNİK ÜNİVERSİTESİ",
            "İSTANBUL TİCARET ÜNİVERSİTESİ",
            "İSTANBUL TOPKAPI ÜNİVERSİTESİ",
            "İSTANBUL ÜNİVERSİTESİ",
            "İSTANBUL ÜNİVERSİTESİ-CERRAHPAŞA",
            "İSTANBUL YENİ YÜZYIL ÜNİVERSİTESİ",
            "İSTANBUL 29 MAYIS ÜNİVERSİTESİ",
            "İSTİNYE ÜNİVERSİTESİ",
            "İZMİR BAKIRÇAY ÜNİVERSİTESİ",
            "İZMİR DEMOKRASİ ÜNİVERSİTESİ",
            "İZMİR EKONOMİ ÜNİVERSİTESİ",
            "İZMİR KATİP ÇELEBİ ÜNİVERSİTESİ",
            "İZMİR KAVRAM MESLEK YÜKSEKOKULU",
            "İZMİR TINAZTEPE ÜNİVERSİTESİ",
            "İZMİR YÜKSEK TEKNOLOJİ ENSTİTÜSÜ",
            "KADİR HAS ÜNİVERSİTESİ",
            "KAFKAS ÜNİVERSİTESİ",
            "KAHRAMANMARAŞ İSTİKLAL ÜNİVERSİTESİ",
            "KAHRAMANMARAŞ SÜTÇÜ İMAM ÜNİVERSİTESİ",
            "KAPADOKYA ÜNİVERSİTESİ",
            "KARABÜK ÜNİVERSİTESİ",
            "KARADENİZ TEKNİK ÜNİVERSİTESİ",
            "KARAMANOĞLU MEHMETBEY ÜNİVERSİTESİ",
            "KASTAMONU ÜNİVERSİTESİ",
            "KAYSERİ ÜNİVERSİTESİ",
            "KIRIKKALE ÜNİVERSİTESİ",
            "KIRKLARELİ ÜNİVERSİTESİ",
            "KIRŞEHİR AHİ EVRAN ÜNİVERSİTESİ",
            "KİLİS 7 ARALIK ÜNİVERSİTESİ",
            "KOCAELİ SAĞLIK VE TEKNOLOJİ ÜNİVERSİTESİ",
            "KOCAELİ ÜNİVERSİTESİ",
            "KOÇ ÜNİVERSİTESİ",
            "KONYA GIDA VE TARIM ÜNİVERSİTESİ",
            "KONYA TEKNİK ÜNİVERSİTESİ",
            "KTO KARATAY ÜNİVERSİTESİ",
            "KÜTAHYA DUMLUPINAR ÜNİVERSİTESİ",
            "KÜTAHYA SAĞLIK BİLİMLERİ ÜNİVERSİTESİ",
            "LOKMAN HEKİM ÜNİVERSİTESİ",
            "MALATYA TURGUT ÖZAL ÜNİVERSİTESİ",
            "MALTEPE ÜNİVERSİTESİ",
            "MANİSA CELÂL BAYAR ÜNİVERSİTESİ",
            "MARDİN ARTUKLU ÜNİVERSİTESİ",
            "MARMARA ÜNİVERSİTESİ",
            "MEF ÜNİVERSİTESİ",
            "MERSİN ÜNİVERSİTESİ",
            "MİMAR SİNAN GÜZEL SANATLAR ÜNİVERSİTESİ",
            "MUDANYA ÜNİVERSİTESİ",
            "MUĞLA SITKI KOÇMAN ÜNİVERSİTESİ",
            "MUNZUR ÜNİVERSİTESİ",
            "MUŞ ALPARSLAN ÜNİVERSİTESİ",
            "NECMETTİN ERBAKAN ÜNİVERSİTESİ",
            "NEVŞEHİR HACI BEKTAŞ VELİ ÜNİVERSİTESİ",
            "NİĞDE ÖMER HALİSDEMİR ÜNİVERSİTESİ",
            "NUH NACİ YAZGAN ÜNİVERSİTESİ",
            "ONDOKUZ MAYIS ÜNİVERSİTESİ",
            "ORDU ÜNİVERSİTESİ",
            "ORTA DOĞU TEKNİK ÜNİVERSİTESİ",
            "OSMANİYE KORKUT ATA ÜNİVERSİTESİ",
            "OSTİM TEKNİK ÜNİVERSİTESİ",
            "ÖZYEĞİN ÜNİVERSİTESİ",
            "PAMUKKALE ÜNİVERSİTESİ",
            "PİRİ REİS ÜNİVERSİTESİ",
            "RECEP TAYYİP ERDOĞAN ÜNİVERSİTESİ",
            "SABANCI ÜNİVERSİTESİ",
            "SAĞLIK BİLİMLERİ ÜNİVERSİTESİ",
            "SAKARYA UYGULAMALI BİLİMLER ÜNİVERSİTESİ",
            "SAKARYA ÜNİVERSİTESİ",
            "SAMSUN ÜNİVERSİTESİ",
            "SANKO ÜNİVERSİTESİ",
            "SELÇUK ÜNİVERSİTESİ",
            "SİİRT ÜNİVERSİTESİ",
            "SİNOP ÜNİVERSİTESİ",
            "SİVAS BİLİM VE TEKNOLOJİ ÜNİVERSİTESİ",
            "SİVAS CUMHURİYET ÜNİVERSİTESİ",
            "SÜLEYMAN DEMİREL ÜNİVERSİTESİ",
            "ŞIRNAK ÜNİVERSİTESİ",
            "TARSUS ÜNİVERSİTESİ",
            "TED ÜNİVERSİTESİ",
            "TEKİRDAĞ NAMIK KEMAL ÜNİVERSİTESİ",
            "TOBB EKONOMİ VE TEKNOLOJİ ÜNİVERSİTESİ",
            "TOKAT GAZİOSMANPAŞA ÜNİVERSİTESİ",
            "TOROS ÜNİVERSİTESİ",
            "TRABZON ÜNİVERSİTESİ",
            "TRAKYA ÜNİVERSİTESİ",
            "TÜRK HAVA KURUMU ÜNİVERSİTESİ",
            "TÜRK-ALMAN ÜNİVERSİTESİ",
            "TÜRKİYE ULUSLARARASI İSLAM, BİLİM VE TEKNOLOJİ",
            "TÜRK-JAPON BİLİM VE TEKNOLOJİ ÜNİVERSİTESİ",
            "UFUK ÜNİVERSİTESİ",
            "UŞAK ÜNİVERSİTESİ",
            "ÜSKÜDAR ÜNİVERSİTESİ",
            "VAN YÜZÜNCÜ YIL ÜNİVERSİTESİ",
            "YALOVA ÜNİVERSİTESİ",
            "YAŞAR ÜNİVERSİTESİ",
            "YEDİTEPE ÜNİVERSİTESİ",
            "YILDIZ TEKNİK ÜNİVERSİTESİ",
            "YOZGAT BOZOK ÜNİVERSİTESİ",
            "YÜKSEK İHTİSAS ÜNİVERSİTESİ",
            "ZONGULDAK BÜLENT ECEVİT ÜNİVERSİTESİ"});
            this.cmbUniversity.Location = new System.Drawing.Point(209, 261);
            this.cmbUniversity.Name = "cmbUniversity";
            this.cmbUniversity.Size = new System.Drawing.Size(298, 29);
            this.cmbUniversity.TabIndex = 814;
            this.cmbUniversity.Enter += new System.EventHandler(this.cmbUniversity_Enter);
            this.cmbUniversity.Leave += new System.EventHandler(this.cmbUniversity_Leave);
            this.cmbUniversity.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cmbUniversity_MouseMove);
            // 
            // btnSignUp
            // 
            this.btnSignUp.BackColor = System.Drawing.Color.White;
            this.btnSignUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSignUp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(154)))), ((int)(((byte)(252)))));
            this.btnSignUp.FlatAppearance.BorderSize = 0;
            this.btnSignUp.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSignUp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnSignUp.Location = new System.Drawing.Point(369, 322);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(138, 42);
            this.btnSignUp.TabIndex = 9;
            this.btnSignUp.Text = "Sign-Up";
            this.btnSignUp.UseVisualStyleBackColor = false;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            this.btnSignUp.Paint += new System.Windows.Forms.PaintEventHandler(this.btnSignUp_Paint);
            this.btnSignUp.MouseEnter += new System.EventHandler(this.btnSignUp_MouseEnter);
            this.btnSignUp.MouseLeave += new System.EventHandler(this.btnSignUp_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnSignIn);
            this.panel1.Controls.Add(this.txtSafe);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtStudentNo);
            this.panel1.Controls.Add(this.cmbUniversity);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.btnSignUp);
            this.panel1.Controls.Add(this.txtFullName);
            this.panel1.Location = new System.Drawing.Point(106, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 402);
            this.panel1.TabIndex = 24;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(485, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 121415;
            this.pictureBox1.TabStop = false;
            // 
            // btnSignIn
            // 
            this.btnSignIn.BackColor = System.Drawing.Color.White;
            this.btnSignIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSignIn.FlatAppearance.BorderSize = 0;
            this.btnSignIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnSignIn.Location = new System.Drawing.Point(209, 322);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(138, 42);
            this.btnSignIn.TabIndex = 13;
            this.btnSignIn.Text = "Sign-In";
            this.btnSignIn.UseVisualStyleBackColor = false;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            this.btnSignIn.Paint += new System.Windows.Forms.PaintEventHandler(this.btnSignIn_Paint);
            this.btnSignIn.MouseEnter += new System.EventHandler(this.btnSignIn_MouseEnter);
            this.btnSignIn.MouseLeave += new System.EventHandler(this.btnSignIn_MouseLeave);
            // 
            // txtSafe
            // 
            this.txtSafe.Location = new System.Drawing.Point(209, 222);
            this.txtSafe.Name = "txtSafe";
            this.txtSafe.Size = new System.Drawing.Size(298, 29);
            this.txtSafe.TabIndex = 121414;
            this.txtSafe.Enter += new System.EventHandler(this.txtSafe_Enter);
            this.txtSafe.Leave += new System.EventHandler(this.txtSafe_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.label1.Location = new System.Drawing.Point(173, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 45);
            this.label1.TabIndex = 11;
            this.label1.Text = "Welcome to ShareU";
            // 
            // SignUpForm
            // 
            this.AcceptButton = this.btnSignUp;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(912, 483);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(928, 522);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(928, 522);
            this.Name = "SignUpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sign Up ";
            this.Load += new System.EventHandler(this.SignUpForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SignUpForm_Paint);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtStudentNo;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.ComboBox cmbUniversity;
        private System.Windows.Forms.Button btnSignUp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSafe;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}