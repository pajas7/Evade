namespace Evade_Gui
{
    partial class HerniOkno
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.grBoxHistorie = new System.Windows.Forms.GroupBox();
            this.btnRedu = new System.Windows.Forms.Button();
            this.ListBoxUndoRedu = new System.Windows.Forms.ListBox();
            this.btnUndo = new System.Windows.Forms.Button();
            this.grBoxSpodniLista = new System.Windows.Forms.GroupBox();
            this.InfoObtiznost = new System.Windows.Forms.Label();
            this.btnUkonceniVypoctu = new System.Windows.Forms.Button();
            this.infoHrajiciHrac = new System.Windows.Forms.Label();
            this.progressBarMinimax = new System.Windows.Forms.ProgressBar();
            this.StripMenuSoubor = new System.Windows.Forms.ToolStripMenuItem();
            this.novaHraStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ulozitStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.otevritStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ukoncitHruStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.HlavniNabidkaStrip = new System.Windows.Forms.MenuStrip();
            this.hraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spustitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pozastavitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nastaveniHryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NejTahStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.napovedaStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.pravidlaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grBoxHracNaTahu = new System.Windows.Forms.GroupBox();
            this.infoHrajiciHracHorni = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.Pozadisachovnice = new System.Windows.Forms.Panel();
            this.SachovniceCanvas = new System.Windows.Forms.PictureBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.worker_minimax = new System.ComponentModel.BackgroundWorker();
            this.labelvypocet = new System.Windows.Forms.Label();
            this.worker_minimaxPC = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ovládaníToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grBoxHistorie.SuspendLayout();
            this.grBoxSpodniLista.SuspendLayout();
            this.HlavniNabidkaStrip.SuspendLayout();
            this.grBoxHracNaTahu.SuspendLayout();
            this.Pozadisachovnice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SachovniceCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // grBoxHistorie
            // 
            this.grBoxHistorie.Controls.Add(this.btnRedu);
            this.grBoxHistorie.Controls.Add(this.ListBoxUndoRedu);
            this.grBoxHistorie.Controls.Add(this.btnUndo);
            this.grBoxHistorie.Location = new System.Drawing.Point(1089, 300);
            this.grBoxHistorie.Name = "grBoxHistorie";
            this.grBoxHistorie.Size = new System.Drawing.Size(360, 732);
            this.grBoxHistorie.TabIndex = 3;
            this.grBoxHistorie.TabStop = false;
            this.grBoxHistorie.Text = "Historie";
            // 
            // btnRedu
            // 
            this.btnRedu.Enabled = false;
            this.btnRedu.Location = new System.Drawing.Point(213, 46);
            this.btnRedu.Name = "btnRedu";
            this.btnRedu.Size = new System.Drawing.Size(86, 35);
            this.btnRedu.TabIndex = 6;
            this.btnRedu.Text = "Dopředu";
            this.btnRedu.UseVisualStyleBackColor = true;
            this.btnRedu.Click += new System.EventHandler(this.btnRedu_Click);
            // 
            // ListBoxUndoRedu
            // 
            this.ListBoxUndoRedu.Enabled = false;
            this.ListBoxUndoRedu.FormattingEnabled = true;
            this.ListBoxUndoRedu.ItemHeight = 20;
            this.ListBoxUndoRedu.Location = new System.Drawing.Point(27, 103);
            this.ListBoxUndoRedu.Name = "ListBoxUndoRedu";
            this.ListBoxUndoRedu.Size = new System.Drawing.Size(308, 604);
            this.ListBoxUndoRedu.TabIndex = 0;
            this.ListBoxUndoRedu.Click += new System.EventHandler(this.ListBoxUndoRedu_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Enabled = false;
            this.btnUndo.Location = new System.Drawing.Point(60, 46);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(84, 35);
            this.btnUndo.TabIndex = 5;
            this.btnUndo.Text = "Zpět";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // grBoxSpodniLista
            // 
            this.grBoxSpodniLista.Controls.Add(this.InfoObtiznost);
            this.grBoxSpodniLista.Controls.Add(this.btnUkonceniVypoctu);
            this.grBoxSpodniLista.Controls.Add(this.infoHrajiciHrac);
            this.grBoxSpodniLista.Controls.Add(this.progressBarMinimax);
            this.grBoxSpodniLista.Location = new System.Drawing.Point(0, 1068);
            this.grBoxSpodniLista.Name = "grBoxSpodniLista";
            this.grBoxSpodniLista.Size = new System.Drawing.Size(1478, 52);
            this.grBoxSpodniLista.TabIndex = 4;
            this.grBoxSpodniLista.TabStop = false;
            // 
            // InfoObtiznost
            // 
            this.InfoObtiznost.AutoSize = true;
            this.InfoObtiznost.Location = new System.Drawing.Point(416, 17);
            this.InfoObtiznost.Name = "InfoObtiznost";
            this.InfoObtiznost.Size = new System.Drawing.Size(77, 20);
            this.InfoObtiznost.TabIndex = 7;
            this.InfoObtiznost.Text = "Obtížnost";
            this.InfoObtiznost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnUkonceniVypoctu
            // 
            this.btnUkonceniVypoctu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnUkonceniVypoctu.Enabled = false;
            this.btnUkonceniVypoctu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUkonceniVypoctu.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUkonceniVypoctu.Location = new System.Drawing.Point(1406, 14);
            this.btnUkonceniVypoctu.Name = "btnUkonceniVypoctu";
            this.btnUkonceniVypoctu.Size = new System.Drawing.Size(66, 38);
            this.btnUkonceniVypoctu.TabIndex = 6;
            this.btnUkonceniVypoctu.Text = "X";
            this.btnUkonceniVypoctu.UseVisualStyleBackColor = true;
            this.btnUkonceniVypoctu.Click += new System.EventHandler(this.btnUkonceniVypoctu_Click);
            // 
            // infoHrajiciHrac
            // 
            this.infoHrajiciHrac.AutoSize = true;
            this.infoHrajiciHrac.Location = new System.Drawing.Point(6, 17);
            this.infoHrajiciHrac.Name = "infoHrajiciHrac";
            this.infoHrajiciHrac.Size = new System.Drawing.Size(101, 20);
            this.infoHrajiciHrac.TabIndex = 5;
            this.infoHrajiciHrac.Text = "Hráč na tahu";
            this.infoHrajiciHrac.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBarMinimax
            // 
            this.progressBarMinimax.Location = new System.Drawing.Point(1071, 14);
            this.progressBarMinimax.Name = "progressBarMinimax";
            this.progressBarMinimax.Size = new System.Drawing.Size(330, 38);
            this.progressBarMinimax.Step = 1;
            this.progressBarMinimax.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarMinimax.TabIndex = 0;
            // 
            // StripMenuSoubor
            // 
            this.StripMenuSoubor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novaHraStripMenu,
            this.ulozitStripMenu,
            this.otevritStripMenu,
            this.ukoncitHruStripMenu});
            this.StripMenuSoubor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.StripMenuSoubor.Name = "StripMenuSoubor";
            this.StripMenuSoubor.Size = new System.Drawing.Size(87, 29);
            this.StripMenuSoubor.Text = "Soubor";
            // 
            // novaHraStripMenu
            // 
            this.novaHraStripMenu.Name = "novaHraStripMenu";
            this.novaHraStripMenu.Size = new System.Drawing.Size(205, 34);
            this.novaHraStripMenu.Text = "Nová hra";
            this.novaHraStripMenu.Click += new System.EventHandler(this.novaHraMenu_Click);
            // 
            // ulozitStripMenu
            // 
            this.ulozitStripMenu.Name = "ulozitStripMenu";
            this.ulozitStripMenu.Size = new System.Drawing.Size(205, 34);
            this.ulozitStripMenu.Text = "Uložit";
            this.ulozitStripMenu.Click += new System.EventHandler(this.ulozitStripMenu_Click);
            // 
            // otevritStripMenu
            // 
            this.otevritStripMenu.Name = "otevritStripMenu";
            this.otevritStripMenu.Size = new System.Drawing.Size(205, 34);
            this.otevritStripMenu.Text = "Otevřít";
            this.otevritStripMenu.Click += new System.EventHandler(this.otevritStripMenu_Click);
            // 
            // ukoncitHruStripMenu
            // 
            this.ukoncitHruStripMenu.Name = "ukoncitHruStripMenu";
            this.ukoncitHruStripMenu.Size = new System.Drawing.Size(205, 34);
            this.ukoncitHruStripMenu.Text = "Ukončit hru";
            this.ukoncitHruStripMenu.Click += new System.EventHandler(this.ukoncitHruStripMenu_Click);
            // 
            // HlavniNabidkaStrip
            // 
            this.HlavniNabidkaStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.HlavniNabidkaStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.HlavniNabidkaStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripMenuSoubor,
            this.hraToolStripMenuItem,
            this.NejTahStripMenu,
            this.napovedaStripMenu});
            this.HlavniNabidkaStrip.Location = new System.Drawing.Point(0, 0);
            this.HlavniNabidkaStrip.Name = "HlavniNabidkaStrip";
            this.HlavniNabidkaStrip.Padding = new System.Windows.Forms.Padding(6, 2, 0, 2);
            this.HlavniNabidkaStrip.Size = new System.Drawing.Size(1478, 33);
            this.HlavniNabidkaStrip.TabIndex = 1;
            this.HlavniNabidkaStrip.Text = "Hlavni nabidka";
            // 
            // hraToolStripMenuItem
            // 
            this.hraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spustitToolStripMenuItem,
            this.pozastavitToolStripMenuItem,
            this.nastaveniHryToolStripMenuItem});
            this.hraToolStripMenuItem.Name = "hraToolStripMenuItem";
            this.hraToolStripMenuItem.Size = new System.Drawing.Size(56, 29);
            this.hraToolStripMenuItem.Text = "Hra";
            // 
            // spustitToolStripMenuItem
            // 
            this.spustitToolStripMenuItem.Enabled = false;
            this.spustitToolStripMenuItem.Name = "spustitToolStripMenuItem";
            this.spustitToolStripMenuItem.Size = new System.Drawing.Size(224, 34);
            this.spustitToolStripMenuItem.Text = "Spustit";
            this.spustitToolStripMenuItem.Click += new System.EventHandler(this.spustitToolStripMenuItem_Click);
            // 
            // pozastavitToolStripMenuItem
            // 
            this.pozastavitToolStripMenuItem.Enabled = false;
            this.pozastavitToolStripMenuItem.Name = "pozastavitToolStripMenuItem";
            this.pozastavitToolStripMenuItem.Size = new System.Drawing.Size(224, 34);
            this.pozastavitToolStripMenuItem.Text = "Pozastavit";
            this.pozastavitToolStripMenuItem.Click += new System.EventHandler(this.pozastavitToolStripMenuItem_Click);
            // 
            // nastaveniHryToolStripMenuItem
            // 
            this.nastaveniHryToolStripMenuItem.Name = "nastaveniHryToolStripMenuItem";
            this.nastaveniHryToolStripMenuItem.Size = new System.Drawing.Size(224, 34);
            this.nastaveniHryToolStripMenuItem.Text = "Nastaveni Hry";
            this.nastaveniHryToolStripMenuItem.Click += new System.EventHandler(this.nastaveniHryToolStripMenuItem_Click);
            // 
            // NejTahStripMenu
            // 
            this.NejTahStripMenu.Name = "NejTahStripMenu";
            this.NejTahStripMenu.Size = new System.Drawing.Size(238, 29);
            this.NejTahStripMenu.Text = "Nápověda Nejlepšího tahu";
            this.NejTahStripMenu.Click += new System.EventHandler(this.NejTahStripMenu_Click);
            // 
            // napovedaStripMenu
            // 
            this.napovedaStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pravidlaToolStripMenuItem,
            this.ovládaníToolStripMenuItem});
            this.napovedaStripMenu.Name = "napovedaStripMenu";
            this.napovedaStripMenu.Size = new System.Drawing.Size(110, 29);
            this.napovedaStripMenu.Text = "Napověda";
            // 
            // pravidlaToolStripMenuItem
            // 
            this.pravidlaToolStripMenuItem.Name = "pravidlaToolStripMenuItem";
            this.pravidlaToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.pravidlaToolStripMenuItem.Text = "Pravidla";
            this.pravidlaToolStripMenuItem.Click += new System.EventHandler(this.pravidlaToolStripMenuItem_Click);
            // 
            // grBoxHracNaTahu
            // 
            this.grBoxHracNaTahu.Controls.Add(this.infoHrajiciHracHorni);
            this.grBoxHracNaTahu.Location = new System.Drawing.Point(1089, 82);
            this.grBoxHracNaTahu.Name = "grBoxHracNaTahu";
            this.grBoxHracNaTahu.Size = new System.Drawing.Size(360, 212);
            this.grBoxHracNaTahu.TabIndex = 6;
            this.grBoxHracNaTahu.TabStop = false;
            this.grBoxHracNaTahu.Text = "Hráč na tahu";
            this.grBoxHracNaTahu.Paint += new System.Windows.Forms.PaintEventHandler(this.HrajiciHracInfo);
            // 
            // infoHrajiciHracHorni
            // 
            this.infoHrajiciHracHorni.AutoSize = true;
            this.infoHrajiciHracHorni.Location = new System.Drawing.Point(9, 185);
            this.infoHrajiciHracHorni.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.infoHrajiciHracHorni.Name = "infoHrajiciHracHorni";
            this.infoHrajiciHracHorni.Size = new System.Drawing.Size(120, 20);
            this.infoHrajiciHracHorni.TabIndex = 0;
            this.infoHrajiciHracHorni.Text = "info Hrajici Hrac";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(130, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 36);
            this.label1.TabIndex = 7;
            this.label1.Text = "A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(280, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 36);
            this.label2.TabIndex = 8;
            this.label2.Text = "B";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(430, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 36);
            this.label3.TabIndex = 9;
            this.label3.Text = "C";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(580, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 36);
            this.label4.TabIndex = 10;
            this.label4.Text = "D";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(730, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 36);
            this.label5.TabIndex = 11;
            this.label5.Text = "E";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(880, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 36);
            this.label6.TabIndex = 12;
            this.label6.Text = "F";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(20, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 36);
            this.label7.TabIndex = 13;
            this.label7.Text = "1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(20, 300);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 36);
            this.label8.TabIndex = 14;
            this.label8.Text = "2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(20, 455);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 36);
            this.label9.TabIndex = 15;
            this.label9.Text = "3";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(20, 605);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 36);
            this.label10.TabIndex = 16;
            this.label10.Text = "4";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(20, 751);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 36);
            this.label11.TabIndex = 17;
            this.label11.Text = "5";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(20, 905);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 36);
            this.label12.TabIndex = 18;
            this.label12.Text = "6";
            // 
            // Pozadisachovnice
            // 
            this.Pozadisachovnice.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.Pozadisachovnice.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Pozadisachovnice.Controls.Add(this.SachovniceCanvas);
            this.Pozadisachovnice.Controls.Add(this.label19);
            this.Pozadisachovnice.Controls.Add(this.label13);
            this.Pozadisachovnice.Controls.Add(this.label20);
            this.Pozadisachovnice.Controls.Add(this.label16);
            this.Pozadisachovnice.Controls.Add(this.label21);
            this.Pozadisachovnice.Controls.Add(this.label14);
            this.Pozadisachovnice.Controls.Add(this.label22);
            this.Pozadisachovnice.Controls.Add(this.label18);
            this.Pozadisachovnice.Controls.Add(this.label23);
            this.Pozadisachovnice.Controls.Add(this.label24);
            this.Pozadisachovnice.Controls.Add(this.label15);
            this.Pozadisachovnice.Controls.Add(this.label17);
            this.Pozadisachovnice.Location = new System.Drawing.Point(0, 29);
            this.Pozadisachovnice.Name = "Pozadisachovnice";
            this.Pozadisachovnice.Size = new System.Drawing.Size(1040, 1040);
            this.Pozadisachovnice.TabIndex = 20;
            // 
            // SachovniceCanvas
            // 
            this.SachovniceCanvas.BackgroundImage = global::Evade_Gui.Properties.Resources.pozadisachovnice;
            this.SachovniceCanvas.Location = new System.Drawing.Point(68, 69);
            this.SachovniceCanvas.Name = "SachovniceCanvas";
            this.SachovniceCanvas.Size = new System.Drawing.Size(900, 900);
            this.SachovniceCanvas.TabIndex = 27;
            this.SachovniceCanvas.TabStop = false;
            this.SachovniceCanvas.WaitOnLoad = true;
            this.SachovniceCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.VykresleniSachovnice);
            this.SachovniceCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Sachovnice_click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label19.Location = new System.Drawing.Point(988, 722);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(32, 36);
            this.label19.TabIndex = 25;
            this.label19.Text = "5";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label13.Location = new System.Drawing.Point(880, 988);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(33, 36);
            this.label13.TabIndex = 26;
            this.label13.Text = "F";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label20.Location = new System.Drawing.Point(988, 875);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(32, 36);
            this.label20.TabIndex = 26;
            this.label20.Text = "6";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label16.Location = new System.Drawing.Point(430, 988);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(36, 36);
            this.label16.TabIndex = 23;
            this.label16.Text = "C";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label21.Location = new System.Drawing.Point(988, 575);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(32, 36);
            this.label21.TabIndex = 24;
            this.label21.Text = "4";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label14.Location = new System.Drawing.Point(730, 988);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 36);
            this.label14.TabIndex = 25;
            this.label14.Text = "E";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label22.Location = new System.Drawing.Point(988, 425);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(32, 36);
            this.label22.TabIndex = 23;
            this.label22.Text = "3";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label18.Location = new System.Drawing.Point(130, 988);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(36, 36);
            this.label18.TabIndex = 21;
            this.label18.Text = "A";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label23.Location = new System.Drawing.Point(988, 269);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(32, 36);
            this.label23.TabIndex = 22;
            this.label23.Text = "2";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label24.Location = new System.Drawing.Point(988, 120);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(32, 36);
            this.label24.TabIndex = 21;
            this.label24.Text = "1";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label15.Location = new System.Drawing.Point(580, 988);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(36, 36);
            this.label15.TabIndex = 24;
            this.label15.Text = "D";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label17.Location = new System.Drawing.Point(280, 988);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 36);
            this.label17.TabIndex = 22;
            this.label17.Text = "B";
            // 
            // worker_minimax
            // 
            this.worker_minimax.WorkerReportsProgress = true;
            this.worker_minimax.WorkerSupportsCancellation = true;
            this.worker_minimax.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_minimax_DoWork);
            this.worker_minimax.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.worker_minimax_ProgressChanged);
            this.worker_minimax.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_minimax_RunWorkerCompleted);
            // 
            // labelvypocet
            // 
            this.labelvypocet.AutoSize = true;
            this.labelvypocet.Location = new System.Drawing.Point(1128, 1049);
            this.labelvypocet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelvypocet.Name = "labelvypocet";
            this.labelvypocet.Size = new System.Drawing.Size(231, 20);
            this.labelvypocet.TabIndex = 8;
            this.labelvypocet.Text = "Probíhá výpočet nejlešího tahu..";
            this.labelvypocet.Visible = false;
            // 
            // worker_minimaxPC
            // 
            this.worker_minimaxPC.WorkerReportsProgress = true;
            this.worker_minimaxPC.WorkerSupportsCancellation = true;
            this.worker_minimaxPC.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_minimaxPC_DoWork);
            this.worker_minimaxPC.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.worker_minimax_ProgressChanged);
            this.worker_minimaxPC.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_minimaxPC_RunWorkerCompleted);
            // 
            // ovládaníToolStripMenuItem
            // 
            this.ovládaníToolStripMenuItem.Name = "ovládaníToolStripMenuItem";
            this.ovládaníToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.ovládaníToolStripMenuItem.Text = "Ovládaní hry";
            this.ovládaníToolStripMenuItem.Click += new System.EventHandler(this.ovládaníToolStripMenuItem_Click);
            // 
            // HerniOkno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1478, 1120);
            this.Controls.Add(this.labelvypocet);
            this.Controls.Add(this.HlavniNabidkaStrip);
            this.Controls.Add(this.grBoxSpodniLista);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grBoxHistorie);
            this.Controls.Add(this.grBoxHracNaTahu);
            this.Controls.Add(this.Pozadisachovnice);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MainMenuStrip = this.HlavniNabidkaStrip;
            this.MaximizeBox = false;
            this.Name = "HerniOkno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Evade";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HerniOkno_FormClosing);
            this.grBoxHistorie.ResumeLayout(false);
            this.grBoxSpodniLista.ResumeLayout(false);
            this.grBoxSpodniLista.PerformLayout();
            this.HlavniNabidkaStrip.ResumeLayout(false);
            this.HlavniNabidkaStrip.PerformLayout();
            this.grBoxHracNaTahu.ResumeLayout(false);
            this.grBoxHracNaTahu.PerformLayout();
            this.Pozadisachovnice.ResumeLayout(false);
            this.Pozadisachovnice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SachovniceCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grBoxHistorie;
        private System.Windows.Forms.ProgressBar progressBarMinimax;
        private System.Windows.Forms.ToolStripMenuItem StripMenuSoubor;
        private System.Windows.Forms.ToolStripMenuItem ulozitStripMenu;
        private System.Windows.Forms.ToolStripMenuItem otevritStripMenu;
        private System.Windows.Forms.MenuStrip HlavniNabidkaStrip;
        private System.Windows.Forms.ListBox ListBoxUndoRedu;
        private System.Windows.Forms.ToolStripMenuItem napovedaStripMenu;
        private System.Windows.Forms.ToolStripMenuItem novaHraStripMenu;
        private System.Windows.Forms.Button btnUkonceniVypoctu;
        private System.Windows.Forms.Button btnRedu;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.ToolStripMenuItem NejTahStripMenu;
        private System.Windows.Forms.GroupBox grBoxHracNaTahu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label InfoObtiznost;
        public System.Windows.Forms.GroupBox grBoxSpodniLista;
        private System.Windows.Forms.Label infoHrajiciHrac;
        private System.Windows.Forms.Panel Pozadisachovnice;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.ComponentModel.BackgroundWorker worker_minimax;
        private System.Windows.Forms.ToolStripMenuItem ukoncitHruStripMenu;
        private System.Windows.Forms.ToolStripMenuItem hraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spustitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pozastavitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nastaveniHryToolStripMenuItem;
        private System.Windows.Forms.Label labelvypocet;
        private System.ComponentModel.BackgroundWorker worker_minimaxPC;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox SachovniceCanvas;
        private System.Windows.Forms.Label infoHrajiciHracHorni;
        private System.Windows.Forms.ToolStripMenuItem pravidlaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ovládaníToolStripMenuItem;
    }
}

