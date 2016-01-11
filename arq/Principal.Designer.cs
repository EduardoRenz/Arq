using System.Windows.Forms;
namespace arq
{
    partial class Principal
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.GroupBox opCredenciais;
            System.Windows.Forms.GroupBox Galcance;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.login = new System.Windows.Forms.Label();
            this.BoxUser = new System.Windows.Forms.TextBox();
            this.BoxSenha = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.Label();
            this.filMax = new System.Windows.Forms.NumericUpDown();
            this.filMin = new System.Windows.Forms.NumericUpDown();
            this.LInicio = new System.Windows.Forms.Label();
            this.Lfim = new System.Windows.Forms.Label();
            this.origem = new System.Windows.Forms.TextBox();
            this.origemlabel = new System.Windows.Forms.Label();
            this.destino = new System.Windows.Forms.TextBox();
            this.destinolabel = new System.Windows.Forms.Label();
            this.info = new System.Windows.Forms.Label();
            this.ok = new System.Windows.Forms.Button();
            this.log = new System.Windows.Forms.RichTextBox();
            this.dica = new System.Windows.Forms.ToolTip(this.components);
            this.barraProgresso = new System.Windows.Forms.ProgressBar();
            this.bgw = new System.ComponentModel.BackgroundWorker();
            this.Abas = new System.Windows.Forms.TabControl();
            this.TabCopia = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            opCredenciais = new System.Windows.Forms.GroupBox();
            Galcance = new System.Windows.Forms.GroupBox();
            opCredenciais.SuspendLayout();
            Galcance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filMin)).BeginInit();
            this.Abas.SuspendLayout();
            this.TabCopia.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // opCredenciais
            // 
            opCredenciais.Controls.Add(this.login);
            opCredenciais.Controls.Add(this.BoxUser);
            opCredenciais.Controls.Add(this.BoxSenha);
            opCredenciais.Controls.Add(this.password);
            opCredenciais.Cursor = System.Windows.Forms.Cursors.Hand;
            opCredenciais.Dock = System.Windows.Forms.DockStyle.Top;
            opCredenciais.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            opCredenciais.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            opCredenciais.Location = new System.Drawing.Point(3, 3);
            opCredenciais.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            opCredenciais.Name = "opCredenciais";
            opCredenciais.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            opCredenciais.Size = new System.Drawing.Size(418, 54);
            opCredenciais.TabIndex = 0;
            opCredenciais.TabStop = false;
            opCredenciais.Text = "Credenciais";
            // 
            // login
            // 
            this.login.AutoSize = true;
            this.login.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login.Location = new System.Drawing.Point(11, 28);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(29, 13);
            this.login.TabIndex = 5;
            this.login.Text = "User";
            // 
            // BoxUser
            // 
            this.BoxUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxUser.Location = new System.Drawing.Point(43, 25);
            this.BoxUser.Name = "BoxUser";
            this.BoxUser.Size = new System.Drawing.Size(135, 20);
            this.BoxUser.TabIndex = 3;
            this.BoxUser.Text = "matriz";
            // 
            // BoxSenha
            // 
            this.BoxSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxSenha.Location = new System.Drawing.Point(244, 25);
            this.BoxSenha.Name = "BoxSenha";
            this.BoxSenha.Size = new System.Drawing.Size(161, 20);
            this.BoxSenha.TabIndex = 4;
            this.BoxSenha.Text = "SAPUCAIA";
            this.BoxSenha.UseSystemPasswordChar = true;
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Location = new System.Drawing.Point(200, 28);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(38, 13);
            this.password.TabIndex = 6;
            this.password.Text = "Senha";
            // 
            // Galcance
            // 
            Galcance.Controls.Add(this.filMax);
            Galcance.Controls.Add(this.filMin);
            Galcance.Controls.Add(this.LInicio);
            Galcance.Controls.Add(this.Lfim);
            Galcance.Cursor = System.Windows.Forms.Cursors.Hand;
            Galcance.Dock = System.Windows.Forms.DockStyle.Top;
            Galcance.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            Galcance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Galcance.Location = new System.Drawing.Point(3, 57);
            Galcance.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            Galcance.Name = "Galcance";
            Galcance.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            Galcance.Size = new System.Drawing.Size(418, 54);
            Galcance.TabIndex = 7;
            Galcance.TabStop = false;
            Galcance.Text = "Alcance";
            // 
            // filMax
            // 
            this.filMax.Location = new System.Drawing.Point(244, 21);
            this.filMax.Name = "filMax";
            this.filMax.Size = new System.Drawing.Size(161, 26);
            this.filMax.TabIndex = 8;
            this.filMax.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // filMin
            // 
            this.filMin.Location = new System.Drawing.Point(43, 22);
            this.filMin.Name = "filMin";
            this.filMin.Size = new System.Drawing.Size(135, 26);
            this.filMin.TabIndex = 7;
            this.filMin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LInicio
            // 
            this.LInicio.AutoSize = true;
            this.LInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LInicio.Location = new System.Drawing.Point(11, 28);
            this.LInicio.Name = "LInicio";
            this.LInicio.Size = new System.Drawing.Size(32, 13);
            this.LInicio.TabIndex = 5;
            this.LInicio.Text = "Inicio";
            // 
            // Lfim
            // 
            this.Lfim.AutoSize = true;
            this.Lfim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lfim.Location = new System.Drawing.Point(200, 28);
            this.Lfim.Name = "Lfim";
            this.Lfim.Size = new System.Drawing.Size(23, 13);
            this.Lfim.TabIndex = 6;
            this.Lfim.Text = "Fim";
            // 
            // origem
            // 
            this.origem.Location = new System.Drawing.Point(120, 12);
            this.origem.Name = "origem";
            this.origem.Size = new System.Drawing.Size(292, 20);
            this.origem.TabIndex = 1;
            // 
            // origemlabel
            // 
            this.origemlabel.AutoSize = true;
            this.origemlabel.Location = new System.Drawing.Point(6, 15);
            this.origemlabel.Name = "origemlabel";
            this.origemlabel.Size = new System.Drawing.Size(94, 13);
            this.origemlabel.TabIndex = 2;
            this.origemlabel.Text = "Arquivo de Origem";
            // 
            // destino
            // 
            this.destino.Location = new System.Drawing.Point(120, 50);
            this.destino.Name = "destino";
            this.destino.Size = new System.Drawing.Size(292, 20);
            this.destino.TabIndex = 1;
            this.destino.Text = "//192.168.FF.PP/sac/prg/";
            // 
            // destinolabel
            // 
            this.destinolabel.AutoSize = true;
            this.destinolabel.Location = new System.Drawing.Point(6, 53);
            this.destinolabel.Name = "destinolabel";
            this.destinolabel.Size = new System.Drawing.Size(82, 13);
            this.destinolabel.TabIndex = 2;
            this.destinolabel.Text = "Arquivo Destino";
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            this.info.Location = new System.Drawing.Point(117, 73);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(183, 13);
            this.info.TabIndex = 3;
            this.info.Text = "//192.168.FF.PP/pasta/novonome.ext";
            this.dica.SetToolTip(this.info, "Manter FF = todas as filiais; Manter PP = todos os PDV\'s");
            // 
            // ok
            // 
            this.ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ok.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ok.FlatAppearance.BorderSize = 3;
            this.ok.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ok.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.ok.ForeColor = System.Drawing.Color.DarkOrange;
            this.ok.Location = new System.Drawing.Point(9, 92);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 4;
            this.ok.Text = "Ok";
            this.ok.UseVisualStyleBackColor = false;
            this.ok.Click += new System.EventHandler(this.button1_Click);
            // 
            // log
            // 
            this.log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.log.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.log.Location = new System.Drawing.Point(9, 121);
            this.log.Name = "log";
            this.log.ReadOnly = true;
            this.log.Size = new System.Drawing.Size(403, 149);
            this.log.TabIndex = 5;
            this.log.Text = "";
            // 
            // barraProgresso
            // 
            this.barraProgresso.Location = new System.Drawing.Point(120, 92);
            this.barraProgresso.Name = "barraProgresso";
            this.barraProgresso.Size = new System.Drawing.Size(292, 23);
            this.barraProgresso.TabIndex = 6;
            // 
            // bgw
            // 
            this.bgw.WorkerReportsProgress = true;
            this.bgw.WorkerSupportsCancellation = true;
            this.bgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            this.bgw.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw_ProgressChanged);
            this.bgw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted);
            // 
            // Abas
            // 
            this.Abas.Controls.Add(this.TabCopia);
            this.Abas.Controls.Add(this.tabPage2);
            this.Abas.Location = new System.Drawing.Point(-6, 0);
            this.Abas.Name = "Abas";
            this.Abas.SelectedIndex = 0;
            this.Abas.Size = new System.Drawing.Size(432, 334);
            this.Abas.TabIndex = 7;
            // 
            // TabCopia
            // 
            this.TabCopia.BackColor = System.Drawing.SystemColors.HotTrack;
            this.TabCopia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TabCopia.Controls.Add(this.origemlabel);
            this.TabCopia.Controls.Add(this.barraProgresso);
            this.TabCopia.Controls.Add(this.origem);
            this.TabCopia.Controls.Add(this.log);
            this.TabCopia.Controls.Add(this.destino);
            this.TabCopia.Controls.Add(this.ok);
            this.TabCopia.Controls.Add(this.destinolabel);
            this.TabCopia.Controls.Add(this.info);
            this.TabCopia.Cursor = System.Windows.Forms.Cursors.Default;
            this.TabCopia.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TabCopia.Location = new System.Drawing.Point(4, 22);
            this.TabCopia.Margin = new System.Windows.Forms.Padding(1);
            this.TabCopia.Name = "TabCopia";
            this.TabCopia.Padding = new System.Windows.Forms.Padding(3);
            this.TabCopia.Size = new System.Drawing.Size(424, 308);
            this.TabCopia.TabIndex = 0;
            this.TabCopia.Text = "Copia";
            this.TabCopia.ToolTipText = "Define Origem e Destino da copia e a executa";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.tabPage2.Controls.Add(Galcance);
            this.tabPage2.Controls.Add(opCredenciais);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(424, 308);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Configurações";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(418, 328);
            this.Controls.Add(this.Abas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Principal";
            this.Text = "Envio de Arquivos nas Filiais";
            opCredenciais.ResumeLayout(false);
            opCredenciais.PerformLayout();
            Galcance.ResumeLayout(false);
            Galcance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filMin)).EndInit();
            this.Abas.ResumeLayout(false);
            this.TabCopia.ResumeLayout(false);
            this.TabCopia.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
              
        #endregion

        private System.Windows.Forms.Label origemlabel;
        private System.Windows.Forms.Label destinolabel;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.Button ok;
        public System.Windows.Forms.TextBox origem;
        public System.Windows.Forms.TextBox destino;
        private System.Windows.Forms.ToolTip dica;
        private System.Windows.Forms.ProgressBar barraProgresso;
        public System.Windows.Forms.RichTextBox log;
        public System.ComponentModel.BackgroundWorker bgw;
        private TabControl Abas;
        private TabPage TabCopia;
        private TabPage tabPage2;
        private Label login;
        public TextBox BoxUser;
        public TextBox BoxSenha;
        private Label password;
        private NumericUpDown filMax;
        private NumericUpDown filMin;
        private Label LInicio;
        private Label Lfim;

      
    }
}

