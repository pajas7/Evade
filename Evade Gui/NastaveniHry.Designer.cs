namespace Evade_Gui
{
    partial class NastaveniHry
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
            this.grBoxBilyHrac = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioBtnBilaTezka = new System.Windows.Forms.RadioButton();
            this.radioBtnBilaStredni = new System.Windows.Forms.RadioButton();
            this.radioBtnBilaLehka = new System.Windows.Forms.RadioButton();
            this.radioBtnPocitacBila = new System.Windows.Forms.RadioButton();
            this.radioBtnBilaHrac = new System.Windows.Forms.RadioButton();
            this.grBoxCernyHrac = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioBtnCernyTezka = new System.Windows.Forms.RadioButton();
            this.radioBtnCernyStredni = new System.Windows.Forms.RadioButton();
            this.radioBtnCernyLehka = new System.Windows.Forms.RadioButton();
            this.radioBtnCernaPocitac = new System.Windows.Forms.RadioButton();
            this.radioBtnCernaHrac = new System.Windows.Forms.RadioButton();
            this.btnStorno = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.otevrittripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOk = new System.Windows.Forms.Button();
            this.grBoxBilyHrac.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grBoxCernyHrac.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grBoxBilyHrac
            // 
            this.grBoxBilyHrac.Controls.Add(this.panel1);
            this.grBoxBilyHrac.Controls.Add(this.radioBtnPocitacBila);
            this.grBoxBilyHrac.Controls.Add(this.radioBtnBilaHrac);
            this.grBoxBilyHrac.Location = new System.Drawing.Point(52, 51);
            this.grBoxBilyHrac.Name = "grBoxBilyHrac";
            this.grBoxBilyHrac.Size = new System.Drawing.Size(494, 199);
            this.grBoxBilyHrac.TabIndex = 0;
            this.grBoxBilyHrac.TabStop = false;
            this.grBoxBilyHrac.Text = "Nastavení Bílého hráče";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioBtnBilaTezka);
            this.panel1.Controls.Add(this.radioBtnBilaStredni);
            this.panel1.Controls.Add(this.radioBtnBilaLehka);
            this.panel1.Location = new System.Drawing.Point(213, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 180);
            this.panel1.TabIndex = 2;
            // 
            // radioBtnBilaTezka
            // 
            this.radioBtnBilaTezka.AutoSize = true;
            this.radioBtnBilaTezka.Enabled = false;
            this.radioBtnBilaTezka.Location = new System.Drawing.Point(77, 127);
            this.radioBtnBilaTezka.Name = "radioBtnBilaTezka";
            this.radioBtnBilaTezka.Size = new System.Drawing.Size(77, 24);
            this.radioBtnBilaTezka.TabIndex = 2;
            this.radioBtnBilaTezka.Text = "Těžká";
            this.radioBtnBilaTezka.UseVisualStyleBackColor = true;
            // 
            // radioBtnBilaStredni
            // 
            this.radioBtnBilaStredni.AutoSize = true;
            this.radioBtnBilaStredni.Enabled = false;
            this.radioBtnBilaStredni.Location = new System.Drawing.Point(77, 78);
            this.radioBtnBilaStredni.Name = "radioBtnBilaStredni";
            this.radioBtnBilaStredni.Size = new System.Drawing.Size(85, 24);
            this.radioBtnBilaStredni.TabIndex = 1;
            this.radioBtnBilaStredni.Text = "Střední";
            this.radioBtnBilaStredni.UseVisualStyleBackColor = true;
            // 
            // radioBtnBilaLehka
            // 
            this.radioBtnBilaLehka.AutoSize = true;
            this.radioBtnBilaLehka.Checked = true;
            this.radioBtnBilaLehka.Enabled = false;
            this.radioBtnBilaLehka.Location = new System.Drawing.Point(77, 28);
            this.radioBtnBilaLehka.Name = "radioBtnBilaLehka";
            this.radioBtnBilaLehka.Size = new System.Drawing.Size(78, 24);
            this.radioBtnBilaLehka.TabIndex = 0;
            this.radioBtnBilaLehka.TabStop = true;
            this.radioBtnBilaLehka.Text = "Lehká";
            this.radioBtnBilaLehka.UseVisualStyleBackColor = true;
            // 
            // radioBtnPocitacBila
            // 
            this.radioBtnPocitacBila.AutoSize = true;
            this.radioBtnPocitacBila.Location = new System.Drawing.Point(52, 121);
            this.radioBtnPocitacBila.Name = "radioBtnPocitacBila";
            this.radioBtnPocitacBila.Size = new System.Drawing.Size(86, 24);
            this.radioBtnPocitacBila.TabIndex = 1;
            this.radioBtnPocitacBila.TabStop = true;
            this.radioBtnPocitacBila.Text = "Počítač";
            this.radioBtnPocitacBila.UseVisualStyleBackColor = true;
            this.radioBtnPocitacBila.CheckedChanged += new System.EventHandler(this.radioBtnPocitacBila_CheckedChanged);
            // 
            // radioBtnBilaHrac
            // 
            this.radioBtnBilaHrac.AutoSize = true;
            this.radioBtnBilaHrac.Checked = true;
            this.radioBtnBilaHrac.Location = new System.Drawing.Point(52, 58);
            this.radioBtnBilaHrac.Name = "radioBtnBilaHrac";
            this.radioBtnBilaHrac.Size = new System.Drawing.Size(68, 24);
            this.radioBtnBilaHrac.TabIndex = 0;
            this.radioBtnBilaHrac.TabStop = true;
            this.radioBtnBilaHrac.Text = "Hráč";
            this.radioBtnBilaHrac.UseVisualStyleBackColor = true;
            // 
            // grBoxCernyHrac
            // 
            this.grBoxCernyHrac.Controls.Add(this.panel2);
            this.grBoxCernyHrac.Controls.Add(this.radioBtnCernaPocitac);
            this.grBoxCernyHrac.Controls.Add(this.radioBtnCernaHrac);
            this.grBoxCernyHrac.Location = new System.Drawing.Point(52, 284);
            this.grBoxCernyHrac.Name = "grBoxCernyHrac";
            this.grBoxCernyHrac.Size = new System.Drawing.Size(494, 212);
            this.grBoxCernyHrac.TabIndex = 1;
            this.grBoxCernyHrac.TabStop = false;
            this.grBoxCernyHrac.Text = "Nastavení Černého hráče";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioBtnCernyTezka);
            this.panel2.Controls.Add(this.radioBtnCernyStredni);
            this.panel2.Controls.Add(this.radioBtnCernyLehka);
            this.panel2.Location = new System.Drawing.Point(213, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(265, 180);
            this.panel2.TabIndex = 4;
            // 
            // radioBtnCernyTezka
            // 
            this.radioBtnCernyTezka.AutoSize = true;
            this.radioBtnCernyTezka.Enabled = false;
            this.radioBtnCernyTezka.Location = new System.Drawing.Point(77, 127);
            this.radioBtnCernyTezka.Name = "radioBtnCernyTezka";
            this.radioBtnCernyTezka.Size = new System.Drawing.Size(77, 24);
            this.radioBtnCernyTezka.TabIndex = 2;
            this.radioBtnCernyTezka.Text = "Těžká";
            this.radioBtnCernyTezka.UseVisualStyleBackColor = true;
            // 
            // radioBtnCernyStredni
            // 
            this.radioBtnCernyStredni.AutoSize = true;
            this.radioBtnCernyStredni.Enabled = false;
            this.radioBtnCernyStredni.Location = new System.Drawing.Point(77, 78);
            this.radioBtnCernyStredni.Name = "radioBtnCernyStredni";
            this.radioBtnCernyStredni.Size = new System.Drawing.Size(85, 24);
            this.radioBtnCernyStredni.TabIndex = 1;
            this.radioBtnCernyStredni.Text = "Střední";
            this.radioBtnCernyStredni.UseVisualStyleBackColor = true;
            // 
            // radioBtnCernyLehka
            // 
            this.radioBtnCernyLehka.AutoSize = true;
            this.radioBtnCernyLehka.Checked = true;
            this.radioBtnCernyLehka.Enabled = false;
            this.radioBtnCernyLehka.Location = new System.Drawing.Point(77, 28);
            this.radioBtnCernyLehka.Name = "radioBtnCernyLehka";
            this.radioBtnCernyLehka.Size = new System.Drawing.Size(78, 24);
            this.radioBtnCernyLehka.TabIndex = 0;
            this.radioBtnCernyLehka.TabStop = true;
            this.radioBtnCernyLehka.Text = "Lehká";
            this.radioBtnCernyLehka.UseVisualStyleBackColor = true;
            // 
            // radioBtnCernaPocitac
            // 
            this.radioBtnCernaPocitac.AutoSize = true;
            this.radioBtnCernaPocitac.Location = new System.Drawing.Point(52, 128);
            this.radioBtnCernaPocitac.Name = "radioBtnCernaPocitac";
            this.radioBtnCernaPocitac.Size = new System.Drawing.Size(86, 24);
            this.radioBtnCernaPocitac.TabIndex = 1;
            this.radioBtnCernaPocitac.TabStop = true;
            this.radioBtnCernaPocitac.Text = "Počítač";
            this.radioBtnCernaPocitac.UseVisualStyleBackColor = true;
            this.radioBtnCernaPocitac.CheckedChanged += new System.EventHandler(this.radioBtnCernaPocitac_CheckedChanged);
            // 
            // radioBtnCernaHrac
            // 
            this.radioBtnCernaHrac.AutoSize = true;
            this.radioBtnCernaHrac.Checked = true;
            this.radioBtnCernaHrac.Location = new System.Drawing.Point(52, 63);
            this.radioBtnCernaHrac.Name = "radioBtnCernaHrac";
            this.radioBtnCernaHrac.Size = new System.Drawing.Size(68, 24);
            this.radioBtnCernaHrac.TabIndex = 0;
            this.radioBtnCernaHrac.TabStop = true;
            this.radioBtnCernaHrac.Text = "Hráč";
            this.radioBtnCernaHrac.UseVisualStyleBackColor = true;
            // 
            // btnStorno
            // 
            this.btnStorno.Enabled = false;
            this.btnStorno.Location = new System.Drawing.Point(435, 514);
            this.btnStorno.Name = "btnStorno";
            this.btnStorno.Size = new System.Drawing.Size(111, 33);
            this.btnStorno.TabIndex = 2;
            this.btnStorno.Text = "Storno";
            this.btnStorno.UseVisualStyleBackColor = true;
            this.btnStorno.Click += new System.EventHandler(this.btnStorno_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otevrittripMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(578, 33);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // otevrittripMenu
            // 
            this.otevrittripMenu.Enabled = false;
            this.otevrittripMenu.Name = "otevrittripMenu";
            this.otevrittripMenu.Size = new System.Drawing.Size(185, 29);
            this.otevrittripMenu.Text = "Načíst uloženou hru";
            this.otevrittripMenu.Visible = false;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(308, 514);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(111, 33);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // NastaveniHry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 565);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnStorno);
            this.Controls.Add(this.grBoxCernyHrac);
            this.Controls.Add(this.grBoxBilyHrac);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NastaveniHry";
            this.Text = "Nastavení hry";
            this.grBoxBilyHrac.ResumeLayout(false);
            this.grBoxBilyHrac.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grBoxCernyHrac.ResumeLayout(false);
            this.grBoxCernyHrac.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grBoxBilyHrac;
        private System.Windows.Forms.GroupBox grBoxCernyHrac;
        private System.Windows.Forms.RadioButton radioBtnPocitacBila;
        private System.Windows.Forms.RadioButton radioBtnBilaHrac;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioBtnBilaLehka;
        private System.Windows.Forms.RadioButton radioBtnBilaTezka;
        private System.Windows.Forms.RadioButton radioBtnBilaStredni;
        private System.Windows.Forms.RadioButton radioBtnCernaPocitac;
        private System.Windows.Forms.RadioButton radioBtnCernaHrac;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioBtnCernyTezka;
        private System.Windows.Forms.RadioButton radioBtnCernyStredni;
        private System.Windows.Forms.RadioButton radioBtnCernyLehka;
        private System.Windows.Forms.Button btnStorno;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem otevrittripMenu;
        private System.Windows.Forms.Button btnOk;
    }
}